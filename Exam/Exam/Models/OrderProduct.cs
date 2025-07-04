﻿using System;
using System.Collections.Generic;

namespace Exam.Models;

public partial class OrderProduct
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quality { get; set; }

    public virtual PartnerOrder Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
