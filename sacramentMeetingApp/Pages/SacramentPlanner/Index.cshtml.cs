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

        [BindProperty(SupportsGet = true)]
        public string? sortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortByOrder { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            var units = from m in _context.SacramentProgram
                        select m;

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                units = units.Where(s => s != null && s.UnitName != null && s.UnitName.ToLower().Contains(SearchTerm.ToLower()));
            }

            SortByOrder = String.IsNullOrEmpty(SortByOrder) ? "desc" : "";

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "Date_Asc":
                        units = SortByOrder == "desc"
                            ? units.OrderBy(item => item.Date)
                            : units.OrderByDescending(item => item.Date);
                        break;
                    case "Date_Desc":
                        units = SortByOrder == "desc"
                            ? units.OrderByDescending(item => item.Date)
                            : units.OrderBy(item => item.Date);
                        break;
                }
            }
            SacramentProgram = await units.ToListAsync();
        }


    }
}
