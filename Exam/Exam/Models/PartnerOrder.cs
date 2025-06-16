using System;
using System.Collections.Generic;

namespace Exam.Models;

public partial class PartnerOrder
{
    public int Id { get; set; }

    public int PartnerId { get; set; }

    public decimal? TotalCost { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Partner Partner { get; set; } = null!;
}
