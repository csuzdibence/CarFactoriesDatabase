namespace CarFactories.Database.Entities
{
    /// <summary>
    /// Egy autó alkatrész típust jelöl
    /// </summary>
    public class Part
    {
        public int Id { get; set; }
        
        
        // Konkrét alkatrész típus pl. V12 Motor, Elektromos motor, Váltó, Golyóálló ablak 
        public string Name{ get; set; }

        // N-N-hez kapcsolat miatt
        public List<CarPart> CarParts { get; set; } = new List<CarPart>();
    }
}
