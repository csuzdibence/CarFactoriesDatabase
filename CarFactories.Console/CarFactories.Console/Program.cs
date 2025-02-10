using CarFactories.Database;
using CarFactories.Database.Entities;
using Microsoft.EntityFrameworkCore.Storage;

CarFactoriesDbContext context = new CarFactoriesDbContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

// Database Seeding - Inicializáló adatok megadása az adatbázisban

Part bulletProofWindow = new Part()
{
    Name = "Golyóálló ablak"
};
Part transmission = new Part()
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
            CarParts = new List<CarPart>()
            {
                new CarPart()
                {
                    Part = bulletProofWindow,
                },
                new CarPart()
                {
                    Part = transmission,
                }
            }
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
            Name = "Mustang",
            CarParts = new List<CarPart>()
            {
                new CarPart()
                {
                    Part = transmission,
                }
            }
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

// Írjuk ki a Tesla gyárban készített autómodellek nevét
// SELECT * FROM Factories WHERE Name = "Tesla" -> Tesla gyár kiválasztása
Factory? factory = context.Factories.FirstOrDefault(factory => factory.Name == "Tesla");
IEnumerable<string> modelNames = factory.CarModels.Select(x => x.Name);
foreach (var modelName in modelNames)
{
    Console.WriteLine();
    Console.WriteLine(modelName);
}

// Tesla Cybetruck összes alaktrészének a nevét írjuk ki.
CarModel? carModel = context.CarModels.FirstOrDefault(carModel => carModel.Name == "Cybertruck");
var partNames = carModel.CarParts.Select(carPart => carPart.Part.Name).OrderByDescending(x => x);
foreach (var partName in partNames)
{
    Console.WriteLine();
    Console.WriteLine(partName);
}
;