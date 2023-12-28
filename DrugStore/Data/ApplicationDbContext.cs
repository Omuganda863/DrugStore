using DrugStore.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace DrugStore.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<User>users { get; set; }
        public DbSet<Drugs> drugs { get; set; }

    }
}
