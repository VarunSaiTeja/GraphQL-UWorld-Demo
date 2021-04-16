using LearnGQL.GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnGQL.GraphQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }

        public DbSet<Implementation> Implementations { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseImplementation> CourseImplementations { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>()
                .HasKey(t => new { t.UserId, t.GroupId });

            modelBuilder.Entity<UserGroup>()
                .HasOne(pt => pt.User)
                .WithMany(t => t.Groups)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserGroup>()
                .HasOne(pt => pt.Group)
                .WithMany(t => t.Users)
                .HasForeignKey(pt => pt.GroupId);
        }
    }
}
