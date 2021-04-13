using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biblio.Data;
using Biblio.Models;

namespace Biblio.Pages.Livre
{
    public class DeleteModel : PageModel
    {
        private readonly Biblio.Data.BiblioContext _context;

        public DeleteModel(Biblio.Data.BiblioContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Livres Livres { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Livres = await _context.Livres.FirstOrDefaultAsync(m => m.BookId == id);

            if (Livres == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Livres = await _context.Livres.FindAsync(id);

            if (Livres != null)
            {
                _context.Livres.Remove(Livres);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
