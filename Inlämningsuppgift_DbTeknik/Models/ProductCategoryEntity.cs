using System.ComponentModel.DataAnnotations;

namespace Inlämningsuppgift_DbTeknik.Models;

public class ProductCategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
}