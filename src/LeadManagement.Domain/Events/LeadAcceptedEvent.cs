using LeadManagement.Domain.SeedWork;

namespace LeadManagement.Domain.Events;
public class LeadAcceptedEvent : IDomainEvent
{
    public DateTime OccurredOn { get; }
    public int LeadId { get; }
    public decimal NewPrice { get; }

    public LeadAcceptedEvent(Lead lead)
    {
        OccurredOn = DateTime.UtcNow;
        LeadId = lead.Id;
        NewPrice = lead.Price;
    }
}