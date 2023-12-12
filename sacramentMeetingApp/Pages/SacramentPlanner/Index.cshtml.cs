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
    public class IndexModel : PageModel
    {
        private readonly sacramentMeetingApp.Data.sacramentMeetingAppContext _context;
        
        public IndexModel(sacramentMeetingApp.Data.sacramentMeetingAppContext context)
        {
            _context = context;
        }

        public IList<SacramentProgram> SacramentProgram { get; set; } = default!;

        public async Task OnGetAsync()
        {
            SacramentProgram = await _context.SacramentProgram.ToListAsync();
        }

        
    }
}
