using LearnGQL.GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnGQL.GraphQL.Data
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
