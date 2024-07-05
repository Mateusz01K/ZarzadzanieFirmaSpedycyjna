using Microsoft.EntityFrameworkCore;
using Projekt.Models.Trucks;
using Projekt.Models.AssignmentTruck;
using Projekt.Models.Users;
using Projekt.Models.Trailer;
using Projekt.Models.AssignTrailerToTruck;

namespace Projekt.Context
{
    public class TruckContext : DbContext
    {
        public TruckContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TrucksModel> Trucks { get; set; }
        public DbSet<TrailerModel> Trailers { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AssignmentModel> Assignments { get; set; }
        public DbSet<AssignTrailerToTruckModel> AssignmentTrailers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
