using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class nodeController : Controller
    {
        private InfrastructureDbContext _context;

        public nodeController([FromServices] InfrastructureDbContext context)
        {
            _context = context;
        }

     [HttpGet]
        public IActionResult GetAllNode()
        {
            var nodedb = new InfrastructureDbContext();
            var Nodes = nodedb.Nodes.Where(f => f.Status != RowStatus.Deleted).ToList();
            return Ok(Nodes);

        }


     [HttpGet("{id}")]
        public ActionResult<Node> GetNode(int id)
        {


            var node = _context.Nodes.Where(n => n.Id == id && n.Status != RowStatus.Deleted).FirstOrDefault();
            if (node == null)
            { return NotFound(); }
            return node;
        }




     [HttpPost]
        public IActionResult CreateNode([FromBody] NodeModel node)
        {
            if (node == null)
                return BadRequest();

            var noddb = new InfrastructureDbContext();

            var newNode = new Node()
            {
                FloorId = node.FloorId ?? 0,
                X = node.X ,
                Y = node.Y,
                Long = node.Long ,
                Lat = node.Lat ,
                NodeType = node.NodeType,
                IsDeleted = false
            };

            noddb.Nodes.Add(newNode);
            noddb.SaveChanges();

            return Ok(new { id = newNode.Id });
        }
       

     [HttpPut("{id}")]
        public IActionResult UpDataNode([FromBody] NodeModel node)
        {
            if(node == null)
                return BadRequest();

            var noddb = new InfrastructureDbContext();
            var exisNode = noddb.Nodes.Where(n => n.Status != RowStatus.Deleted).FirstOrDefault(n => n.Id == node.Id);

            if(exisNode == null)
                return NotFound();



            exisNode.Id = node.Id;
            exisNode.FloorId = node.FloorId;
            exisNode.X = node.X;
            exisNode.Y = node.Y;
            exisNode.Long = node.Long;
            exisNode.Lat = node.Lat;
            exisNode.IsDeleted = node.IsDeleted;
            exisNode.Status = RowStatus.Updated;

            noddb.SaveChanges();
            return Ok(exisNode);
        }



     [HttpDelete("{id}")]
        public IActionResult DEleteNode(int id)
        { 
        var noddb = new InfrastructureDbContext();
        var exixNode= noddb.Nodes.Where(n => n.Status != RowStatus.Deleted).FirstOrDefault(n => n.Id == id);

            if(exixNode == null)
                return NotFound();

            exixNode.IsDeleted = true;
            exixNode.Status = RowStatus.Deleted;
            noddb.SaveChanges();
            return Ok();



        
        
        }

        public class NodeModel
        {
            public int Id { get; set; }
            public int? FloorId { get; set; }

            public decimal? X { get; set; }

            public decimal? Y { get; set; }

            public decimal? Long { get; set; }

            public decimal? Lat { get; set; }

            public NodeType NodeType { get; set; }

            public bool? IsDeleted { get; set; }

        }


    }
}
