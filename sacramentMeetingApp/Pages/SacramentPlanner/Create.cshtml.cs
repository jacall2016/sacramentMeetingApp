using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sacramentMeetingApp.Data;
using sacramentMeetingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace sacramentMeetingApp.Pages.SacramentPlanner
{
    public class CreateModel : PageModel
    {
        private readonly sacramentMeetingApp.Data.sacramentMeetingAppContext _context;

        public CreateModel(sacramentMeetingApp.Data.sacramentMeetingAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            LoadUnitNameOptions();
            return Page();
        }

        [BindProperty]
        public SacramentProgram NewSacramentProgram { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.SacramentProgram == null || NewSacramentProgram == null)
            {
                return Page();
            }

            _context.SacramentProgram.Add(NewSacramentProgram);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
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

        public async Task<JsonResult> OnGetHymnsAsync(string q, int page)
        {
            try
            {
                if (page < 1)
                {
                    page = 1;
                }

                int pageSize = 50;
                var hymns = await _context.Hymn
                    .Where(h => h.Title.Contains(q))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new JsonResult(new
                {
                    items = hymns.Select(h => new { id = h.Title, text = h.Title }),
                    total_count = _context.Hymn.Count(h => h.Title.Contains(q))
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
    }
}
