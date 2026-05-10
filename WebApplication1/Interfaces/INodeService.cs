using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Interfaces
{
    public interface INodeService
    {
        List<NodeDto> GetAllNode();
        NodeDto GetNode(int id);
        NodeDto CreateNode(NodeModel model);
        void DEleteNode (int  id);
        void UpdateNode(NodeModel model);






    }
}
