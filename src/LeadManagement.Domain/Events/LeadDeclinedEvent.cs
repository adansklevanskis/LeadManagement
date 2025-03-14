using LeadManagement.Domain.SeedWork;

namespace LeadManagement.Domain.Events;
public class LeadDeclinedEvent : IDomainEvent
{
    public DateTime OccurredOn { get; }
    public int LeadId { get; }

    public LeadDeclinedEvent(Lead lead)
    {
        OccurredOn = DateTime.UtcNow;
        LeadId = lead.Id;
    }
}