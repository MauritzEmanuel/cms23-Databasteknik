using Inlämningsuppgift_DbTeknik.Entities;

namespace Inlämningsuppgift_DbTeknik.Models;

public class Products
{
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public string PricingUnit { get; set; } = null!;
    public string ProductCategory { get; set; } = null!;

}
