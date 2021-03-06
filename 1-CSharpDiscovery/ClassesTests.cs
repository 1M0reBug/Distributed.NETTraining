﻿using System.Linq;
using NFluent;
using NUnit.Framework;

namespace CSharpDiscovery
{

    public class Calculator
    {
        private const double pi = 3.14;
        public Calculator()
        {
            Name = "Calculator";
        }

        public Calculator(string _name)
        {
            Name = _name;
        }

        public double Sum(double[] array)
        {
            return array[0] + array[1];
        }

        public double Sum(string operation)
        {
            var numbers = operation.Split('+').Select(s => 2);
            for (int i = 0; i < numbers.Length; i++ )
            {
                if (numbers[i].Trim().Equals("pi"))
                    numbers[i] = pi.ToString();
            }
            return (double.Parse(numbers[0].Trim()) + double.Parse(numbers[1].Trim()));
        }

        public string Name { get; set; }
    }
    [TestFixture]
    public class ClassesTests
    {
        [Test]
        public void CreateACalculatorClassWithADefaultConstructorAndInstanciate()
        {
            Calculator calculator = new Calculator();
            Check.That(calculator).IsNotNull();
        }

        [Test]
        public void AddAnotherConstructorWithAFriendlyNameAndInstanciate()
        {
            Calculator calculator = new Calculator("_Calculator");
            // use a public member for Name for now, i.e public string Name;
            Check.That(calculator.Name).Equals("_Calculator");
        }

        [Test]
        public void AddAMethodThatMakeASumOfAnArrayOfDouble()
        {
            Calculator calculator = new Calculator();
            var valuesToSum = new[] { 1.3, 1.7 };
            double sumOfTheArray = calculator.Sum(valuesToSum);
            // add a method Sum to calculator class
            Check.That(sumOfTheArray).Equals(3.0);
        }

        [Test]
        public void AddAMethodOverloadThatMakeASumOfTwoDoubleFromStringRepresentation()
        {
            var sumOfTwoDoubleFromString = "1,0+2";
            // add a method with the same name that uses the previous method
            // tips : use string.Split
            var calculator = new Calculator();
            var onePlusTwo = calculator.Sum(sumOfTwoDoubleFromString);

            Check.That(onePlusTwo).Equals(3.0);
        }

        [Test]
        public void AddAGetterForNameInsteadOfPublicNameMember()
        {
            var calculator = new Calculator();
            Check.That(calculator.Name).Equals("Calculator");
        }

        [Test]
        public void AddASetterForNameAndChangeNameWithIt()
        {
            var calculator = new Calculator();
            calculator.Name = "Enhanced Calculator";
            Check.That(calculator.Name).Equals("Enhanced Calculator");
        }

        [Test]
        public void UseObjectInitilizerWithDefaultConstructor()
        {
            var calculator = new Calculator();
            Check.That(calculator.Name).Equals("Calculator");
        }

        [Test]
        public void DefineConstantForPi()
        {
            var sumOfADoubleAndPiConstant = "1,2 + pi";
            var calculator = new Calculator();
            var sum = calculator.Sum(sumOfADoubleAndPiConstant);
            // define pi constant (as double) and replace pi string with constant value
            Check.That(sum).Equals(4.34);
        }

        //[Test]
        //public void StaticReadonlyMembers()
        //{
        //    var sumOfADoubleAndPiConstant = "1,2 + pi";
        //     replace pi constant with a static readonly member
        //    Check.That(sum).Equals(4.34);
        //}

        //[Test]
        //public void MakeSumMethodsStaticAsTheyDoNotNeedAnyInstanceSpecific()
        //{
        //    // make sum methods static and call one these to retrieve a sum of double array values
        //    Check.That(sum).Equals(3.0);
        //}

        //[Test]
        //public void AddStaticCalculatorClass()
        //{
        //    // define a static class StaticCalculator that uses Calculator static methods & define static getter for Name
        //    Check.That(staticCalculator.Name).Equals("Static calculator");
        //}
    }
}
