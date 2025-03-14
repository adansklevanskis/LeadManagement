using LeadManagement.Domain.SeedWork;

namespace LeadManagement.Infrastructure.EventStore;
public interface IEventStore
{
    Task SaveEventsAsync(int aggregateId, IEnumerable<IDomainEvent> events);
}