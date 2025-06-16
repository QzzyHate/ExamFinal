using System;
using System.Collections.Generic;

namespace Exam.Models;

public partial class MaterialType
{
    public int Id { get; set; }

    public string MaterialName { get; set; } = null!;

    public decimal DefectPercentage { get; set; }
}
