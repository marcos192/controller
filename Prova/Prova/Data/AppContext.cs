using Microsoft.EntityFrameworkCore;
using Prova.Models;

namespace Prova.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base (options)
        { 
            
        }

        public DbSet<Produto> Prod { get; set; }
    }
}
