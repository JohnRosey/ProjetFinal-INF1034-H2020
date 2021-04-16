using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblio.Models;
using Biblio.Pages.Livre;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Biblio
{
    public class IndexModelLivre : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly Biblio.Data.BiblioContext _context;
        
        public IndexModelLivre(ILogger<IndexModel> logger,
            Biblio.Data.BiblioContext context)
        {
            _logger = logger;
            _context = context;
        }
       
        public IList<Livres> Livre { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Categorie { get; set; }
        [BindProperty(SupportsGet = true)]
        public string LivreCategorie { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> categQuery = from m in _context.Livres
                                           orderby m.Categorie.ToString()
                                           select m.Categorie.ToString();


            var livres = from m in _context.Livres
                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                livres = livres.Where(s => s.Title.Contains(SearchString));

            }

            if (!string.IsNullOrEmpty(LivreCategorie))
            {

                livres = livres.Where(s => s.Categorie.ToString() == LivreCategorie);
            }
           // Categorie = new SelectList(await categQuery.Distinct().ToListAsync());

            Livre = await livres.ToListAsync();
            
        }
       

    }
}