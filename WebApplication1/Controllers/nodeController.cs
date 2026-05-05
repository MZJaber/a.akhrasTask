using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Dto;
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
            var Nodes = _context.Nodes.Where(f => f.Status != RowStatus.Deleted).Select(n => new NodeDto { Id = n.Id, floor_id = n.FloorId, x = n.X, y = n.Y, Long = n.Long, lat = n.Lat}).ToList();
            return Ok(Nodes);

        }


     [HttpGet("{id}")]
        public ActionResult<Node> GetNode(int id)
        {


            var node = _context.Nodes.Where(n => n.Id == id && n.Status != RowStatus.Deleted).Select(n => new NodeDto {Id=n.Id,floor_id=n.FloorId,x=n.X,y=n.Y,Long=n.Long,lat=n.Lat }).FirstOrDefault();
            if (node == null)
            { return NotFound(); }
            return Ok(node);
        }




     [HttpPost]
        public IActionResult CreateNode([FromBody] NodeModel node)
        {
            if (node == null)
                return BadRequest();

           

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

            _context.Nodes.Add(newNode);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetNode), new { id = newNode.Id }, newNode);
        }
        
       

     [HttpPut("{id}")]
        public IActionResult UpDataNode(int id, [FromBody] NodeModel node)
        {
            if(node == null)
                return BadRequest();

            
            var exisNode = _context.Nodes.Where(n => n.Status != RowStatus.Deleted).FirstOrDefault(n => n.Id == id);

            if(exisNode == null)
                return NotFound();



            
            exisNode.FloorId = node.FloorId;
            exisNode.X = node.X;
            exisNode.Y = node.Y;
            exisNode.Long = node.Long;
            exisNode.Lat = node.Lat;
            exisNode.NodeType = node.NodeType;



            _context.SaveChanges();
            
            return NoContent();
        }



     [HttpDelete("{id}")]
        public IActionResult DEleteNode(int id)
        { 
      
        var exixNode= _context.Nodes.Where(n => n.Status != RowStatus.Deleted).FirstOrDefault(n => n.Id == id);

            if(exixNode == null)
                return NotFound();

            exixNode.IsDeleted = true;
            exixNode.Status = RowStatus.Deleted;
            _context.SaveChanges();
            return NoContent();





        }

        public class NodeModel
        {
            

            public int? FloorId { get; set; }

            public decimal? X { get; set; }

            public decimal? Y { get; set; }

            public decimal? Long { get; set; }

            public decimal? Lat { get; set; }

            public NodeType NodeType { get; set; }

            

        }


    }
}
