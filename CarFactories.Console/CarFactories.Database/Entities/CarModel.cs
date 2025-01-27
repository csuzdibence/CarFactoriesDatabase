namespace CarFactories.Database.Entities
{
    public class CarModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Pl. Model S, F150 Raptor
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// FK
        /// </summary>
        public int FactoryId { get; set; }

        public Factory Factory { get; set; }

        // N-N-hez kapcsolat miatt
        public List<CarPart> CarParts { get; set; } = new List<CarPart>();
    }
}
