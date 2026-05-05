using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class lineController : Controller
    {


     [HttpGet]
        public IActionResult GetAllLine()
        {
            var lindb = new InfrastructureDbContext();
            var lins = lindb.Lines.Where(l => l.Status != RowStatus.Deleted).Select(l => new LineDto { id = l.Id, first_node_id = l.FirstNodeId, second_node_id=l.SecondNodeId, is_two_way=l.IsTwoWay });
            return Ok(lins);
        }

     [HttpGet("{id}")]
        public ActionResult<Line> Get(int id)
        {
            var lidb = new InfrastructureDbContext();
            var lineId = lidb.Lines.Where(l => l.Id == id && l.Status != RowStatus.Deleted).Select(l => new LineDto { id = l.Id, first_node_id = l.FirstNodeId, second_node_id = l.SecondNodeId, is_two_way = l.IsTwoWay }).FirstOrDefault();
            if (lineId == null)
            {
                return NotFound();
            }
            return Ok(lineId);
        }





     [HttpPost]
        public IActionResult CreateLine([FromBody] LineModel line)
        {
            if (line == null)
                return BadRequest();

            var lindb = new InfrastructureDbContext();

            var newLine = new Line()
            {
                FirstNodeId = line.FirstNodeId ?? 0,
                SecondNodeId = line.SecondNodeId ?? 0,
                IsTwoWay = line.IsTwoWay,
                IsDeleted = false,
                Status=RowStatus.New
            };

            lindb.Lines.Add(newLine);
            lindb.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = newLine.Id }, newLine);
        }
       

     [HttpPut ("{id}")]
        public IActionResult UpDateLine(int id, [FromBody] LineModel line)
        { 
         if(line == null)
                return BadRequest();

         var lindb = new InfrastructureDbContext();
         var exisLine = lindb.Lines.Where(l => l.Status != RowStatus.Deleted).FirstOrDefault(l => l.Id == id);


            if(exisLine == null)
                return NotFound();



            //exisLine.Id = (int)line.Id;
            exisLine.FirstNodeId = line.FirstNodeId;
            exisLine.SecondNodeId = line.SecondNodeId;
            exisLine.Status = RowStatus.Updated;
           
            lindb.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLine(int id)
        { 
        var lindb = new InfrastructureDbContext();
        var exixLine=lindb.Lines.Where(l => l.Status != RowStatus.Deleted).FirstOrDefault(l => l.Id == id);

            if(exixLine == null)
                return NotFound();
            
            exixLine.IsDeleted = true;
            exixLine.Status = RowStatus.Deleted;
            lindb.SaveChanges();


            return NoContent();




        }


        public class LineModel
        {
           

            public int? FirstNodeId { get; set; }

            public int? SecondNodeId { get; set; }

            public bool? IsTwoWay { get; set; }
            
            
        }


    }
}
