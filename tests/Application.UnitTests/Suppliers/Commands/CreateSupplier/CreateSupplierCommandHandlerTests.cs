using FluentAssertions;
using Moq;
using SupplierService.Application.Suppliers.Commands.CreateSupplier;
using SupplierService.Domain.Repositories;
using SupplierService.Domain.Shared;
using SupplierService.Domain.Errors;

namespace SupplierService.Application.UnitTests.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommandHandlerTests
{
	private readonly Mock<ISupplierRepository> _supplierRepositoryMock;
	private readonly Mock<IUnitOfWork> _unitOfWorkMock;

	public CreateSupplierCommandHandlerTests()
	{
		_supplierRepositoryMock = new Mock<ISupplierRepository>();
		_unitOfWorkMock = new Mock<IUnitOfWork>();
	}

	[Fact]
	public async Task Handle_Should_ReturnFailureResult_WhenNameIsNotUnique()
	{
		var command = new CreateSupplierCommand(
			Name: "Supplier Name",
			Street: "Supplier Address",
			City: "Some city",
			State: null,
			PostalCode: "1234",
			Country: "Denmark",
			Phone: "12341234",
			Email: "test@mail.com",
			Notes: null);

		_supplierRepositoryMock.Setup(
			x => x.IsNameUnique(
			It.IsAny<string>(),
			It.IsAny<CancellationToken>()))
			.ReturnsAsync(false);

		var handler = new CreateSupplierCommandHandler(_supplierRepositoryMock.Object, _unitOfWorkMock.Object);

		// Act
		Result<Guid> result = await handler.Handle(command, default);

		// Assert
		result.IsFailure.Should().BeTrue();
		result.Error.Should().Be(DomainErrors.Supplier.NameAlreadyExists);
	}

	[Fact]
	public async Task Handle_Should_ReturnFailureResult_WhenEmailIsNotUnique()
	{
		var command = new CreateSupplierCommand(
			Name: "Supplier Name",
			Street: "Supplier Address",
			City: "Some city",
			State: null,
			PostalCode: "1234",
			Country: "Denmark",
			Phone: "12341234",
			Email: "test@mail.com",
			Notes: null);

		_supplierRepositoryMock.Setup(
			x => x.IsEmailUnique(
			It.IsAny<string>(),
			It.IsAny<CancellationToken>()))
			.ReturnsAsync(false);

		var handler = new CreateSupplierCommandHandler(_supplierRepositoryMock.Object, _unitOfWorkMock.Object);

		// Act
		Result<Guid> result = await handler.Handle(command, default);

		// Assert
		result.IsFailure.Should().BeTrue();
		result.Error.Should().Be(DomainErrors.Supplier.EmailAlreadyInUse);
	}
}
