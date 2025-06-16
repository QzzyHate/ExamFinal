using System;
using System.Collections.Generic;

namespace Exam.Models;

public partial class ProductType
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Coefficient { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
