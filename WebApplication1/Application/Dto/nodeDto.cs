using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class NodeDto
    {
        public int Id { get; set; }
        public int? floor_id { get; set; }
        public decimal? x { get; set; }
        public decimal? y { get; set; }

        public decimal? Long   { get; set;}
       
        public decimal? lat { get; set; }



        public NodeDto(Node n) 
        
        {

            Id = n.Id; floor_id = n.FloorId; x = n.X; y = n.Y; Long = n.Long; lat = n.Lat;


        }
    }
}
