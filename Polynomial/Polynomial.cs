using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Polynomiall
{
    public sealed class Polynomial
    {
        #region Fields

        private readonly double[] coefficients;

        private readonly int degree;

        private static readonly double epsilon;

        #endregion

        #region Properties
        /// <summary>
        /// Degree
        /// </summary>
        public int Degree { get { return degree; } }

        /// <summary>
        /// Epsilon
        /// </summary>
        public static double Epsilon { get { return epsilon; } }
        #endregion

        private double this[int index]
        {
            get
            {
                if (index < 0 || index > Degree)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return coefficients[index];
            }
        }

        #region Constructors

        static Polynomial()
        {
                epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"], CultureInfo.InvariantCulture);        
        }
        /// <summary>
        /// Initialize a new instance
        /// </summary>
        /// <param name="coefficients">Taking coefficients of the polynome</param>
        public Polynomial(params double[] coefficients)
        {
            
            if (ReferenceEquals(coefficients, null))
                throw new ArgumentNullException(nameof(coefficients));

            degree = coefficients.Length - 1;
            for (int i = coefficients.Length - 1; i >= 0; i--)
                if (i == 0 || Math.Abs(coefficients[i]) > epsilon)
                {
                    this.degree = i;
                    break;
                }
            this.coefficients = new double[degree + 1];
            Array.Copy(coefficients, this.coefficients, degree + 1);
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Calculating a result value of the polynome
        /// </summary>
        /// <param name="x">variable x</param>
        /// <returns>result value</returns>
        public double Calculate(double x)
        {
            double result = 0;

            for (int i = 0; i <= degree; i++)
            {
                result += Math.Pow(x, i) * coefficients[i];
            }
            return result;
        }

        /// <summary>
        /// Checks whether this instance has the same values with argument instance
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (this.degree != other.Degree) return false;

            for (int i = 0; i < this.coefficients.Length; i++)
                if (this.coefficients[i] != other.coefficients[i]) 
                    return false;
            return true;
        }

   
       public override bool Equals(object obj)
       {
            if (this.GetType() != obj.GetType())
                return false;
            return Equals((Polynomial)obj);
       }


        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Represents polynome as a string
        /// </summary>
        /// <returns>Represents polynome as a string</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            int degree = 1;
            result.AppendFormat($"{coefficients[0]}");
            for (int i = 1; i < coefficients.Length; i++)
            {
                if (Math.Abs(coefficients[i]) < epsilon)
                {
                    degree++;
                    continue;
                }

                if (i != coefficients.Length - 1)
                    if (coefficients[i] == 0)
                        continue;
                if (coefficients[i] > 0)
                    result.Append(" + ");
                else result.Append(" - ");

                result.AppendFormat($"{Math.Abs(coefficients[i])}x^{degree++}");               
            }

            return result.ToString();
        }

        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return true;

            if (ReferenceEquals(lhs, null)) return false;

            return lhs.Equals(rhs);


            return lhs.Equals(lhs);
        }

        public static bool operator !=(Polynomial lhs, Polynomial rhs) => !(lhs == rhs);

        /// <summary>
        /// sum for two polynomes
        /// </summary>
        /// <param name="lhs">first</param>
        /// <param name="rhs">second</param>
        /// <returns>sum of two polynomes</returns>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                throw new ArgumentNullException("one of args is null");

            int newDegree = (lhs.degree < rhs.degree) ? rhs.degree : lhs.degree;

            double[] newCoefficients = new double[newDegree + 1];    

            for (int i = 0; i <= newDegree; i++)
            {              
                if (i <= lhs.degree)
                    newCoefficients[i] += lhs.coefficients[i];
                if (i <= rhs.degree)
                    newCoefficients[i] += rhs.coefficients[i];
            }

            return new Polynomial(newCoefficients);
        }
        /// <summary>
        /// substruct for two polynomes
        /// </summary>
        /// <param name="lhs">first</param>
        /// <param name="rhs">second</param>
        /// <returns>substractions of two polynomes</returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                throw new ArgumentNullException("one of args is null");

            double[] newCoefficients = new double[rhs.degree + 1];
            for (int i = 0; i < newCoefficients.Length; i++)
                newCoefficients[i] = -rhs.coefficients[i];
            return lhs + (-rhs);
        }

        public static Polynomial operator -(Polynomial rhs)
        {
            double[] newCoefficients = new double[rhs.degree + 1];
            for (int i = 0; i < newCoefficients.Length; i++)
                newCoefficients[i] = -rhs.coefficients[i];
            return new Polynomial(newCoefficients);
        }
        /// <summary>
        /// multiplication of two polynomes
        /// </summary>
        /// <param name="lhs">first</param>
        /// <param name="rhs">second</param>
        /// <returns>multiplication of two polynomes</returns>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                throw new ArgumentNullException("one of args is null");

            double[] newCoefficients = new double[lhs.degree + rhs.degree + 1];

            for (int i = 0; i <= lhs.degree; i++)
                for (int j = 0; j <= rhs.degree; j++)
                    newCoefficients[i + j] += lhs.coefficients[i] * rhs.coefficients[j];

            return new Polynomial(newCoefficients);
        }

        public static Polynomial Add(Polynomial lhs, Polynomial rhs) => lhs + rhs;      
        public static Polynomial Subtract(Polynomial lhs, Polynomial rhs) => lhs - rhs;
        public static Polynomial Multiply(Polynomial lhs, Polynomial rhs) => lhs * rhs;
        #endregion
    }
}