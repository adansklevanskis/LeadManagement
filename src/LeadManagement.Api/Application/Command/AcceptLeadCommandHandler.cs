using LeadManagement.Api.Application.Services;
using LeadManagement.Domain.Repositories;
using MediatR;

namespace LeadManagement.Api.Application.Command;

public class AcceptLeadCommandHandler : IRequestHandler<AcceptLeadCommand>
{
    private readonly ILeadRepository _repository;
    private readonly IEmailService _emailService;

    public AcceptLeadCommandHandler(ILeadRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    public async Task Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = await _repository.GetByIdAsync(request.LeadId);
        if (lead == null)
            throw new KeyNotFoundException("Lead not found.");

        lead.Accept();

        await _repository.UpdateAsync(lead);

        // Send notification email asynchronously
        await _emailService.SendEmailAsync(
            recipient: "admin@leadsystem.com",
            subject: $"Lead Accepted: {lead.FirstName} {lead.LastName}",
            body: $"The lead '{lead.FirstName} {lead.LastName}' has been accepted. Status: {lead.Status}");


    }
}