using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift_DbTeknik.Entities;

internal class ProductEntity
{
    [Key]
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public string PricingUnit { get; set; } = null!;
    public string ProductCategory { get; set; } = null!;
}
