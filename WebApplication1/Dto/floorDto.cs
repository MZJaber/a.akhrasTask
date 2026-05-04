
namespace WebApplication1.Dto
{
    public class FloorDto
    {

        public int id { get; set; }
        public  string? Name { get; set; }
        public int? Level { get; set; }
        public int? VenueId { get; set; }

        internal object FirstOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}
