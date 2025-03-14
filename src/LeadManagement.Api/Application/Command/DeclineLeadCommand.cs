using MediatR;

namespace LeadManagement.Api.Application.Command;

public class DeclineLeadCommand : IRequest
{
    public int LeadId { get; set; }

    public DeclineLeadCommand(int leadId)
    {
        LeadId = leadId;
    }
}