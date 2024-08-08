using FluentAssertions;
using Moq;
using VendorService.Application.Vendors.Commands.CreateVendor;
using VendorService.Domain.Errors;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.UnitTests.SupplierService.Application.UnitTests.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommandHandlerTests
{
	private readonly Mock<IVendorRepository> _supplierRepositoryMock;
	private readonly Mock<IUnitOfWork> _unitOfWorkMock;

	public CreateSupplierCommandHandlerTests()
	{
		_supplierRepositoryMock = new Mock<IVendorRepository>();
		_unitOfWorkMock = new Mock<IUnitOfWork>();
	}

	[Fact]
	public async Task Handle_Should_ReturnFailureResult_WhenNameIsNotUnique()
	{
		var command = new CreateVendorCommand(
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

		var handler = new CreateVendorCommandHandler(_supplierRepositoryMock.Object, _unitOfWorkMock.Object);

		// Act
		Result<Guid> result = await handler.Handle(command, default);

		// Assert
		result.IsFailure.Should().BeTrue();
		result.Error.Should().Be(DomainErrors.Vendor.NameAlreadyExists);
	}

	[Fact]
	public async Task Handle_Should_ReturnFailureResult_WhenEmailIsNotUnique()
	{
		var command = new CreateVendorCommand(
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

		var handler = new CreateVendorCommandHandler(_supplierRepositoryMock.Object, _unitOfWorkMock.Object);

		// Act
		Result<Guid> result = await handler.Handle(command, default);

		// Assert
		result.IsFailure.Should().BeTrue();
		result.Error.Should().Be(DomainErrors.Vendor.EmailAlreadyInUse);
	}
}
