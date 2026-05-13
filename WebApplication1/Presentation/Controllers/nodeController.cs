using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class nodeController : Controller
    {
        private readonly NodeServices _nodeService;

        public nodeController(NodeServices nodeService)
        {
            _nodeService = nodeService;
        }

     [HttpGet]
        public IActionResult GetAllNode()
        {
            var Nodes = _nodeService.GetAllNode();
            return Ok(Nodes);

        }


     [HttpGet("{id}")]
        public ActionResult<Node> GetNode(int id)
        {


            var node = _nodeService.GetNode( id);
            if (node == null)
            { return NotFound(); }
            return Ok(node);
        }




        [HttpPost]
        public IActionResult CreateNode([FromBody] NodeModel model)
        {
            if (model == null)
                return BadRequest();

            
            var newNode = _nodeService.CreateNode(model);
            return CreatedAtAction(nameof(GetNode), new { id = newNode.Id }, newNode);

        }



        [HttpPut("{id}")]

        public IActionResult UpdateNode(int id, [FromBody] NodeModel node)
        {
            if (node == null)
                return BadRequest();
            _nodeService.UpdateNode(id,node);
            return NoContent();

        }



        [HttpDelete("{id}")]
        public IActionResult DeleteNode(int id)
        {
            _nodeService.DEleteNode(id);
            return NoContent();

        }


    }
}
