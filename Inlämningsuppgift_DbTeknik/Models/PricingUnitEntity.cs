using System.ComponentModel.DataAnnotations;

namespace Inlämningsuppgift_DbTeknik.Models;

public class PricingUnitEntity
{
    public int Id { get; set; }
    public string Unit { get ; set; } = null!;
}