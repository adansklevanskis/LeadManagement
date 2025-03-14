using LeadManagement.Domain.SeedWork;
using System.Text.Json;

namespace LeadManagement.Infrastructure.EventStore;

public class DatabaseEventStore : IEventStore
{
    private readonly LeadContext _context;

    public DatabaseEventStore(LeadContext context)
    {
        _context = context;
    }

    public async Task SaveEventsAsync(int aggregateId, IEnumerable<IDomainEvent> events)
    {
        foreach (var domainEvent in events)
        {
            var storedEvent = new StoredEvent
            {
                AggregateId = aggregateId,
                EventType = domainEvent.GetType().AssemblyQualifiedName,
                Data = JsonSerializer.Serialize(domainEvent, domainEvent.GetType()),
                OccurredOn = domainEvent.OccurredOn
            };

            await _context.Set<StoredEvent>().AddAsync(storedEvent);
        }
        await _context.SaveChangesAsync();
    }
}
