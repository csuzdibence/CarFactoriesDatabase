using Moq;

namespace TestProject1
{
    // Minden teszt osztály -> egy konkrét osztályt tesztel.

    // AAA -> rövidítés (Arrange, Act, Assert)
    // Arrange -> Objektum inicializálása
    // Act -> Cselekvés/ Metódus hívás
    // Assert -> Validálás/Meggyõzõdés
    public class CalculatorTests
    {
        private Calculator calculator;
        private Mock<IAdder> adderMock;

        /// <summary>
        /// Minden teszt futása elõtt lefut (N-szer).
        /// </summary>
        [SetUp]
        public void Setup()
        {
            adderMock = new Mock<IAdder>();
            calculator = new Calculator(adderMock.Object);
        }

        /// <summary>
        /// Csak ekkor fog futni a unit teszt, tehát megjelöljük tesztként
        /// </summary>
        [TestCase(1, 1, 2)]
        [TestCase(10, 20, 30)]
        [TestCase(0, 0, 0)]
        [TestCase(2001, 1245, 3246)]
        public void AddingANumberToAnotherAddsThemRight(int x, int y, int sum)
        {
            // mockolás
            adderMock.Setup(adder => adder.Add(x, y)).Returns(sum);

            // Act
            int addResult = calculator.Add(x, y);

            adderMock.Verify(adder => adder.Add(x, y), Times.Once);

            // Assert
            Assert.AreEqual(sum, addResult);
        }

        [TestCase(2.0, 0.0, 1.0)]
        [TestCase(2.0, 10.0, 1024.0)]
        [TestCase(0.0, 1.0, 0.0)]
        public void PoweringANumberToAnotherPowersThemRight(double x, double y, double powerResult)
        {
            // Act
            double addResult = calculator.PowerBy(x, y);
            // Assert
            Assert.AreEqual(addResult, powerResult);
        }

        [Test]
        public void AddingMinusFiftyToFortyReturnsMinusTen()
        {
            adderMock.Setup(adder => adder.Add(-50, 40)).Returns(-10);
            // Act
            int addResult = calculator.Add(-50, 40);
            // Assert
            Assert.AreEqual(addResult, -10);
        }
    }
}