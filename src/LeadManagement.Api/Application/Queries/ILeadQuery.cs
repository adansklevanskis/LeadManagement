namespace LeadManagement.Api.Application.Queries;

public interface ILeadQuery
{
    Task<IEnumerable<LeadQueryModel>> GetInvitedLeadsAsync();
    Task<IEnumerable<LeadQueryModel>> GetAcceptedLeadsAsync();
}
