﻿using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Entities;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.Products.Queries.GetAllProducts;

internal sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<Product>>
{
	private readonly IProductRepository _productRepository;

	public GetAllProductsQueryHandler(IProductRepository productRepository)
	{
		_productRepository = productRepository;
	}

	public async Task<Result<IEnumerable<Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
	{
		return await _productRepository.GetAllAsync(cancellationToken);
	}
}
