using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class VenueDto
    {
        public int? id { get; set; }
        public string? name { get; set; }


        public VenueDto(Venue v) 
        {
            id = v.Id; name = v.Name;


        }
        public List<FloorDto> Floors { get; set; } = new List<FloorDto>();

    }
}
