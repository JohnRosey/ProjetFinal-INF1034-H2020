using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblio.Data;
using Biblio.Models;

namespace Biblio.Pages.Livre
{
    public class EditModel : PageModel
    {
        private readonly Biblio.Data.BiblioContext _context;

        public EditModel(Biblio.Data.BiblioContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Livres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivresExists(Livres.BookId))
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

        private bool LivresExists(int id)
        {
            return _context.Livres.Any(e => e.BookId == id);
        }
    }
}
