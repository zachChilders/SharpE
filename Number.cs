using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpe
{
    public class Number
    {
        internal Double real = 0.0;
        internal Double imaginary;

        public Number() { real = 0.0; imaginary = 0.0; }

        /// <summary>
        /// From Number to Double
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static implicit operator Double(Number n)
        {
            return n.real;
        }

        /// <summary>
        /// From Double to Number
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static implicit operator Number(Double d)
        {
            Number n = new Number();
            n.real = d;
            return n;
        }

        /// <summary>
        /// Convert from Number to Int64
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static implicit operator Int64(Number n)
        {
            return Convert.ToInt64(n.real);
        }

        /// <summary>
        /// Convert from Int64 to Number
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static implicit operator Number(Int64 i)
        {
            Number n = new Number();
            n.real = i;
            return n;
        }

        public static implicit operator ComplexNumber(Number n)
        {
            ComplexNumber cn = new ComplexNumber();
            cn.real = n.real;
            cn.imaginary = n.imaginary;
            return cn;
        }

        public static implicit operator Number(ComplexNumber cn)
        {
            Number n = new Number();
            n.real = cn.real;
            n.imaginary = cn.imaginary;
            return n;
        }

        public static implicit operator float(Number n)
        {
            return (float)n.real;
        }

        public static Number operator +(Number a, Number b)
        {
            Number n = new Number();
            n.real = a.real + b.real;
            n.imaginary = a.imaginary + b.imaginary;
            return n;
        }

        public static Number operator -(Number a, Number b)
        {
            Number n = new Number();
            n.real = a.real - b.real;
            n.imaginary = a.imaginary - b.imaginary;
            return n;
        }

        public static Number operator *(Number a, Number b)
        {
            Number n = new Number();
            n.real = a.real * b.real;
            n.imaginary = a.imaginary * b.imaginary;
            return n;
        }

        public static Number operator /(Number a, Number b)
        {
            //This should probably not let you divide by 0.
            Number n = new Number();
            n.real = a.real / b.real;
            n.imaginary = a.imaginary / b.imaginary;
            return n;
        }

        public static Boolean operator ==(Number a, Number b)
        {
            return ((a.real == b.real) && (a.imaginary == b.imaginary));
        }

        public static Boolean operator !=(Number a, Number b)
        {
            return ((a.real != b.real) && (a.imaginary != b.imaginary));
        }

        public static Boolean operator <(Number a, Number b)
        {
            if ((a.imaginary != 0.0) || (b.imaginary != 0.0))
            {
                throw new NotImplementedException();
            }
            else
            {
                return a.real < b.real;
            }
        }

        public static Boolean operator >(Number a, Number b)
        {
            if ((a.imaginary != 0.0) || (b.imaginary != 0.0))
            {
                throw new NotImplementedException();
            }
            else
            {
                return a.real > b.real;
            }
        }

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

        public new String ToString()
        {
            if (imaginary != 0.0)
            {
                StringBuilder complex = new StringBuilder();
                complex.Append(real.ToString());
                complex.Append(imaginary.ToString());
                return complex.ToString();
            }
            else
            {
                return real.ToString();
            }
        }

    }
}
