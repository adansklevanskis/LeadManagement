namespace LeadManagement.Domain.SeedWork;
public abstract class Entity
{
    public int Id { get; protected set; }

    // Domain event support:
    private List<IDomainEvent> _domainEvents;
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents = _domainEvents ?? new List<IDomainEvent>();
        _domainEvents.Add(domainEvent);
    }

    protected void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents?.Remove(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents?.Clear();

    // Equality based on Id.
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var entity = (Entity)obj;
        return Id == entity.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(Entity a, Entity b)
    {
        if (ReferenceEquals(a, b))
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b) => !(a == b);
}