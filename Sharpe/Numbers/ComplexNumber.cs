using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double real;

        /// <summary>
        /// Imaginary component of a complex number.
        /// </summary>
        public double imaginary;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ComplexNumber()
        {
            real = Double.NaN;
            imaginary = Double.NaN;
        }

        /// <summary>
        /// Sets default values of a ComplexNumber.
        /// </summary>
        /// <param name="r">Real Number</param>
        /// <param name="i">Imaginary Number</param>
        public ComplexNumber(double r, double i)
        {
            real = r;
            imaginary = i;
        }


        /// <summary>
        /// Adds two ComplexNumbers.
        /// </summary>
        /// <param name="A">A ComplexNumber</param>
        /// <param name="B">A ComplexNumber</param>
        /// <returns>The sum of two ComplexNumbers.</returns>
        public static ComplexNumber operator +(ComplexNumber A, Number B)
        {
            ComplexNumber cn = new ComplexNumber();
            cn.real = A.real + B.real;
            cn.imaginary = A.imaginary + B.imaginary;
            return cn;
        }

        /// <summary>
        /// Subtracts two ComplexNumbers.
        /// </summary>
        /// <param name="A">A ComplexNumber</param>
        /// <param name="B">A ComplexNumber</param>
        /// <returns>The difference of two ComplexNumbers.</returns>
        public static ComplexNumber operator -(ComplexNumber A, Number B)
        {
            ComplexNumber cn = new ComplexNumber();
            cn.real = A.real - B.real;
            cn.imaginary = A.imaginary - B.imaginary;
            return cn;
        }

        /// <summary>
        /// Multiplies two ComplexNumbers.
        /// </summary>
        /// <param name="A">A ComplexNumber</param>
        /// <param name="B">A ComplexNumber</param>
        /// <returns>The product of two ComplexNumbers.</returns>
        public static ComplexNumber operator *(ComplexNumber A, Number B)
        {
            ComplexNumber cn = new ComplexNumber();
            cn.real = A.real * B.real;
            cn.imaginary = A.imaginary * B.imaginary;
            return cn;
        }

        /// <summary>
        /// Divides two ComplexNumbers.
        /// </summary>
        /// <param name="A">A ComplexNumber</param>
        /// <param name="B">A ComplexNumber with Non-Zero components.</param>
        /// <returns>The quotient of two ComplexNumbers.</returns>
        public static ComplexNumber operator /(ComplexNumber A, Number B)
        {
            if ((B.real == 0) || (B.imaginary == 0))
            {
                throw new DivideByZeroException();
            }
            ComplexNumber cn = new ComplexNumber();
            cn.real = A.real / B.real;
            cn.imaginary = A.imaginary / B.imaginary;
            return cn;
        }

        /// <summary>
        /// Converts ComplexNumber to a String.
        /// </summary>
        /// <returns>The String representation of a ComplexNumber.</returns>
        public new String ToString()
        {
            StringBuilder complex = new StringBuilder();
            complex.Append(real.ToString());
            complex.Append(!Double.IsNaN(this.imaginary) ? "+" : "");
            complex.Append(imaginary.ToString());
            complex.Append("i");
            return complex.ToString();
        }
    }
}
