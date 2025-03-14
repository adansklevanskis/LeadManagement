namespace LeadManagement.Api.Application.Services;

public class FileEmailService : IEmailService
{
    private readonly string _emailLogPath;

    public FileEmailService(string emailLogPath)
    {
        _emailLogPath = emailLogPath;
    }

    public async Task SendEmailAsync(string recipient, string subject, string body)
    {
        // Ensure the directory exists
        var directory = Path.GetDirectoryName(_emailLogPath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // Create the email content
        var emailContent = $@"
To: {recipient}
Subject: {subject}
Body:
{body}
Date: {DateTime.Now}
---
";

        // Append the email content to the log file asynchronously
        await File.AppendAllTextAsync(_emailLogPath, emailContent);
    }
}
