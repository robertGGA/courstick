using Microsoft.EntityFrameworkCore;

namespace Courstick.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
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
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
