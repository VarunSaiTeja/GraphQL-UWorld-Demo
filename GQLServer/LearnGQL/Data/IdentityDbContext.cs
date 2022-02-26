using LearnGQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnGQL.Data
{
    public class IdentityDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Identity.db");
        }

        public DbSet<Identity> Identities { get; set; }
    }
}
