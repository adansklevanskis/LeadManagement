using LeadManagement.Domain;
using LeadManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.Repositories;
public class LeadRepository : ILeadRepository
{
    private readonly LeadContext _context;

    public LeadRepository(LeadContext context)
    {
        _context = context;
    }

    public async Task<List<Lead>> GetByStatusAsync(LeadStatus status)
    {
        return await _context.Leads.Where(l => l.Status == status).ToListAsync();
    }

    public async Task<Lead> GetByIdAsync(int id)
    {
        return await _context.Leads.FindAsync(id);
    }

    public async Task AddAsync(Lead lead)
    {
        await _context.Leads.AddAsync(lead);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Lead lead)
    {
        _context.Leads.Update(lead);
        await _context.SaveChangesAsync();
    }
}