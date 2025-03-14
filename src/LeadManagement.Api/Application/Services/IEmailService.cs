namespace LeadManagement.Api.Application.Services;

public interface IEmailService
{
    Task SendEmailAsync(string recipient, string subject, string body);
}

