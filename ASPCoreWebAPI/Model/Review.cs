using System;
using System.Collections.Generic;

namespace ASPCoreWebAPI.Model;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? ProductId { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public int? Rating { get; set; }

    public virtual Product? Product { get; set; }
}
