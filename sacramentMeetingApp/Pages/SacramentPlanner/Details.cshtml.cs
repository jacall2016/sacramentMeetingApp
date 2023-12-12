using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sacramentMeetingApp.Data;
using sacramentMeetingApp.Models;

namespace sacramentMeetingApp.Pages.SacramentPlanner
{
    public class DetailsModel : PageModel
    {
        private readonly sacramentMeetingApp.Data.sacramentMeetingAppContext _context;

        public DetailsModel(sacramentMeetingApp.Data.sacramentMeetingAppContext context)
        {
            _context = context;
        }

        public SacramentProgram SacramentProgram { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentprogram = await _context.SacramentProgram
                                    .Include(_ => _.Talk)
                                    .FirstOrDefaultAsync(m => m.Id == id);
            if (sacramentprogram == null)
            {
                return NotFound();
            }
            else
            {
                SacramentProgram = sacramentprogram;
            }
            return Page();
        }
    }
}
