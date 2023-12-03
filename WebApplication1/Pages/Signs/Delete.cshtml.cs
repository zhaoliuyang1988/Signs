using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Signs
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public DeleteModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Sign Sign { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sign == null)
            {
                return NotFound();
            }

            var sign = await _context.Sign.FirstOrDefaultAsync(m => m.ID == id);

            if (sign == null)
            {
                return NotFound();
            }
            else 
            {
                Sign = sign;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sign == null)
            {
                return NotFound();
            }
            var sign = await _context.Sign.FindAsync(id);

            if (sign != null)
            {
                Sign = sign;
                _context.Sign.Remove(Sign);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
