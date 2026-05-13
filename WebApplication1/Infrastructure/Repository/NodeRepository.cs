using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class NodeRepository
    {
        private InfrastructureDbContext _db;


        public NodeRepository(InfrastructureDbContext db)
        {  _db = db; }


        public List<Node> GetAllNode()
        {

            return _db.Nodes.Where(n => n.Status != RowStatus.Deleted).ToList();
        }
        public Node GetNode(int id) 
        {
            return _db.Nodes.Where(n => n.Id == id && n.Status != RowStatus.Deleted).FirstOrDefault();


        }


        public void Add(Node node)
        {
            _db.Nodes.Add(node);
            _db.SaveChanges();
        }


        public void Delete(Node nodeob)
        {

            _db.Nodes.Update(nodeob);
            _db.SaveChanges();

        }


        public void Update(Node node)
        {
            _db.SaveChanges();
        }

    }
}
