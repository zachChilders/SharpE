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
    public class RowVector : Matrix
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public RowVector(int n)
            : base(1, n)
        {
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public RowVector(int[] array)
            : base(1, array.Length)
        {
            Parallel.For(0, array.Length, i =>
            {
                matrix[0][1] = array[i];
            });
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public RowVector(Double[] array)
            : base(1, array.Length)
        {
            Parallel.For(0, array.Length, i =>
            {
                matrix[0][i] = array[i];
            });
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public RowVector(float[] array)
            : base(array.Length, 1)
        {
            Parallel.For(0, array.Length, i =>
            {
                matrix[0][i] = array[i];
            });
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public RowVector(Number[] array)
            : base(array.Length, 1)
        {
            Parallel.For(0, array.Length, i =>
            {
                matrix[0][i] = array[i];
            });
        }

        /// <summary>
        /// Allows for [][] indexing of matrices. Must be 0 based.
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Matrix Row i</returns>
        public new Number this[int i]
        {
            get
            {
                return matrix[0][i];
            }
            set
            {
                matrix[0][i] = value;
            }
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
                resultant[i] = b.dot(a[i]);
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

            Parallel.For(0, a.NumCols, i =>
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
            RowVector resultant = new RowVector(v.NumRows);
            Parallel.For(0, v.NumCols, i =>
            {
                resultant[i] = v[i] / n;
            });
            return resultant;
        }

        /// <summary>
        /// Find the max of a vector.
        /// </summary>
        /// <returns></returns>
        public Number MaxElement()
        {
            Number max = matrix[0][0];
            Parallel.For(1, NumCols, i =>
            {
                if (matrix[0][i] > max)
                {
                    max = matrix[0][i];
                }
            });
            return max;
        }

        /// <summary>
        /// Applies a scale to each number and returns the sum.
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        private Number dot(Number[] number1)
        {
            Number resultant = 0.0;
            Parallel.For(0, number1.Length, i =>
            {
                resultant += (number1[i]*matrix[0][i]);
            });

            return resultant;
        }

        /// <summary>
        /// Applies a scale to each number and returns the sum.
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        private static Number dot(Number number1, Number[] number2)
        {
            return number2.Aggregate<Number, Number>(0.0, (current, t) => current + (t * number1));
        }

        /// <summary>
        /// Row * Vector is a dot product.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Number operator *(RowVector r, Vector v)
        {
            if (r.NumCols != v.NumRows)
            {
                return new Number();
            }

            Number sum = 0.0;
            Parallel.For(0, r.NumCols, i =>
            {
                sum += (r[i]*v[i]);
            });
            return sum;
        }

        /// <summary>
        /// Override to print horizontally.
        /// </summary>
        /// <returns></returns>
        public new String ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < NumCols; i++)
            {
                str.Append(matrix[0][i]);
                str.Append(" ");
            }
            str.Append("\n");

            return str.ToString();
        }

        /// <summary>
        /// Transposing a Column Vector should give a Row vector
        /// </summary>
        /// <returns></returns>
        public new Vector Transpose()
        {
            Vector r = new Vector(NumCols);
            Parallel.For(0, NumCols, i =>
            {
                r[i] = matrix[0][i];
            });
            return r;
        }

        /// <summary>
        /// Returns a unit vector 
        /// </summary>
        /// <returns></returns>
        public RowVector UnitVector()
        {
            return this / Magntitude();
        }

        public Number Magntitude()
        {
            Number magnitude = 0.0;
            Parallel.For(0, NumCols, i =>
            {
                magnitude += matrix[0][i]*matrix[0][i];
            });
            magnitude = Math.Sqrt(magnitude);
            return magnitude;
        }
    }
}

