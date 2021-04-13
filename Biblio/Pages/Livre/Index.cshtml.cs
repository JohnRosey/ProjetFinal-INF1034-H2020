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
    public class IndexModel : PageModel
    {
        private readonly Biblio.Data.BiblioContext _context;

        public IndexModel(Biblio.Data.BiblioContext context)
        {
            _context = context;
        }

        public IList<Livres> Livres { get;set; }

        public async Task OnGetAsync()
        {
            Livres = await _context.Livres.ToListAsync();
        }
    }
}
