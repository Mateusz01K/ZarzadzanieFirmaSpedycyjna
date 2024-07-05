using Microsoft.IdentityModel.Tokens;
using Projekt.Context;
using Projekt.Models.Trailer;

namespace Projekt.Services.Trailer
{
    public class TrailerService : ITrailerService
    {
        public readonly TruckContext _context;

        public TrailerService(TruckContext context)
        {
            _context = context;
        }

        public void DeleteTrailer(int id)
        {
            var trailer = _context.Trailers.FirstOrDefault(x => x.Id == id);
            if (trailer != null)
            {
                _context.Trailers.Remove(trailer);
                _context.SaveChangesAsync();
            }
        }

        public List<TrailerModel> GetTrailer()
        {
            return _context.Trailers.ToList();
        }

        public TrailerModel GetTrailer(int id)
        {
            var trailer = _context.Trailers.FirstOrDefault(x => x.Id == id);
            return trailer ?? new TrailerModel();
        }

        public void InsertTrailer(string Model, string Brand, string Type, int MaxLoad, int YearOfProduction)
        {
            var lastId = _context.Trailers.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            if (lastId != null)
            {
                _context.Trailers.Add(new TrailerModel()
                {
                    Id = (int)lastId + 1,
                    Model = Model,
                    Brand = Brand,
                    Type = Type,
                    MaxLoad = MaxLoad,
                    YearOfProduction = YearOfProduction
                });
                _context.SaveChanges();
            }
        }

        public void UpdateTrailer(int id, string Model, string Brand, string Type, int MaxLoad, int YearOfProduction)
        {
            var trailer = _context.Trailers.FirstOrDefault(x => x.Id == id);
            if (trailer != null)
            {
                trailer.Model = Model;
                trailer.Brand = Brand;
                trailer.Type = Type;
                trailer.MaxLoad = MaxLoad;
                trailer.YearOfProduction = YearOfProduction;
                _context.SaveChanges();
            }
        }
    }
}
