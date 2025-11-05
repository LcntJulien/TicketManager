using Microsoft.EntityFrameworkCore;
using TicketManager.Core.Entities;

namespace TicketManager.Infrastructure.Data
{
    public class TicketManagerDbContext : DbContext
    {
        public TicketManagerDbContext(DbContextOptions<TicketManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketManagerDbContext).Assembly);
        }
    }
}
