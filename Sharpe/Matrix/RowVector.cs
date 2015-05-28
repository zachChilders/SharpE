using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpe.Numbers;

namespace Sharpe.Matrix
{
    /// <summary>
    /// 
    /// </summary>
    public class RowVector : Vector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public RowVector(int n)
            : base(n)
        {
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public RowVector(int[] array)
            : base(array.Length)
        {
            Parallel.For(0, array.Length, i =>
            {
                v.Insert(i, array[i]);
            });
        }


        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public RowVector(Byte[] array)
            : base(array.Length)
        {
            Parallel.For(0, array.Length, i =>
            {
                v.Insert(i, array[i]);
            });
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public RowVector(Double[] array)
            : base(array.Length)
        {
            Parallel.For(0, array.Length, i =>
            {
                v.Insert(i, array[i]);
            });
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public RowVector(float[] array)
            : base(array.Length)
        {
            Parallel.For(0, array.Length, i =>
            {
                v.Insert(i, array[i]);
            });
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public RowVector(Number[] array)
            : base(array.Length)
        {
            Parallel.For(0, array.Length, i =>
            {
                v.Insert(i, array[i]);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static RowVector operator +(RowVector r, Number n)
        {
            RowVector resultant = new RowVector(r.Size);
            Parallel.For(0, r.Size, i =>
            {
                r[i] += n;
            });

            return resultant;
        }

        public static RowVector operator -(RowVector a, RowVector b)
        {
            RowVector resultant = new RowVector(a.Size);
            Parallel.For(0, a.Size, i =>
            {
                resultant[i] = a[i] - b[i];
            });
            return resultant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static RowVector operator -(RowVector r, Number n)
        {
            RowVector resultant = new RowVector(r.Size);
            Parallel.For(0, r.Size, i =>
            {
                resultant[i] = r[i] - n;
            });

            return resultant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static RowVector operator *(RowVector r, Number n)
        {
            RowVector resultant = new RowVector(r.Size);
            Parallel.For(0, r.Size, i =>
            {
                resultant[i] = r[i] * n;
            });

            return resultant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static RowVector operator *(Number n, RowVector r)
        {
            RowVector resultant = new RowVector(r.Size);
            Parallel.For(0, r.Size, i =>
            {
                resultant[i] = r[i] * n;
            });

            return resultant;
        }

        /// <summary>
        /// Multiplies two matrices, if possible.  
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static RowVector operator *(Matrix a, RowVector b)
        {

            RowVector resultant = new RowVector(a.NumRows);

            Parallel.For(0, a.NumRows, i =>
            {
                resultant.Append(b.dot(a[i]));
            });

            return resultant;
        }

        /// <summary>
        /// Vector * matrix
        /// </summary>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static RowVector operator *(RowVector b, Matrix a)
        {

            RowVector resultant = new RowVector(a.NumRows);

            Parallel.For(0, a.NumRows, i =>
            {
                resultant[i] = dot(b[i], a[i]);
            });

            return resultant;
        }

        /// <summary>
        /// Matrix * Matrix
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Number operator *(RowVector a, RowVector b)
        {
            Number resultant = 0.0;

            Parallel.For(0, a.Size, i =>
            {
                resultant += a[i] * b[i];
            });
            return resultant;
        }

        /// <summary>
        /// Scale down a vector
        /// </summary>
        /// <param name="v"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static RowVector operator /(RowVector v, Number n)
        {
            RowVector resultant = new RowVector(v.Size);
            Parallel.For(0, v.Size, i =>
            {
                resultant[i] = v[i] / n;
            });
            return resultant;
        }

        /// <summary>
        /// Applies a scale to each number and returns the sum.
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        private Number dot(RowVector number1)
        {
            Number resultant = 0.0;
            Parallel.For(0, number1.Size, i =>
            {
                resultant += (number1[i] * v[i]);
            });

            return resultant;
        }

        /// <summary>
        /// Applies a scale to each number and returns the sum.
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        private static Number dot(Number number1, RowVector number2)
        {
            Number sum = 0.0;
            for (int i = 0; i < number2.Size; i++)
            {
                sum += (number1 * number2[i]);
            }
            return sum;
        }

        /// <summary>
        /// Row * Vector is a dot product.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Number operator *(RowVector r, Vector v)
        {
            if (r.Size != v.Size)
            {
                return new Number();
            }

            Number sum = 0.0;
            Parallel.For(0, r.Size, i =>
            {
                sum += (r[i] * v[i]);
            });
            return sum;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < v.Count; i++)
            {
                sb.Append(v[i].ToString());
                sb.Append(" ");
            }
            sb.Append("\n");
            return sb.ToString();
        }
    }
}

