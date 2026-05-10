using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq.Expressions;
using System.Xml.Linq;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  public class venuesController : ControllerBase
    {
        private readonly VenueServices _venueServices;

        public venuesController(VenueServices venueServices)
        { _venueServices = venueServices; }

        [HttpGet]
        public IActionResult GetAllVenues()
        {

           
            var venues =_venueServices.GetAllVenues();

            // Return all products
            return Ok(venues);
        }




   [HttpGet("{id}")]
        public ActionResult<Venue> Get(int id)
        {
            var venue = _venueServices.Get(id);
            if (venue == null)
            {
                return NotFound();

            }
            return Ok(venue);
        }


   [HttpPost]

        public IActionResult CreateVenue([FromBody] VenueModel model )
        {
            if (model == null)
                return BadRequest();


            var newVenue = _venueServices.CreateVenue(model);
            return CreatedAtAction(nameof(Get), new { id = newVenue.id }, newVenue);
        }

     


   [HttpPut("{id}")]

        public IActionResult UpDateVenue(int id, [FromBody] VenueModel venue)
        {
            if (venue == null)
                return BadRequest();
            _venueServices.UpDateVenue(id, venue);
            return NoContent();



        }



   [HttpDelete("{id}")]
        public IActionResult DEleteVenue(int id)
        {
            _venueServices.DEleteVenue(id);
            return NoContent();

        }

       


  }
   
}
