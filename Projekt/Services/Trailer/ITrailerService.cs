using Projekt.Models.Trailer;

namespace Projekt.Services.Trailer
{
    public interface ITrailerService
    {
        public List<TrailerModel> GetTrailer();
        public TrailerModel GetTrailer(int id);
        public void InsertTrailer(string Model, string Brand, string Type, int MaxLoad, int YearOfProduction);
        public void UpdateTrailer(int id, string Model, string Brand, string Type, int MaxLoad, int YearOfProduction);
        public void DeleteTrailer(int id);
    }
}
