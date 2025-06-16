using System;
using System.Collections.Generic;

namespace Exam.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductsName { get; set; } = null!;

    public int? ProductTypeId { get; set; }

    public string? ArticleNumber { get; set; }

    public decimal? MinPrice { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual ProductType? ProductType { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
