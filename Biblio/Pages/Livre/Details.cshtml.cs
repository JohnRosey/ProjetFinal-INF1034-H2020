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
    public class DetailsModel : PageModel
    {
        private readonly Biblio.Data.BiblioContext _context;

        public DetailsModel(Biblio.Data.BiblioContext context)
        {
            _context = context;
        }

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
    }
}
