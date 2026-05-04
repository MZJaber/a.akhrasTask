using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Venue
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Floor> Floors { get; set; } = new List<Floor>();
    public RowStatus Status { get; set; }
}
