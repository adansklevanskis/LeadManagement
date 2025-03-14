using LeadManagement.Domain;
using LeadManagement.Infrastructure;
using LeadManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.UnitTests;
public class LeadRepositoryTests
{
    private LeadContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<LeadContext>()
            .UseInMemoryDatabase(databaseName: "LeadManagement")
            .Options;
        return new LeadContext(options);
    }

    [Fact]
    public async Task GetByStatusAsync_ShouldReturnLeadsWithSpecifiedStatus()
    {
        // Arrange
        var context = GetDbContext();
        var repository = new LeadRepository(context);

        var lead1 = new Lead("Jane", "Smith", "", "category", "description", 156, "teste@gmail.com", "31-999999");
        lead1.Accept();

        await context.Leads.AddRangeAsync(
            new Lead("John", "Doe", "", "category", "description", 156, "teste@gmail.com", "31-999999"),
            lead1);
        await context.SaveChangesAsync();

        // Act
        var invitedLeads = await repository.GetByStatusAsync(LeadStatus.Invited);

        // Assert
        Assert.Single(invitedLeads);
        Assert.Equal("John", invitedLeads.First().FirstName);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectLead()
    {
        // Arrange
        var context = GetDbContext();
        var repository = new LeadRepository(context);

        var lead = new Lead("John", "Doe", "", "category", "description", 156, "teste@gmail.com", "31-999999");
        context.Leads.Add(lead);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetByIdAsync(lead.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(lead.FirstName, result.FirstName);
    }
}