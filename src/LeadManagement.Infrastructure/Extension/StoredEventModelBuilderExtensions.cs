using LeadManagement.Infrastructure.EventStore;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.Extension;

public static class StoredEventModelBuilderExtensions
{
    /// <summary>
    /// Configures the StoredEvent entity.
    /// </summary>
    /// <param name="modelBuilder">The EF Core ModelBuilder.</param>
    /// <returns>The updated ModelBuilder instance.</returns>
    public static ModelBuilder AddStoredEvents(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StoredEvent>(builder =>
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.EventType)
                   .IsRequired();

            builder.Property(e => e.Data)
                   .IsRequired();

            builder.Property(e => e.OccurredOn)
                   .IsRequired();

            // Optionally, define the table name.
            builder.ToTable("StoredEvents");
        });

        return modelBuilder;
    }
}