using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpe.Numbers
{
    /// <summary>
    /// Number is a generic class that allows any numerical data type to 
    /// be converted to any other numerical data type.  Every number is implicitly
    /// converted to a Number when it enters a matrix.
    /// </summary>
    public class Number
    {
        public Double real = Double.NaN;
        public Double imaginary = Double.NaN;

        /// <summary>
        /// Convert from Number to Double.
        /// </summary>
        /// <param name="n">Any Number</param>
        /// <returns>A Double</returns>
        public static implicit operator Double(Number n)
        {
            return n.real;
        }

        /// <summary>
        /// Converts from Double to Number.
        /// </summary>
        /// <param name="d">Any Double</param>
        /// <returns>A Number</returns>
        public static implicit operator Number(Double d)
        {
            Number n = new Number();
            n.real = d;
            return n;
        }

        /// <summary>
        /// Converts from Number to Int64.
        /// </summary>
        /// <param name="n">Any Number</param>
        /// <returns>An Integer</returns>
        public static implicit operator Int64(Number n)
        {
            return Convert.ToInt64(n.real);
        }

        /// <summary>
        /// Converts from Int64 to Number
        /// </summary>
        /// <param name="i">Any Integer</param>
        /// <returns>A Number</returns>
        public static implicit operator Number(Int64 i)
        {
            Number n = new Number {real = i};
            return n;
        }

        /// <summary>
        /// Converts from Number to ComplexNumber.
        /// </summary>
        /// <param name="n">A Number</param>
        /// <returns>A Complex Number</returns>
        public static implicit operator ComplexNumber(Number n)
        {
            ComplexNumber cn = new ComplexNumber {real = n.real, imaginary = n.imaginary};
            return cn;
        }

        /// <summary>
        /// Converts from ComplexNumber to Number.
        /// </summary>
        /// <param name="cn">A ComplexNumber</param>
        /// <returns>A Number</returns>
        public static implicit operator Number(ComplexNumber cn)
        {
            Number n = new Number {real = cn.real, imaginary = cn.imaginary};
            return n;
        }

        /// <summary>
        /// Converts from Number to float.  May incur loss of precision.
        /// </summary>
        /// <param name="n">A Number</param>
        /// <returns>A float.</returns>
        public static implicit operator float(Number n)
        {
            return (float)n.real;
        }

        /// <summary>
        /// Adds two Numbers. 
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Number</param>
        /// <returns>Sum of A and B</returns>
        public static Number operator +(Number a, Number b)
        {
            Number n = new Number {real = a.real + b.real, imaginary = a.imaginary + b.imaginary};
            return n;
        }

        /// <summary>
        /// Subtracts two numbers.
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Number</param>
        /// <returns>Difference between A and B</returns>
        public static Number operator -(Number a, Number b)
        {
            Number n = new Number {real = a.real - b.real, imaginary = a.imaginary - b.imaginary};
            return n;
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Number</param>
        /// <returns>The product of A and B</returns>
        public static Number operator *(Number a, Number b)
        {
            Number n = new Number {real = a.real*b.real, imaginary = a.imaginary*b.imaginary};
            return n;
        }

        /// <summary>
        /// Divides two numbers.  
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Non-Zero Number</param>
        /// <returns>The quotient of A and B.</returns>
        public static Number operator /(Number a, Number b)
        {

            Number n = new Number();
            if ((b.real != 0.0) && (b.imaginary != 0.0))
            {
                n.real = a.real / b.real;
                n.imaginary = a.imaginary / b.imaginary;
            }
            return n;
        }

        /// <summary>
        /// Compares two Numbers.
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Number</param>
        /// <returns>Equality of two numbers.</returns>
        public static Boolean operator ==(Number a, Number b)
        {
            return ((a.real == b.real) && (a.imaginary == b.imaginary));
        }

        /// <summary>
        /// Compares two Numbers.
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Number</param>
        /// <returns>Equality of two numbers.</returns>
        public static Boolean operator !=(Number a, Number b)
        {
            return ((a.real != b.real) && (a.imaginary != b.imaginary));
        }

        /// <summary>
        /// Compares two Numbers.
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Number</param>
        /// <returns>A is less than B.</returns>
        public static Boolean operator <(Number a, Number b)
        {
            if ((!double.IsNaN(a.imaginary)) || (!double.IsNaN(b.imaginary)))
            {
                throw new NotImplementedException();
            }
            else
            {
                return a.real < b.real;
            }
        }

        /// <summary>
        /// Compares two Numbers.
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Number</param>
        /// <returns>A is greater than B.</returns>
        public static Boolean operator >(Number a, Number b)
        {
            if ((!double.IsNaN(a.imaginary)) || (!double.IsNaN(b.imaginary)))
            {
                throw new NotImplementedException();
            }
            else
            {
                return a.real > b.real;
            }
        }

        /// <summary>
        /// Compares two Numbers.
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Number</param>
        /// <returns>A is less than or equal to B.</returns>
        public static Boolean operator <=(Number a, Number b)
        {
            if ((a.imaginary != 0.0) || (b.imaginary != 0.0))
            {
                throw new NotImplementedException();
            }
            else
            {
                return a.real <= b.real;
            }
        }

        /// <summary>
        /// Compares two Numbers.
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Number</param>
        /// <returns>A is greater than or equal to B.</returns>
        public static Boolean operator >=(Number a, Number b)
        {
            if ((a.imaginary != 0.0) || (b.imaginary != 0.0))
            {
                throw new NotImplementedException();
            }
            else
            {
                return a.real >= b.real;
            }
        }

        /// <summary>
        /// Compares a reference of a Number and another object.
        /// </summary>
        /// <param name="obj">An object</param>
        /// <returns>If the reference is the same as our Number</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Number)) return false;

            Number p = (Number)obj;
            return real == p.real && imaginary == p.imaginary;
        }

        /// <summary>
        /// Hashes a Number.
        /// </summary>
        /// <returns>Hash of a Number.</returns>
        public override int GetHashCode()
        {
            return Tuple.Create(real, imaginary).GetHashCode();
        }

        /// <summary>
        /// Converts to String.
        /// </summary>
        /// <returns>The String representation of a Number.</returns>
        public new String ToString()
        {
            if (!Double.IsNaN(imaginary))
            {
                ComplexNumber cn = new ComplexNumber(real, imaginary);
                return cn.ToString();
            }
            else
            {
                return real.ToString();
            }
        }

    }
}
