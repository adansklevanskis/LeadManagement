using LeadManagement.Domain.Repositories;
using MediatR;

namespace LeadManagement.Api.Application.Command;

public class DeclineLeadCommandHandler : IRequestHandler<DeclineLeadCommand>
{
    private readonly ILeadRepository _repository;

    public DeclineLeadCommandHandler(ILeadRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
    {
        // Fetch the lead by ID
        var lead = await _repository.GetByIdAsync(request.LeadId);
        if (lead == null)
        {
            throw new KeyNotFoundException("Lead not found.");
        }

        lead.Decline();

        await _repository.UpdateAsync(lead);

    }
}