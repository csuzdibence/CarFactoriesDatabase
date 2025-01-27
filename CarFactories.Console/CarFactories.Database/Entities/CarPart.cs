namespace CarFactories.Database.Entities
{
    public class CarPart
    {
        // PK
        public int Id { get; set; }

        // FK
        public int CarModelId { get; set; }

        public CarModel CarModel { get; set; }

        // FK
        public int PartId { get; set; }

        public Part Part { get; set; }
    }
}
