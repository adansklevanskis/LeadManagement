namespace LeadManagement.Domain.Repositories;

public interface ILeadRepository
{
    Task<Lead> GetByIdAsync(int id);
    Task AddAsync(Lead lead);
    Task UpdateAsync(Lead lead);
}