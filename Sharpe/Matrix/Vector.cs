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
    public class Vector
    {
        protected List<Number> v;

        public int Size
        {
            get { return v.Count; }
        }
        /// <summary>
        /// Creates an n-Dimensional Vector.
        /// </summary>
        /// <param name="n">Number of dimensions.</param>
        public Vector(int n)
        {
            v = new List<Number>();
            for (int i = 0; i < n; i++)
            {
                v.Add(0);
            }
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public Vector(int[] array)
        {
            v = new List<Number>(array.Length);
            Parallel.For(0, array.Length, i =>
            {
                v.Insert(i, array[i]);
            });
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public Vector(Double[] array)
        {
            v = new List<Number>(array.Length);
            Parallel.For(0, array.Length, i =>
            {
                v.Insert(i, array[i]);
            });
        }


        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public Vector(Byte[] array)
        {
            v = new List<Number>(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                v.Insert(i, array[i]);
            }
        }


        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public Vector(float[] array)
        {
            v = new List<Number>(array.Length);
            Parallel.For(0, array.Length, i =>
            {
                v.Insert(i, array[i]);
            });
        }

        /// <summary>
        /// Constructor to make a vector from an array.
        /// </summary>
        /// <param name="array"></param>
        public Vector(Number[] array)
        {
            v = new List<Number>(array.Length);
            Parallel.For(0, array.Length, i =>
            {
                v.Insert(i, array[i]);
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
                return v[i];
            }
            set
            {
                v[i] = value;
            }
        }


        public static Vector operator -(Vector a, Vector b)
        {
            Vector resultant = new Vector(a.Size);
            Parallel.For(0, a.Size, i =>
            {
                resultant[i] = a[i] - b[i];
            });
            return resultant;
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
        public static Number operator *(Vector a, Vector b)
        {
            Number resultant = 0.0;

            Parallel.For(0, a.v.Count, i =>
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
        public static Vector operator /(Vector a, Number n)
        {
            Vector resultant = new Vector(a.v.Count);
            Parallel.For(0, a.v.Count, i =>
            {
                resultant[i] = a[i] / n;
            });
            return resultant;
        }

        /// <summary>
        /// Adds a scalar to each element in a vector.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Vector operator +(Vector a, Number n)
        {
            Vector resultant = new Vector(a.v.Count);
            Parallel.For(0, a.v.Count, i =>
            {
                resultant[i] = a[i] + n;
            });
            return resultant;
        }

        /// <summary>
        /// Subtracts a scalar from each element in a vector.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Vector operator -(Vector a, Number n)
        {
            Vector resultant = new Vector(a.v.Count);
            Parallel.For(0, a.v.Count, i =>
            {
                resultant[i] = a[i] - n;
            });
            return resultant;
        }

        /// <summary>
        /// Find the max of a vector.
        /// </summary>
        /// <returns></returns>
        public Number MaxElement()
        {
            Number max = v[0];
            Parallel.For(0, v.Count, i =>
            {
                if (v[i] > max)
                {
                    max = v[i];
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
        /// Row * Vector is a matrix
        /// </summary>
        /// <param name="r"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Matrix operator *(Vector a, RowVector r)
        {
            Matrix m = new Matrix(a.v.Count, r.Size);
            Parallel.For(0, a.v.Count, i =>
            {
                for (int j = 0; j < r.Size; j++)
                {
                    m[i][j] = r[i] * a[j];
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
        private static Number dot(Number number1, Vector number2)
        {
            Number sum = 0.0;
            for (int i = 0; i < number2.Size; i++)
            {
                sum += (number1 * number2[i]);
            }
            return sum;
        }

        /// <summary>
        /// Transposing a Column Vector should give a Row vector
        /// </summary>
        /// <returns></returns>
        public RowVector Transpose()
        {
            RowVector r = new RowVector(v.Count);
            Parallel.For(0, v.Count, i =>
            {
                r[i] = v[i];
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

        /// <summary>
        /// Calculates the magnitude of a vector.
        /// </summary>
        /// <returns></returns>
        public Number Magnitude()
        {
            Number magnitude = 0.0;
            Parallel.For(0, v.Count, i =>
            {
                magnitude += v[i] * v[i];
            });
            magnitude = Math.Sqrt(magnitude);
            return magnitude;
        }

        /// <summary>
        /// Appends a number to a column
        /// </summary>
        /// <param name="n"></param>
        public void Append(Number n)
        {
            v.Add(n);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aVector"></param>
        public void Append(Vector aVector)
        {
            for (int i = 0; i < aVector.Size; i++)
            {
                Append(aVector[i]);
            }
        }

        /// <summary>
        /// Calculates the average of a Vector.
        /// </summary>
        /// <returns></returns>
        public Number Mean()
        {
            Number sum = 0.0;
            for (int i = 0; i < v.Count; i++)
            {
                sum += v[i];
            }
            return sum/v.Count;
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
                sb.Append(v[i]);
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}

