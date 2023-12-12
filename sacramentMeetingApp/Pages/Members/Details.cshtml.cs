using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sacramentMeetingApp.Data;
using sacramentMeetingApp.Models;

namespace sacramentMeetingApp.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly sacramentMeetingApp.Data.sacramentMeetingAppContext _context;

        public DetailsModel(sacramentMeetingApp.Data.sacramentMeetingAppContext context)
        {
            _context = context;
        }

        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            else
            {
                Member = member;
            }
            return Page();
        }
    }
}
