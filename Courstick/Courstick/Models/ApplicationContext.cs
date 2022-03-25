using Microsoft.EntityFrameworkCore;

namespace Courstick.Models
{
    public class ApplicationContext : DbContext
    {
        
        public DbSet<Role> Roles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubType> SubTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasMany(c => c.Author).WithMany(c => c.AuthorOf);
            modelBuilder.Entity<Course>().HasMany(c => c.Users).WithMany(c => c.Courses);
            base.OnModelCreating(modelBuilder);
        }   
    }
}
