﻿using System.ComponentModel.DataAnnotations;

namespace Inlämningsuppgift_DbTeknik.Entities;

public class PricingUnitEntity
{
    public int Id { get; set; }
    public string Unit { get; set; } = null!;
}