using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class NodeServices
    {
        private InfrastructureDbContext _db;

        public NodeServices(InfrastructureDbContext db)
        { _db = db; }

        public List<NodeDto> GetAllNode()
        {
            return _db.Nodes.Where(f => f.Status != RowStatus.Deleted).Select(n => new NodeDto { Id = n.Id, floor_id = n.FloorId, x = n.X, y = n.Y, Long = n.Long, lat = n.Lat }).ToList();

        }


        public NodeDto GetNode(int id)
        {
            return _db.Nodes.Where(n => n.Id == id && n.Status != RowStatus.Deleted).Select(n => new NodeDto { Id = n.Id, floor_id = n.FloorId, x = n.X, y = n.Y, Long = n.Long, lat = n.Lat }).FirstOrDefault();
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


            };
            _db.Nodes.Add(newNode);
            _db.SaveChanges();
            return new NodeDto { Id=newNode.Id,floor_id=newNode.FloorId,x=newNode.X,y=newNode.Y,Long=newNode.Long,lat=newNode.Lat};
        }


        public void UpdateNode(int id, NodeModel model)
        {
            var exixNode = _db.Nodes.Where(n => n.Status != RowStatus.Deleted).FirstOrDefault(n => n.Id == id);
            if (exixNode != null)
            {
                exixNode.FloorId = model.FloorId;
                exixNode.X = model.X;
                exixNode.Y = model.Y;
                exixNode.Long = model.Long;
                exixNode.Lat = model.Lat;

                _db.SaveChanges();
            }


        }

        public void DEleteNode(int id)
        {
            var node = _db.Nodes.Find(id);
            if (node != null)
            {
                node.Status = RowStatus.Deleted;
                _db.SaveChanges();


            }




        }
    }
}
