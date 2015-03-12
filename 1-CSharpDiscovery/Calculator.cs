namespace CSharpDiscovery
{
    using System.Linq;

    public class Calculator
    {
        private const double pi = 3.14;
        public Calculator()
        {
            this.Name = "Calculator";
        }

        public Calculator(string _name)
        {
            this.Name = _name;
        }

        public double Sum(double[] array)
        {
            return array[0] + array[1];
        }

        

        public string Name { get; set; }
    }
}