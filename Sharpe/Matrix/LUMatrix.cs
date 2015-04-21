using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpe.Numbers;

namespace Sharpe.Matrix
{
    /// <summary>
    /// lowerQueue Upper Matrix class for decomposition
    /// </summary>
    public class LUMatrix
    {
        private Tuple<Matrix, Matrix> LU;

        //This is used for 
        private IdentityMatrix id;

        private Queue<Number> lowerQueue = new Queue<Number>();
        private Stack<Number> upperStack = new Stack<Number>(); 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public LUMatrix(Matrix m)
        {
            id = new IdentityMatrix(m.NumRows);

            Matrix U = new Matrix(m.NumRows, m.NumCols);
            //Begin a Decomposition.
            //Copy the first row, it remains unchanged
            U[0] = m[0];
            for (int i = 1; i < m.NumRows; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    //Get the number we're supposed to scale by
                    Number scalar = null;
                    Number[] scaled = null;

                    if (j > 0)
                    {
                        scalar = U[i][j] / U[i - 1][j];

                        //Enqueue the number for later use
                        lowerQueue.Enqueue(scalar);
                        //Perform the scale  
                        scaled = Matrix.Scale(U[i - 1], scalar);

                        U[i] = Matrix.RowSubtract(U[i], scaled);
                    }

                    else
                    {
                        scalar = m[i][j] / m[0][j];
                        //Enqueue the number for later use
                        lowerQueue.Enqueue(scalar);
                        //Perform the scale  
                        scaled = Matrix.Scale(m[0], scalar);
                        U[i] = Matrix.RowSubtract(m[i], scaled);
                    }

                }
                for (int j = 0; j < m.NumRows; j++)
                {
                    if (j > i)
                    {
                        upperStack.Push(U[i][j]);
                    }
                }
            }

            Matrix L = new IdentityMatrix(m.NumRows);

            for (int i = 0; i < m.NumRows; i ++)
            {
                for (int j = 0; j < m.NumCols; j++)
                {
                    if (j < i)
                    {
                        L[i][j] = lowerQueue.Dequeue();
                        lowerQueue.Enqueue(L[i][j]);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            LU = Tuple.Create(L, U);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Matrix GetUpper()
        {
            return LU.Item2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Matrix GetLower()
        {
            return LU.Item1;
        }

        /// <summary>
        /// Calculate the determinant of the matrix
        /// </summary>
        /// <returns>The determinant</returns>
        public Number Determinant()
        {
            Number[] diagonal = LU.Item2.Diagonal();
            return diagonal.Aggregate<Number, Number>(1.0, (current, n) => current*n);
        }

        /// <summary>
        /// Generate the Inverse of a matrix
        /// </summary>
        /// <returns></returns>
        public Matrix Inverse()
        {
            //L d = b
            //U x = d
            IdentityMatrix Identity = new IdentityMatrix(id.NumCols);
            for (int i = 0; i < id.NumCols; i++)
            {
                //The current column in the Identity Matrix
                Number[] b = Identity.GetColumn(i);

                //Unknowns we need to solve for.
                Number[] d = new Number[b.Length];
                Number[] x = new Number[b.Length];

                //Forward Substitution
                d[0] = b[0];
                for (int j = 1; j < id.NumRows; j++)
                {
                    d[j] = b[j];
                    for (int k = 1; k < j; k++)
                    {
                        d[j] -= d[j - k] * lowerQueue.Dequeue();
                    }
                }

                //Backward Substitution
                x[id.NumRows - 1] = d[id.NumRows - 1] / upperStack.Pop();
                for (int j = id.NumRows - 1; j >= 0; j--)
                {
                    b[j] = x[j];
                    for (int k = 1; k < j; k++)
                    {
                        b[j] -= x[id.NumRows - k];
                    }

                }
            }
            return id;
        }

    }
}
