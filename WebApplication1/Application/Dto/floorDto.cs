
using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class FloorDto
    {

        public int id { get; set; }
        public  string? Name { get; set; }
        public int? Level { get; set; }
        public int? VenueId { get; set; }
        
       
        public FloorDto(Floor f) {
            id = f.Id; Name = f.Name; Level = f.Level; VenueId = f.VenueId;



        }
    }
}
