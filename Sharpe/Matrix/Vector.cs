using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Sharpe.Numbers;

namespace Sharpe.Matrix
{
    /// <summary>
    /// An n-Dimensional Vector
    /// </summary>
    public class Vector : Matrix
    {
        /// <summary>
        /// Creates an n-Dimensional Vector.
        /// </summary>
        /// <param name="n">Number of dimensions.</param>
        public Vector(int n)
            : base(n, 1)
        {
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public Vector(int[] array)
            : base(array.Length, 1)
        {
            Parallel.For(0, array.Length, i =>
            {
                matrix[i][0] = array[i];
            });
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public Vector(Double[] array)
            : base(array.Length, 1)
        {
            Parallel.For(0, array.Length, i =>
            {
                matrix[i][0] = array[i];
            });
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public Vector(float[] array)
            : base(array.Length, 1)
        {
            Parallel.For(0, array.Length, i =>
            {
                matrix[i][0] = array[i];
            });
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public Vector(Number[] array)
            : base(array.Length, 1)
        {
            Parallel.For(0, array.Length, i =>
            {
                matrix[i][0] = array[i];
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
                return matrix[i][0];
            }
            set
            {
                matrix[i][0] = value;
            }
        }

        /// <summary>
        /// Multiplies two matrices, if possible.  
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(Matrix a, Vector b)
        {

            Vector resultant = new Vector(a.NumRows);

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
        public static Vector operator *(Vector b, Matrix a)
        {

            Vector resultant = new Vector(a.NumRows);

            Parallel.For(0, a.NumRows, i=>
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
        public static Number operator *(Vector a, Vector b)
        {
            Number resultant = 0.0;

            Parallel.For(0, a.NumRows, i =>
            {
                resultant += a[i]*b[i];
            });
            return resultant;
        }

        /// <summary>
        /// Scale down a vector
        /// </summary>
        /// <param name="v"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Vector operator /(Vector v, Number n)
        {
            Vector resultant = new Vector(v.NumRows);
            Parallel.For(0, v.NumRows, i =>
            {
                resultant[i] = v[i]/n;
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
            Parallel.For(0, NumRows, i =>
            {
                if (matrix[i][0] > max)
                {
                    max = matrix[i][0];
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
                resultant += (number1[i]*matrix[i][0]);
            });

            return resultant;
        }

        /// <summary>
        /// Row * Vector is a matrix
        /// </summary>
        /// <param name="r"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Matrix operator *(Vector v, RowVector r)
        {
            Matrix m = new Matrix(v.NumRows, r.NumCols);
            Parallel.For(0, v.NumRows, i =>
            {
                for (int j = 0; j < r.NumCols; j++)
                {
                    m[i][j] = r[i]*v[j];
                }
            });

            return m;
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
        /// Transposing a Column Vector should give a Row vector
        /// </summary>
        /// <returns></returns>
        public new RowVector Transpose()
        {
            RowVector r = new RowVector(NumRows);
            Parallel.For(0, NumRows, i =>
            {
                r[i] = matrix[i][0];
            });
            return r;
        }

        /// <summary>
        /// Returns a unit vector 
        /// </summary>
        /// <returns></returns>
        public Vector UnitVector()
        {
            return this / Magnitude();
        }

        public Number Magnitude()
        {
            Number magnitude = 0.0;
            Parallel.For(0, NumRows, i =>
            {
                magnitude += matrix[i][0]*matrix[i][0];
            });
            magnitude = Math.Sqrt(magnitude);
            return magnitude;
        }
    }
}

