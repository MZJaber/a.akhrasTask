using Microsoft.AspNetCore.Mvc;
using System;
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
            var lins = lindb.Lines.Where(f => f.Status != RowStatus.Deleted).ToList();
            return Ok(lins);
        }

     [HttpGet("{id}")]
        public ActionResult<Line> Get(int id)
        {
            var lidb = new InfrastructureDbContext();
            var lineId = lidb.Lines.Where(l => l.Id == id && l.Status != RowStatus.Deleted).FirstOrDefault();
            if (lineId == null)
            {
                return NotFound();
            }
            return lineId;
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

            return Ok(new { id = newLine.Id });
        }
       

     [HttpPut ("{id}")]
        public IActionResult UpDateLine([FromBody] LineModel line)
        { 
         if(line == null)
                return BadRequest();

         var lindb = new InfrastructureDbContext();
         var exisLine = lindb.Lines.Where(l => l.Status != RowStatus.Deleted).FirstOrDefault(l => l.Id == line.Id);


            if(exisLine == null)
                return NotFound();



            //exisLine.Id = (int)line.Id;
            exisLine.FirstNodeId = line.FirstNodeId;
            exisLine.SecondNodeId = line.SecondNodeId;
            exisLine.Status = RowStatus.Updated;
           
            lindb.SaveChanges();

            return Ok();

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


            return Ok() ;
        
        
        
        
        }


        public class LineModel
        {
            public int? Id { get; set; }
            public int? FirstNodeId { get; set; }

            public int? SecondNodeId { get; set; }

            public bool? IsTwoWay { get; set; }
            
            
        }


    }
}
