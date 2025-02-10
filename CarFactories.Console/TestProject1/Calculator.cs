namespace TestProject1
{
    internal class Calculator
    {
        private IAdder adder;

        public Calculator(IAdder adder)
        {
            this.adder = adder;
        }

        public int Add(int x, int y)
        {
            // Delegálja a feladatot
            return adder.Add(x, y);
        }

        // Pl. 2.0 -> 0.0 -> 1.0
        // pl. 2.0 -> 10.0 -> 1024.0
        // Pl. 0.0 -> 1.0 -> 0.0
        public double PowerBy(double baseValue, double powerBy)
        {
            return Math.Pow(baseValue, powerBy);
        }
    }
}
