using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IVeneuService
    {
        List<VenueDto> GetAllVenues();
        VenueDto Get(int id);
        VenueDto CreateVenue(VenueModel model);
        void DEleteVenue(int id);
        void UpDateVenue(VenueModel model);
        Task <Venue>GetVenueAsync(int id);
    }
}
