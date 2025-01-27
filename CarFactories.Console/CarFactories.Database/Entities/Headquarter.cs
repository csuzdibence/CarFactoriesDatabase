namespace CarFactories.Database.Entities
{
    /// <summary>
    /// Ez egy főhadiszállást reprezentál
    /// </summary>
    public class Headquarter
    {
        public int Id { get; set; }

        public string Location { get; set; }

        /// <summary>
        /// Foreign Key
        /// </summary>
        public int FactoryId { get; set; }

        /// <summary>
        /// Navigációs tulajdonság - Navigation Property
        /// </summary>
        public Factory Factory { get; set; }
    }
}
