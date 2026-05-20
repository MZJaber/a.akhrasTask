using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Node
{
    public int Id { get; set; }

    public int? FloorId { get; set; }

    public decimal? X { get; set; }

    public decimal? Y { get; set; }

    public decimal? Long { get; set; }

    public decimal? Lat { get; set; }

    public bool? IsDeleted { get; set; }
    public NodeType NodeType { get; set; }

    public virtual Floor? Floor { get; set; }
    public RowStatus Status { get; set; }
}
