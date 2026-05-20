using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Line
{
    public int Id { get; set; }

    public int? FirstNodeId { get; set; }

    public int? SecondNodeId { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsTwoWay { get; set; }
    public RowStatus Status { get; set; }
}
