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
        public Vector(int n) : base(n, 1)
        {}

        /// <summary>
        /// Allows for [][] indexing of matrices. Must be 0 based.
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Matrix Row i</returns>
        public new Number this[int i]
        {
            get
            {
                return this.matrix[i][0];
            }
            set
            {
                this.matrix[i][0] = value;
            }
        }

        /// <summary>
        /// Multiplies two matrices, if possible.  
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Vector operator *(Matrix A, Vector B)
        {

            Vector resultant = new Vector(A.NumRows);

            for (int i = 0; i < A.NumRows; i++)
            {
                resultant[i] = B.dot(A[i]);
            }

            return resultant;
        }

        public static Vector operator *(Vector B, Matrix A)
        {

            Vector resultant = new Vector(A.NumRows);

            for (int i = 0; i < A.NumRows; i++)
            {
                resultant[i] = dot(B[i], A[i]);
            }

            return resultant;
        }

        public static Number operator *(Vector A, Vector B)
        {
            Number resultant = 0.0;

            for (int i = 0; i < A.NumRows; i++)
            {
                resultant += A[i]*B[i];
            }
            return resultant;
        }

        public static Vector operator /(Vector V, Number n)
        {
            Vector resultant = new Vector(V.NumRows);
            for (int i = 0; i < V.NumRows; i++)
            {
                resultant[i] = V[i]/n;
            }
            return resultant;
        }

        public Number maxElement()
        {
            Number max = matrix[0][0];
            for (int i = 1; i < this.NumRows; i++)
            {
                if (matrix[i][0] > max)
                {
                    max = matrix[i][0];
                }
            }
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
            for (int i = 0; i < number1.Length; i++)
            {
                resultant += (number1[i] * this.matrix[i][0]);
            }

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
            Number resultant = 0.0;
            for (int i = 0; i < number2.Length; i++)
            {
                resultant += (number2[i] * number1);
            }

            return resultant;
        }
    }
}

