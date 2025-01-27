using CarFactories.Database;
using CarFactories.Database.Entities;

CarFactoriesDbContext context = new CarFactoriesDbContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

// Database Seeding - Inicializáló adatok megadása az adatbázisban

Part part = new Part()
{
    Name = "Golyóálló ablak"
};
Part part2 = new Part()
{
    Name = "Sebességváltó"
};

Factory teslaFactory = new Factory()
{
    Name = "Tesla",
    Headquarter = new Headquarter()
    {
        Location = "Palo Alto, CA"
    },
    CarModels = new List<CarModel>()
    {
        new CarModel()
        {
            Name = "Model S Plaid"
        },
        new CarModel()
        {
            Name = "Model X"
        },
        new CarModel()
        {
            Name = "Cybertruck",
        }
    }
};
Console.WriteLine("Tesla gyár feltöltés.");

Factory fordFactory = new Factory()
{
    Name = "Ford",
    Headquarter = new Headquarter()
    {
        Location = "Detroit, MI",
    },
    CarModels = new List<CarModel>()
    {
        new CarModel()
        {
            Name = "Focus"
        },
        new CarModel()
        {
            Name = "Mustang"
        },
        new CarModel()
        {
            Name = "F150 Raptor"
        }
    }
};
Console.WriteLine("Ford gyár feltöltés.");

context.Factories.Add(teslaFactory);
context.Factories.Add(fordFactory);
context.SaveChanges();
;