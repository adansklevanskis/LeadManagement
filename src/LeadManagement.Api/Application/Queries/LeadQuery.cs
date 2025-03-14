using LeadManagement.Domain;
using LeadManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace LeadManagement.Api.Application.Queries;

public class LeadQuery : ILeadQuery
{
    private readonly LeadContext _context;

    public LeadQuery(LeadContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LeadQueryModel>> GetInvitedLeadsAsync()
    {
        return await _context.Leads
            .Where(l => l.Status == LeadStatus.Invited)
            .Select(l => new LeadQueryModel
            {
                Id = l.Id,
                FirstName = l.FirstName,
                LastName = l.LastName,
                Status = l.Status.ToString(),
                DateCreated = l.DateCreated,
                Suburb = l.Suburb,
                Category = l.Category,
                Description = l.Description,
                Price = l.Price,
                Email = l.Email,
                Phone = l.PhoneNumber,
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<LeadQueryModel>> GetAcceptedLeadsAsync()
    {
        return await _context.Leads
            .Where(l => l.Status == LeadStatus.Accepted)
            .Select(l => new LeadQueryModel
            {
                Id = l.Id,
                FirstName = l.FirstName,
                LastName = l.LastName,
                Status = l.Status.ToString(),
                DateCreated = l.DateCreated,
                Suburb = l.Suburb,
                Category = l.Category,
                Description = l.Description,
                Price = l.Price,
                Email = l.Email,
                Phone = l.PhoneNumber,
            })
            .ToListAsync();
    }
}