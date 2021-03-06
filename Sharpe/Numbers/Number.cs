﻿using System;
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
        /// <summary>
        /// 
        /// </summary>
        public Double Real = Double.NaN;
        /// <summary>
        /// 
        /// </summary>
        public Double Imaginary = Double.NaN;

        /// <summary>
        /// Convert from Number to Double.
        /// </summary>
        /// <param name="n">Any Number</param>
        /// <returns>A Double</returns>
        public static implicit operator Double(Number n)
        {
            return n.Real;
        }

        /// <summary>
        /// Converts from Double to Number.
        /// </summary>
        /// <param name="d">Any Double</param>
        /// <returns>A Number</returns>
        public static implicit operator Number(Double d)
        {
            Number n = new Number();
            n.Real = d;
            return n;
        }

        /// <summary>
        /// Converts from Number to Int64.
        /// </summary>
        /// <param name="n">Any Number</param>
        /// <returns>An Integer</returns>
        public static implicit operator Int64(Number n)
        {
            return Convert.ToInt64(n.Real);
        }

        /// <summary>
        /// Converts from Int64 to Number
        /// </summary>
        /// <param name="i">Any Integer</param>
        /// <returns>A Number</returns>
        public static implicit operator Number(Int64 i)
        {
            Number n = new Number {Real = i};
            return n;
        }

        /// <summary>
        /// Converts from Number to ComplexNumber.
        /// </summary>
        /// <param name="n">A Number</param>
        /// <returns>A Complex Number</returns>
        public static implicit operator ComplexNumber(Number n)
        {
            ComplexNumber cn = new ComplexNumber {Real = n.Real, Imaginary = n.Imaginary};
            return cn;
        }

        /// <summary>
        /// Converts from ComplexNumber to Number.
        /// </summary>
        /// <param name="cn">A ComplexNumber</param>
        /// <returns>A Number</returns>
        public static implicit operator Number(ComplexNumber cn)
        {
            Number n = new Number {Real = cn.Real, Imaginary = cn.Imaginary};
            return n;
        }

        /// <summary>
        /// Converts from Number to float.  May incur loss of precision.
        /// </summary>
        /// <param name="n">A Number</param>
        /// <returns>A float.</returns>
        public static implicit operator float(Number n)
        {
            return (float)n.Real;
        }

        /// <summary>
        /// Adds two Numbers. 
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Number</param>
        /// <returns>Sum of A and B</returns>
        public static Number operator +(Number a, Number b)
        {
            Number n = new Number {Real = a.Real + b.Real, Imaginary = a.Imaginary + b.Imaginary};
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
            Number n = new Number {Real = a.Real - b.Real, Imaginary = a.Imaginary - b.Imaginary};
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
            Number n = new Number {Real = a.Real*b.Real, Imaginary = a.Imaginary*b.Imaginary};
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
            if ((b.Real != 0.0) && (b.Imaginary != 0.0))
            {
                n.Real = a.Real / b.Real;
                n.Imaginary = a.Imaginary / b.Imaginary;
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
            return ((a.Real == b.Real) && (a.Imaginary == b.Imaginary));
        }

        /// <summary>
        /// Compares two Numbers.
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Number</param>
        /// <returns>Equality of two numbers.</returns>
        public static Boolean operator !=(Number a, Number b)
        {
            return ((a.Real != b.Real) && (a.Imaginary != b.Imaginary));
        }

        /// <summary>
        /// Compares two Numbers.
        /// </summary>
        /// <param name="a">A Number</param>
        /// <param name="b">A Number</param>
        /// <returns>A is less than B.</returns>
        public static Boolean operator <(Number a, Number b)
        {
            if ((!double.IsNaN(a.Imaginary)) || (!double.IsNaN(b.Imaginary)))
            {
                throw new NotImplementedException();
            }
            else
            {
                return a.Real < b.Real;
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
            if ((!double.IsNaN(a.Imaginary)) || (!double.IsNaN(b.Imaginary)))
            {
                throw new NotImplementedException();
            }
            else
            {
                return a.Real > b.Real;
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
            return Real == p.Real && Imaginary == p.Imaginary;
        }

        /// <summary>
        /// Hashes a Number.
        /// </summary>
        /// <returns>Hash of a Number.</returns>
        public override int GetHashCode()
        {
            return Tuple.Create(Real, Imaginary).GetHashCode();
        }

        /// <summary>
        /// Converts to String.
        /// </summary>
        /// <returns>The String representation of a Number.</returns>
        public new String ToString()
        {
            if (!Double.IsNaN(Imaginary))
            {
                ComplexNumber cn = new ComplexNumber(Real, Imaginary);
                return cn.ToString();
            }
            else
            {
                return Real.ToString();
            }
        }

    }
}
