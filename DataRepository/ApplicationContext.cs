using Microsoft.EntityFrameworkCore;

namespace DataRepository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new EventMap(modelBuilder.Entity<Event>());
        }
    }
}

