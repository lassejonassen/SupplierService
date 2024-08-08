using VendorService.Application.Contacts.Commands.DeleteContact;
using VendorService.Domain.Entities;

namespace VendorService.Application.UnitTests.Contacts.Commands.DeleteContact;

public class DeleteContactCommandHandlerTests
{
	private readonly Mock<IContactRepository> _contactRepositoryMock;
	private readonly Mock<IUnitOfWork> _unitOfWorkMock;

	public DeleteContactCommandHandlerTests()
	{
		_contactRepositoryMock = new Mock<IContactRepository>();
		_unitOfWorkMock = new Mock<IUnitOfWork>();
	}

	[Fact]
	public async Task Handle_Should_ReturnFailureResult_WhenContactIsNotFound()
	{
		// Arrange
		var command = new DeleteContactCommand(Id: Guid.NewGuid());

		_contactRepositoryMock.Setup(
			x => x.GetByIdAsync(
				It.IsAny<Guid>(),
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(Result.Failure<Contact>(DomainErrors.Contact.NotFound));

		var handler = new DeleteContactCommandHandler(
			_contactRepositoryMock.Object,
			_unitOfWorkMock.Object);

		// Act
		Result result = await handler.Handle(command, default);

		// Assert
		result.IsFailure.Should().BeTrue();
		result.Error.Should().Be(DomainErrors.Contact.NotFound);
	}
}
