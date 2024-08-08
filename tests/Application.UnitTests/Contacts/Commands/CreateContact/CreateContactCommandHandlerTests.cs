using VendorService.Application.Contacts.Commands.CreateContact;
using VendorService.Application.UnitTests.Helpers.Vendors;
using VendorService.Domain.Entities;

namespace VendorService.Application.UnitTests.Contacts.Commands.CreateContact;

public class CreateContactCommandHandlerTests
{
	private readonly Mock<IContactRepository> _contactRepositoryMock;
	private readonly Mock<IVendorRepository> _vendorRepositoryMock;
	private readonly Mock<IUnitOfWork> _unitOfWorkMock;

	public CreateContactCommandHandlerTests()
	{
		_contactRepositoryMock = new Mock<IContactRepository>();
		_vendorRepositoryMock = new Mock<IVendorRepository>();
		_unitOfWorkMock = new Mock<IUnitOfWork>();
	}

	[Fact]
	public async Task Handle_Should_ReturnFailureResult_WhenEmailIsNotUnique()
	{
		// Arrange
		var command = new CreateContactCommand(
			FirstName: "John", LastName: "Doe",
			Email: "johndoe@mail.com", Phone: "12341234",
			Notes: null,
			SupplierId: Guid.NewGuid());

		_contactRepositoryMock.Setup(
			x => x.IsEmailUnique(
				It.IsAny<string>(),
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(false);

		var handler = new CreateContactCommandHandler(
			_contactRepositoryMock.Object,
			_vendorRepositoryMock.Object,
			_unitOfWorkMock.Object);

		// Act
		Result<Guid> result = await handler.Handle(command, default);

		// Assert
		result.IsFailure.Should().BeTrue();
		result.Error.Should().Be(DomainErrors.Contact.EmailAlreadyInUse);
	}

	[Fact]
	public async Task Handle_Should_ReturnSuccessResult_WhenEmailIsUnique()
	{
		// Arrange
		var command = new CreateContactCommand(
			FirstName: "John", LastName: "Doe",
			Email: "johndoe@mail.com", Phone: "12341234",
			Notes: null,
			SupplierId: Guid.NewGuid());

		_contactRepositoryMock.Setup(
			x => x.IsEmailUnique(
				It.IsAny<string>(),
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(true);

		_vendorRepositoryMock.Setup(
			x => x.GetByIdAsync(
				It.IsAny<Guid>(),
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(VendorGenerator.Vendor());

		var handler = new CreateContactCommandHandler(
			_contactRepositoryMock.Object,
			_vendorRepositoryMock.Object,
			_unitOfWorkMock.Object);

		// Act
		Result<Guid> result = await handler.Handle(command, default);

		// Assert
		result.IsSuccess.Should().BeTrue();
		result.Value.Should().NotBeEmpty();
	}

	[Fact]
	public async Task Handle_Should_ReturnFailureResult_WhenSupplierIsNotFound()
	{
		// Arrange
		var command = new CreateContactCommand(
			FirstName: "John", LastName: "Doe",
			Email: "johndoe@mail.com", Phone: "12341234",
			Notes: null,
			SupplierId: Guid.NewGuid());

		_contactRepositoryMock.Setup(
			x => x.IsEmailUnique(
				It.IsAny<string>(),
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(true);

		_vendorRepositoryMock.Setup(
			x => x.GetByIdAsync(
				It.IsAny<Guid>(),
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(Result.Failure<Vendor>(DomainErrors.Vendor.NotFound));

		var handler = new CreateContactCommandHandler(
			_contactRepositoryMock.Object,
			_vendorRepositoryMock.Object,
			_unitOfWorkMock.Object);

		// Act
		Result<Guid> result = await handler.Handle(command, default);

		// Assert
		result.IsFailure.Should().BeTrue();
		result.Error.Should().Be(DomainErrors.Vendor.NotFound);
	}

	[Fact]
	public async Task Handle_Should_ReturnSuccessResult_WhenSupplierIsFound()
	{
		// Arrange
		var command = new CreateContactCommand(
			FirstName: "John", LastName: "Doe",
			Email: "johndoe@mail.com", Phone: "12341234",
			Notes: null,
			SupplierId: Guid.NewGuid());

		_contactRepositoryMock.Setup(
			x => x.IsEmailUnique(
				It.IsAny<string>(),
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(true);

		_vendorRepositoryMock.Setup(
				x => x.GetByIdAsync(
					It.IsAny<Guid>(),
					It.IsAny<CancellationToken>()))
				.ReturnsAsync(VendorGenerator.Vendor());

		var handler = new CreateContactCommandHandler(
			_contactRepositoryMock.Object,
			_vendorRepositoryMock.Object,
			_unitOfWorkMock.Object);

		// Act
		Result<Guid> result = await handler.Handle(command, default);

		// Assert
		result.IsSuccess.Should().BeTrue();
		result.Value.Should().NotBeEmpty();
	}
}
