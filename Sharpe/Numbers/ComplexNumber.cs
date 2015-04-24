using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpe.Matrix;

namespace Sharpe.Numbers
{
    /// <summary>
    /// A Class to represent Complex numbers. 
    /// Contains a real and imaginary portion.
    /// </summary>
    public class ComplexNumber
    {
        /// <summary>
        /// Real component of a complex number.
        /// </summary>
        public double Real;

        /// <summary>
        /// Imaginary component of a complex number.
        /// </summary>
        public double Imaginary;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ComplexNumber()
        {
            Real = Double.NaN;
            Imaginary = Double.NaN;
        }

        /// <summary>
        /// Sets default values of a ComplexNumber.
        /// </summary>
        /// <param name="r">Real Number</param>
        /// <param name="i">Imaginary Number</param>
        public ComplexNumber(double r, double i)
        {
            Real = r;
            Imaginary = i;
        }


        /// <summary>
        /// Adds two ComplexNumbers.
        /// </summary>
        /// <param name="a">A ComplexNumber</param>
        /// <param name="b">A ComplexNumber</param>
        /// <returns>The sum of two ComplexNumbers.</returns>
        public static ComplexNumber operator +(ComplexNumber a, Number b)
        {
            ComplexNumber cn = new ComplexNumber();
            cn.Real = a.Real + b.Real;
            cn.Imaginary = a.Imaginary + b.Imaginary;
            return cn;
        }

        /// <summary>
        /// Subtracts two ComplexNumbers.
        /// </summary>
        /// <param name="a">A ComplexNumber</param>
        /// <param name="b">A ComplexNumber</param>
        /// <returns>The difference of two ComplexNumbers.</returns>
        public static ComplexNumber operator -(ComplexNumber a, Number b)
        {
            ComplexNumber cn = new ComplexNumber();
            cn.Real = a.Real - b.Real;
            cn.Imaginary = a.Imaginary - b.Imaginary;
            return cn;
        }

        /// <summary>
        /// Multiplies two ComplexNumbers.
        /// </summary>
        /// <param name="a">A ComplexNumber</param>
        /// <param name="b">A ComplexNumber</param>
        /// <returns>The product of two ComplexNumbers.</returns>
        public static ComplexNumber operator *(ComplexNumber a, Number b)
        {
            ComplexNumber cn = new ComplexNumber();
            cn.Real = a.Real * b.Real;
            cn.Imaginary = a.Imaginary * b.Imaginary;
            return cn;
        }

        /// <summary>
        /// Divides two ComplexNumbers.
        /// </summary>
        /// <param name="a">A ComplexNumber</param>
        /// <param name="b">A ComplexNumber with Non-Zero components.</param>
        /// <returns>The quotient of two ComplexNumbers.</returns>
        public static ComplexNumber operator /(ComplexNumber a, Number b)
        {
            if ((b.Real == 0) || (b.Imaginary == 0))
            {
                throw new DivideByZeroException();
            }
            ComplexNumber cn = new ComplexNumber();
            cn.Real = a.Real / b.Real;
            cn.Imaginary = a.Imaginary / b.Imaginary;
            return cn;
        }

        /// <summary>
        /// Converts ComplexNumber to a String.
        /// </summary>
        /// <returns>The String representation of a ComplexNumber.</returns>
        public new String ToString()
        {
            StringBuilder complex = new StringBuilder();
            complex.Append(Real.ToString());
            complex.Append(!Double.IsNaN(Imaginary) ? "+" : "");
            complex.Append(Imaginary.ToString());
            complex.Append("i");
            return complex.ToString();
        }
    }
}
