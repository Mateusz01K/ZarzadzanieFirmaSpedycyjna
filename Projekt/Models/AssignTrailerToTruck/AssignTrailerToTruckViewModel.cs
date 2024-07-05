using Projekt.Models.Trailer;
using Projekt.Models.Trucks;

namespace Projekt.Models.AssignTrailerToTruck
{
    public class AssignTrailerToTruckViewModel
    {
        public AssignTrailerToTruckViewModel()
        {

        }

        public List<AssignTrailerToTruckModel> AssignmentTrailers { get; set; }
        public List<TrucksModel> Trucks { get; internal set; }
        public List<TrailerModel> Trailers { get; internal set; }
    }
}
