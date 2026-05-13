using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Floor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? VenueId { get; set; }

    public int? Level { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Node> Nodes { get; set; } = new List<Node>();

    public virtual Venue? Venue { get; set; }
    public RowStatus  Status { get; set; }
       
}
