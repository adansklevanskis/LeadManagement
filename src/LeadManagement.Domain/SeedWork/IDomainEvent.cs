namespace LeadManagement.Domain.SeedWork;
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}