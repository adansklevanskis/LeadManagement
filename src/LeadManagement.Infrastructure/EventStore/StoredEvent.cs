namespace LeadManagement.Infrastructure.EventStore;
public class StoredEvent
{
    public int Id { get; set; }
    public int AggregateId { get; set; }
    public string EventType { get; set; }
    public string Data { get; set; }
    public DateTime OccurredOn { get; set; }
}