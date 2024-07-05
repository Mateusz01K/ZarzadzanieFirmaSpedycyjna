using Projekt.Models.AssignmentTruck;

namespace Projekt.Models.Trucks
{
    public class TrucksModel
    {
        public TrucksModel(){ }
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Power { get; set; }
        public int Distance { get; set; }
        public int YearOfProduction { get; set; }
        public bool IsAssignedUser { get; set; }
        public bool IsAssignedTrailer { get; set; }
        public ICollection<AssignmentModel> Assignments { get; set; }
    }
}
