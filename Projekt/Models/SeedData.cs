using Microsoft.EntityFrameworkCore;
using Projekt.Context;
using Projekt.Models.Trucks;
using Projekt.Models.AssignmentTruck;
using Projekt.Models.Users;
using Projekt.Models.Trailer;
using Projekt.Models.AssignTrailerToTruck;

namespace Projekt.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TruckContext(serviceProvider.GetRequiredService<DbContextOptions<TruckContext>>()))
            {
                if (context.Trucks.Any())
                {
                    return;
                }
                context.Trucks.AddRange(
                    new TrucksModel()
                    {
                        Id = 1,
                        Model = "Euro 6",
                        Brand = "Scania",
                        Power = 1500,
                        Distance = 1000000,
                        YearOfProduction = 2020,
                        IsAssignedUser = false,
                    },
                    new TrucksModel()
                    {
                        Id = 2,
                        Model = "Euro 5",
                        Brand = "Volvo",
                        Power = 2000,
                        Distance = 200000,
                        YearOfProduction = 2021,
                        IsAssignedUser = false,
                    },
                    new TrucksModel()
                    {
                        Id = 3,
                        Model = "Euro 7",
                        Brand = "Scania",
                        Power = 1000,
                        Distance = 10000,
                        YearOfProduction = 2023,
                        IsAssignedUser = true,
                    }
                );
                context.SaveChanges();
            }

            //Users

            using (var context = new TruckContext(serviceProvider.GetRequiredService<DbContextOptions<TruckContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }
                context.Users.AddRange(
                    new UserModel()
                    {
                        Id = 1,
                        FirstName = "Jan",
                        LastName = "Kowlaski",
                        Email = "jankowlaski@test.pl",
                        IsAssignedTruck = false
                    }
                );
                context.SaveChanges();
            }

            //Assignments

            using (var context = new TruckContext(serviceProvider.GetRequiredService<DbContextOptions<TruckContext>>()))
            {
                if (context.Assignments.Any())
                {
                    return;
                }
                context.Assignments.AddRange(
                new AssignmentModel()
                {
                    Id = 1,
                    TruckId = 1,
                    UserId = 1,
                    AssignmentDate = new DateTime(2022, 12, 1),
                    ReturnDate = new DateTime(2022, 12, 8),
                    IsReturned = true
                },
                new AssignmentModel()
                {
                    Id = 2,
                    TruckId = 2,
                    UserId = 1,
                    AssignmentDate = new DateTime(2022, 12, 15),
                    ReturnDate = new DateTime(2022, 12, 22),
                    IsReturned = true
                },
                new AssignmentModel()
                {
                    Id = 3,
                    TruckId = 3,
                    UserId = 1,
                    AssignmentDate = new DateTime(2022, 12, 29),
                    ReturnDate = new DateTime(2023, 1, 5),
                    IsReturned = false
                }
                );
                context.SaveChanges();
            }



            //Trailers

            using (var context = new TruckContext(serviceProvider.GetRequiredService<DbContextOptions<TruckContext>>()))
            {
                if (context.Trailers.Any())
                {
                    return;
                }
                context.Trailers.AddRange(
                new TrailerModel()
                {
                    Id = 1,
                    Model = "N10",
                    Brand = "Volvo",
                    Type = "Cysterna",
                    MaxLoad = 20000,
                    YearOfProduction = 2020
                },
                new TrailerModel()
                {
                    Id = 2,
                    Model = "N1",
                    Brand = "Scania",
                    Type = "Wywrotka",
                    MaxLoad = 20000,
                    YearOfProduction = 2022
                },
                new TrailerModel()
                {
                    Id = 3,
                    Model = "N2",
                    Brand = "Volvo",
                    Type = "Firanka",
                    MaxLoad = 20000,
                    YearOfProduction = 2023
                }
                );
                context.SaveChanges();
            }

            //AssignmentTrailers

            using (var context = new TruckContext(serviceProvider.GetRequiredService<DbContextOptions<TruckContext>>()))
            {
                if (context.AssignmentTrailers.Any())
                {
                    return;
                }
                context.AssignmentTrailers.AddRange(
                new AssignTrailerToTruckModel()
                {
                    Id = 1,
                    TruckId = 1,
                    TrailerId = 1,
                    AssignmentDate = new DateTime(2022, 12, 1),
                    ReturnDate = new DateTime(2022, 12, 8),
                    IsReturned = true
                },
                new AssignTrailerToTruckModel()
                {
                    Id = 2,
                    TruckId = 2,
                    TrailerId = 1,
                    AssignmentDate = new DateTime(2022, 12, 15),
                    ReturnDate = new DateTime(2022, 12, 22),
                    IsReturned = true
                },
                new AssignTrailerToTruckModel()
                {
                    Id = 3,
                    TruckId = 3,
                    TrailerId = 1,
                    AssignmentDate = new DateTime(2022, 12, 29),
                    ReturnDate = new DateTime(2023, 1, 5),
                    IsReturned = false
                }
                );
                context.SaveChanges();
            }
        }
    }
}
