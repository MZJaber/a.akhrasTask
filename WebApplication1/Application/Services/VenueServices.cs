using System;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class VenueServices
    {
        private readonly VenueRepository _venueRepo;

        public VenueServices(VenueRepository venueRepo)
        { _venueRepo = venueRepo; }



        public List<VenueDto> GetAllVenues()
        {
            return _venueRepo.GetAllVenues().Select(v => new VenueDto (v)).ToList();
        }


        public VenueDto get(int id)
        {
            var v = _venueRepo.get(id);

            return new VenueDto(v);
        }




        public VenueDto CreateVenue(VenueModel model)
        {
            var newVenue = new Venue
            {
               Name = model.Name,


            };
            _venueRepo.Add(newVenue);
           

            return new VenueDto (newVenue);
        }




        public void UpDateVenue(int id, VenueModel model)
        {
            var exisVenue = _venueRepo.get(id);
            if (exisVenue != null)
            {
                exisVenue.Name =model.Name; ;
                exisVenue.Status = RowStatus.Updated;
                
            }


        }
        public void DEleteVenue(int id)
        {
            var venue = _venueRepo.get(id);
            if (venue != null)
            {
                venue.Status = RowStatus.Deleted;
                


            }


        }



    }
}
