using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sacramentMeetingApp.Data;
using sacramentMeetingApp.Models;

namespace sacramentMeetingApp.Pages.SacramentPlanner
{
    public class EditModel : PageModel
    {
        private readonly sacramentMeetingApp.Data.sacramentMeetingAppContext _context;

        public EditModel(sacramentMeetingApp.Data.sacramentMeetingAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SacramentProgram SacramentProgram { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            LoadUnitNameOptions();
            var sacramentprogram = await _context.SacramentProgram
                                    .Include(s => s.Talk)
                                    .FirstOrDefaultAsync(m => m.Id == id);
            if (sacramentprogram == null)
            {
                return NotFound();
            }
            SacramentProgram = sacramentprogram;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (SacramentProgram == null)
            {
                return NotFound();
            }

            _context.Attach(SacramentProgram).State = EntityState.Modified;
            if (SacramentProgram.Talk != null)
            {
                foreach (var talk in SacramentProgram.Talk)
                {
                    if (talk.IsDeleted)
                    {
                        _context.Talk.Remove(talk);
                    }
                    else if (talk.Id == 0)
                    {
                        _context.Talk.Add(talk);
                    }
                    else
                    {
                        _context.Attach(talk).State = EntityState.Modified;
                    }
                }
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SacramentProgramExists(SacramentProgram.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SacramentProgramExists(int id)
        {
            return _context.SacramentProgram.Any(e => e.Id == id);
        }

        private void LoadUnitNameOptions()
        {
            // Use LINQ to get list of unit names.
            var unitNames = _context.Unit.ToList();
            // Use LINQ to get list of member names.
            var memberName = _context.Member.ToList();
            // Create a list of unit names and unit types.
            var unitNameOptions = unitNames.Select(u => new { Value = $"{u.UnitName} {u.UnitType}", Text = $"{u.UnitName} {u.UnitType}" }).ToList();
            ViewData["UnitNameOptions"] = new SelectList(unitNameOptions, "Value", "Text");
            // Create a list of member names and positions.
            var memberOptions = memberName.Select(m =>
            {
                var prefix = m.Position?.ToLower() == "member" ? m.Gender switch
                {
                    GenderType.Male => "Brother",
                    GenderType.Female => "Sister",
                    _ => string.Empty
                } : string.Empty;

                return new
                {
                    Value = string.IsNullOrEmpty(prefix) ? $"{m.Name}, {m.Position}" : $"{prefix} {m.Name}",
                    Text = string.IsNullOrEmpty(prefix) ? $"{m.Name}, {m.Position}" : $"{prefix} {m.Name}"
                };
            }).ToList();
            ViewData["MemberNameOptions"] = new SelectList(memberOptions, "Value", "Text");

            var hymns = _context.Hymn.ToList();
            ViewData["hymnOptions"] = new SelectList(hymns, "Title", "Title");
        }

    }
}
