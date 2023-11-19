namespace Inlämningsuppgift_DbTeknik.Models;

internal class Products
{
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public int PricingUnitId { get; set; }
    public PricingUnitEntity PricingUnit { get; set; } = null!;

    public int ProductCategoryId { get; set; }
    public ProductCategoryEntity ProductCategory { get; set; } = null!;
}
