using WebApplication1.Dto;
using WebApplication1.Models;


namespace WebApplication1.Interfaces
{
    public interface ILineServices
    {
        List<LineDto> GetAllLine();
        LineDto Get(int id);
        LineDto AddLine(LineModel model);
        void DeleteLine(int id);

        void UpdateLine(int id, LineModel model);
    }
}
