using System.Drawing;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class NodeServices
    {
        private NodeRepository _nodeRepo;

        public NodeServices(NodeRepository nodeRepo)
        { _nodeRepo = nodeRepo; }

        public List<NodeDto> GetAllNode()
        {
            return _nodeRepo.GetAllNode().Select(n => new NodeDto (n)).ToList();

        }


        public NodeDto GetNode(int id)
        {
            var n = _nodeRepo.GetNode(id);
               return    new NodeDto (n);
        }


        public NodeDto CreateNode(NodeModel model)
        {
            var newNode = new Node
            {
                FloorId = model.FloorId,
                X = model.X,
                Y = model.Y,
                Long = model.Long,
                Lat = model.Lat,
                Status = RowStatus.New


            };
            _nodeRepo.Add(newNode);
            
            return new (newNode);
        }


        public void UpdateNode(int id, NodeModel model)
        {
            var exixNode = _nodeRepo.GetNode(id);
            if (exixNode != null)
            {
                exixNode.FloorId = model.FloorId;
                exixNode.X = model.X;
                exixNode.Y = model.Y;
                exixNode.Long = model.Long;
                exixNode.Lat = model.Lat;

                _nodeRepo.Update(exixNode);
            }


        }

        public void DEleteNode(int id)
        {
            var node = _nodeRepo.GetNode(id);
            if (node != null)
            {
                node.Status = RowStatus.Deleted;

                _nodeRepo.Delete(node);

            }




        }
    }
}
