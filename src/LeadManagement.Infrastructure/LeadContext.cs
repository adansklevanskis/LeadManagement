using LeadManagement.Domain;
using LeadManagement.Domain.SeedWork;
using LeadManagement.Infrastructure.EntityConfigurations;
using LeadManagement.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure;

public class LeadContext : DbContext, IUnitOfWork
{
    public DbSet<Lead> Leads { get; set; }

    // Modify the constructor so that the IEventStore is injected.
    public LeadContext(DbContextOptions<LeadContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply Lead configuration.
        modelBuilder.ApplyConfiguration(new LeadConfiguration());

        // Apply the StoredEvent configuration via the extension method.
        modelBuilder.AddStoredEvents();

        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Overrides SaveChangesAsync to first persist all database changes,
    /// and then persist domain events from aggregates tracked by the context,
    /// using the injected event store.
    /// </summary>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Save changes to the main database.
        int result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

}
