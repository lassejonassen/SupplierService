using Microsoft.EntityFrameworkCore;
using SupplierService.Domain.Entities;

namespace SupplierService.Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext
{
	public DbSet<Supplier> Suppliers => Set<Supplier>();
	public DbSet<ProductType> ProductTypes => Set<ProductType>();
	public DbSet<Product> Products => Set<Product>();
	public DbSet<Contact> Contacts => Set<Contact>();

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		var assembly = typeof(ApplicationDbContext).Assembly;
		modelBuilder.ApplyConfigurationsFromAssembly(assembly);
	}
}
