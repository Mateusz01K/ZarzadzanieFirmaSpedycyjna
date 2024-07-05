namespace Projekt.Models.Trailer
{
    public class TrailerModel
    {
        public TrailerModel() { }
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int MaxLoad { get; set; }
        public int YearOfProduction { get; set; }
        public bool IsAssigned { get; set; }
    }
}
