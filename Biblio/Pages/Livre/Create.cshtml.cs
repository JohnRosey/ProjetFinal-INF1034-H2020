using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Biblio.Data;
using Biblio.Models;

namespace Biblio.Pages.Livre
{
    public class CreateModel : PageModel
    {
        private readonly Biblio.Data.BiblioContext _context;

        public CreateModel(Biblio.Data.BiblioContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Livres Livres { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Livres.Add(Livres);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
