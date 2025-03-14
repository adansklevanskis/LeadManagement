using LeadManagement.Api.Application.Command;
using LeadManagement.Api.Application.Services;
using LeadManagement.Domain;
using LeadManagement.Domain.Repositories;
using Moq;

namespace LeadManagement.UnitTests;
public class AcceptLeadCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldAcceptLeadAndSaveChanges()
    {
        // Arrange
        var mockRepository = new Mock<ILeadRepository>();
        var mockEmailService = new Mock<IEmailService>();
        var lead = new Lead("John", "Doe", "", "category", "description", 156, "teste@gmail.com", "31-999999");
        mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                      .ReturnsAsync(lead);

        var handler = new AcceptLeadCommandHandler(mockRepository.Object, mockEmailService.Object);
        var command = new AcceptLeadCommand(1);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(LeadStatus.Accepted, lead.Status);
        mockRepository.Verify(repo => repo.UpdateAsync(lead), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowExceptionIfLeadNotFound()
    {
        // Arrange
        var mockRepository = new Mock<ILeadRepository>();
        var mockEmailService = new Mock<IEmailService>();
        mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                      .ReturnsAsync((Lead)null);

        var handler = new AcceptLeadCommandHandler(mockRepository.Object, mockEmailService.Object);
        var command = new AcceptLeadCommand(1);

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(command, CancellationToken.None));
    }
}
