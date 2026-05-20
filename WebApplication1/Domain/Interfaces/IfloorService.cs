using WebApplication1.Dto;
using WebApplication1.Models;
//using static WebApplication1.Controllers.FloorController;;

namespace WebApplication1.Interfaces
{
    public interface IFloorServices
    {
        List<FloorDto> GetAllFloor();
        FloorDto GetFloor(int id);
        Floor Add(FloorModel model);
        void Delete(int id);

        void Update(int id, FloorModel model);
    }
}
