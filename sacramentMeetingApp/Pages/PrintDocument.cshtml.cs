using IronPdf.Razor.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IronPdf;
using sacramentMeetingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace sacramentMeetingApp.Pages
{
    public class PrintDocumentModel : PageModel
    {

        private readonly sacramentMeetingApp.Data.sacramentMeetingAppContext _context;

        public PrintDocumentModel(sacramentMeetingApp.Data.sacramentMeetingAppContext context)
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
            ViewData["IsGeneratingPdf"] = false;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
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

            ViewData["IsGeneratingPdf"] = true;

            ChromePdfRenderer renderer = new ChromePdfRenderer();
            // Render Razor Page to PDF document
            PdfDocument pdf = renderer.RenderRazorToPdf(this);
            Response.Headers.Add("Content-Disposition", "inline");
            // View output PDF on broswer
            return File(pdf.BinaryData, "application/pdf");
        }
    }
}
