using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq.Expressions;
using System.Xml.Linq;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class venuesController : ControllerBase
    {
        private readonly VenueServices _venueServices;
        private readonly VenueRepository _venueRepository;

        public venuesController(VenueServices venueServices, VenueRepository venueRepository)
        { 
            _venueServices = venueServices; 
            _venueRepository = venueRepository;
        }

        [HttpGet]
        public IActionResult GetAllVenues()
        {


            var venues = _venueServices.GetAllVenues();

            // Return all products
            return Ok(venues);
        }




        [HttpGet("{id}")]
        public ActionResult<Venue> get(int id)
        {
            var venue = _venueServices.get(id);
            if (venue == null)
            {
                return NotFound();

            }
            return Ok(venue);
        }

        [HttpGet("{id}/with-floors")]
        public async Task<IActionResult> GetVenueWithFloors(int id)
        {
            var venue = await _venueRepository.GetVenueAsync(id);
            if (venue == null)
            {
                return NotFound();
            }
            var resultDto = new VenueDto(venue )
            {
              

                Floors = venue.Floors.Select(f => new FloorDto(f)).ToList()


            };
            return Ok(resultDto);
        }

   [HttpPost]

        public IActionResult CreateVenue([FromBody] VenueModel model )
        {
            if (model == null)
                return BadRequest();


            var newVenue = _venueServices.CreateVenue(model);
            return CreatedAtAction(nameof(get), new { id = newVenue.id }, newVenue);
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
