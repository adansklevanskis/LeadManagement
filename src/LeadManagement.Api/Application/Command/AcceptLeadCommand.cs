using MediatR;

namespace LeadManagement.Api.Application.Command;

public class AcceptLeadCommand : IRequest
{
    public int LeadId { get; set; }

    public AcceptLeadCommand(int leadId)
    {
        LeadId = leadId;
    }
}
