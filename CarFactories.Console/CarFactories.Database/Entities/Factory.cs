namespace CarFactories.Database.Entities
{
    /// <summary>
    /// Ez egy autó gyárat reprezentál
    /// </summary>
    public class Factory
    {
        public int Id { get; set; }

        /// <summary>
        /// Példa: Tesla, Ford
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 1-1 navigációs tulajdonság
        /// </summary>
        public Headquarter Headquarter { get; set; }

        /// <summary>
        /// 1-N navigációs tulajdonság
        /// </summary>
        public List<CarModel> CarModels { get; set; } = new List<CarModel>();
    }
}
