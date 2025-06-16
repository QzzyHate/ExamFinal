using System;
using System.Collections.Generic;

namespace Exam.Models;

public partial class Partner
{
    public int Id { get; set; }

    public string? PartnerType { get; set; }

    public string PartnerName { get; set; } = null!;

    public string? Director { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Inn { get; set; }

    public int? Rating { get; set; }

    public virtual ICollection<PartnerOrder> PartnerOrders { get; set; } = new List<PartnerOrder>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
