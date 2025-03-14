namespace LeadManagement.Domain.Exceptions;

public class LeadManagementDomainException : Exception
{
    public LeadManagementDomainException()
    { }

    public LeadManagementDomainException(string message)
        : base(message)
    { }

    public LeadManagementDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}