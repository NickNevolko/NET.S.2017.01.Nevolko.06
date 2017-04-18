using NUnit.Framework;
using System;
using Polynomiall;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomTests
{
    [TestFixture]
    public class TestClass
    {

        public void Constructor_NullException()
        {
            double[] nul = null;
            Assert.Throws<ArgumentNullException>(() => new Polynomial(nul));
        }

        [TestCase(2, 5, ExpectedResult = 12)]
        [TestCase(0, 0, 0, 0, 0, 2, ExpectedResult = 64)]
        [TestCase(1, -4, 0, 2, ExpectedResult = 9)]
        [TestCase(0, 0, 0, 0, 0, 0, ExpectedResult = 0)]
        public double Calculate_Test(params double[] coefficients)
        {
            double x = 2;
            return (new Polynomial(coefficients)).Calculate(x);
        }

        [TestCase(new double[] { 1, -2, 3, 4, -5 }, ExpectedResult = "1 - 2x^1 + 3x^2 + 4x^3 - 5x^4")]
        public string ToString_Test(double[] coefficients) => new Polynomial(coefficients).ToString();

        [TestCase(new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 }, ExpectedResult = false)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, ExpectedResult = true)]
        public bool OperatorEqual_Test(double[] coefficients1, double[] coefficients2)
        {
            return new Polynomial(coefficients1) == new Polynomial(coefficients2);
        }

        [TestCase(new double[] { 1, 0, 3 }, new double[] { 30, 0, 30 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3, 4 }, new double[] { 1, 2, -3, 4 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3, 4 }, new double[] { 1, 2, 3, 4 }, ExpectedResult = false)]
        public bool OperatorNotEqual_Test(double[] coefficients1, double[] coefficients2)
        {
            return new Polynomial(coefficients1) != new Polynomial(coefficients2);
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { -1, -2, -3 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, ExpectedResult = true)]
        public bool Equals_Test(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = new Polynomial(coefficients1);
            Polynomial polynomial2 = new Polynomial(coefficients2);

            return polynomial1.Equals(polynomial2);
        }

        [TestCase(new double[] { 1, 2, 3, 5 }, new double[] { -1, -2, -3, -5 }, 2, ExpectedResult = 0)]
        [TestCase(new double[] { 1, 2 }, new double[] { 3 }, 2, ExpectedResult = 8)]
        public double Add_Test(double[] coefficients1, double[] coefficients2, double x)
        {
            return (new Polynomial(coefficients1) + new Polynomial(coefficients2)).Calculate(x);
        }

        [TestCase(new double[] { 1, 2, 3, 5 }, new double[] { -1, -2, -3, -5 }, 2, ExpectedResult = 114)]
        [TestCase(new double[] { 1, 2 }, new double[] { 3 }, 2, ExpectedResult = 2)]
        public double Subs_Test(double[] coefficients1, double[] coefficients2, double x)
        {
            return (new Polynomial(coefficients1) - new Polynomial(coefficients2)).Calculate(x);
        }

        [TestCase(new double[] { 1, 2 ,3 , 4 }, new double[] { 0, 0, 0 }, 2, ExpectedResult = 0)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 1, 2, 3, 4 }, 3, ExpectedResult = 0)]
        [TestCase(new double[] { 0, 1, 0 }, new double[] { 1, 2, 3, 4 }, 4, ExpectedResult = 1252)]
        [TestCase(new double[] { 1, 2, 3, 4 }, new double[] { 1, 2, 3, 4 }, 5, ExpectedResult = 343396)]
        public double Multiply_Test(double[] coefficients1, double[] coefficients2, double x)
        {
            return (new Polynomial(coefficients1) * new Polynomial(coefficients2)).Calculate(x);
        }

    }
}