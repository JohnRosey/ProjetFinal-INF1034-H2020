using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblio.Models;

namespace Biblio.Data
{
    public class BiblioContext : DbContext
    {
        public BiblioContext (DbContextOptions<BiblioContext> options)
            : base(options)
        {
        }

        public DbSet<Biblio.Models.Livres> Livres { get; set; }
    }
}
