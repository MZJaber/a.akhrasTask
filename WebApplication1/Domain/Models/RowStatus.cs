
using NpgsqlTypes;

namespace WebApplication1.Models;


public enum RowStatus
{
    [PgName("New")]
    New,
    [PgName("Updated")]
    Updated,
    [PgName("Deleted")]
    Deleted,


}
