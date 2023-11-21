using Inlämningsuppgift_DbTeknik.Entities;
using Inlämningsuppgift_DbTeknik.Models;
using Inlämningsuppgift_DbTeknik.Repositories;

namespace Inlämningsuppgift_DbTeknik.Services;

internal class ProductService
{
    private readonly ProductRepo _productRepo;
    private readonly PricingUnitRepo _pricingUnitRepo;
    private readonly ProductCategoryRepo _productCategoryRepo;

    public ProductService(ProductRepo productRepository, PricingUnitRepo pricingUnitRepo, ProductCategoryRepo productCategoryRepo)
    {
        _productRepo = productRepository;
        _pricingUnitRepo = pricingUnitRepo;
        _productCategoryRepo = productCategoryRepo;
    }

    public async Task<bool> CreateProductAsync(Products product)
    {
        if (!await _productRepo.ExistsAsync(x => x.ProductName == product.ProductName))
        {
            var pricingUnitEntity = await _pricingUnitRepo.GetAsync(x => x.Unit == product.PricingUnit);
            pricingUnitEntity ??= await _pricingUnitRepo.CreateAsync(new PricingUnitEntity { Unit = product.PricingUnit });

            var productCategoryEntity = await _productCategoryRepo.GetAsync(x => x.CategoryName == product.ProductCategory);
            productCategoryEntity ??= await _productCategoryRepo.CreateAsync(new ProductCategoryEntity { CategoryName = product.ProductCategory });

            var productEntity = await _productRepo.CreateAsync(new ProductEntity
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                PricingUnitId = pricingUnitEntity.Id,
                ProductCategoryId = productCategoryEntity.Id
            });

            if (productEntity != null)
                return true;
        }

        return false;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        var products = await _productRepo.GetAllAsync();
        return products;
    }
}
