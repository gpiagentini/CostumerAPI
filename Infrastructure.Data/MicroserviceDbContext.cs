using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MicroserviceDbContext : DbContext
    {

        public MicroserviceDbContext(DbContextOptions<MicroserviceDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<CustomerBase> CustomerBase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MicroserviceDbContext).Assembly);
        }

    }
}