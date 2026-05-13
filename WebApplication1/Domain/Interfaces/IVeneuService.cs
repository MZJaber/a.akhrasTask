using WebApplication1.Dto;

namespace WebApplication1.Interfaces
{
    public interface IVeneuService
    {
        List<VenueDto> GetAllVenues();
        VenueDto Get(int id);
        VenueDto CreateVenue(VenueModel model);
        void DEleteVenue(int id);
        void UpDateVenue(VenueModel model);

    }
}
