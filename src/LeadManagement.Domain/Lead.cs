using LeadManagement.Domain.Events;
using LeadManagement.Domain.Exceptions;
using LeadManagement.Domain.SeedWork;

namespace LeadManagement.Domain;

public class Lead : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateCreated { get; private set; }
    public string Suburb { get; private set; }
    public string Category { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public LeadStatus Status { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    private Lead() { }

    public Lead(
        string firstName,
        string lastName,
        string suburb,
        string category,
        string description,
        decimal price,
        string email,
        string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        DateCreated = DateTime.UtcNow;
        Suburb = suburb;
        Category = category;
        Description = description;
        Price = price;
        Email = email;
        PhoneNumber = phoneNumber;
        Status = LeadStatus.Invited;
    }

    // Domain method to accept the lead.
    public void Accept()
    {
        if (Status != LeadStatus.Invited)
            throw new LeadManagementDomainException("Only invited leads can be accepted.");

        Status = LeadStatus.Accepted;
        if (Price > 500)
            Price *= 0.9m;

        // Raise a domain event.
        AddDomainEvent(new LeadAcceptedEvent(this));
    }

    // Domain method to decline the lead.
    public void Decline()
    {
        if (Status != LeadStatus.Invited)
            throw new LeadManagementDomainException("Only invited leads can be declined.");

        Status = LeadStatus.Declined;

        // Raise a domain event.
        AddDomainEvent(new LeadDeclinedEvent(this));
    }
}


public enum LeadStatus
{
    Invited,
    Accepted,
    Declined
}