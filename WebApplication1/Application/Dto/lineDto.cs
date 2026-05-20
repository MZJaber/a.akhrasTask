using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class LineDto
    {


        public int? id { get; set; }
        public int? first_node_id { get; set; }
        public int? second_node_id { get; set; }
        public bool? is_two_way { get; set; }

        public LineDto(Line l) {
            id = l.Id; first_node_id = l.FirstNodeId; second_node_id = l.SecondNodeId; is_two_way = l.IsTwoWay; 


        }
    
        

    }
}
