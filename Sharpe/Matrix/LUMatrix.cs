using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpe.Numbers;

namespace Sharpe.Matrix
{
    /// <summary>
    /// Lower Upper Matrix class for decomposition
    /// </summary>
    public class LUMatrix
    {
        private Tuple<Matrix, Matrix> LU;

        //This is used for 
        private IdentityMatrix id;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public LUMatrix(Matrix m)
        {
            id = new IdentityMatrix(m.NumRows);

            Matrix U = new Matrix(m.NumRows, m.NumCols);
            //Begin a Decomposition.
            Queue<Number> lower = new Queue<Number>();
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
                        lower.Enqueue(scalar);
                        //Perform the scale  
                        scaled = Matrix.Scale(U[i - 1], scalar);

                        U[i] = Matrix.RowSubtract(U[i], scaled);
                    }

                    else
                    {
                        scalar = m[i][j] / m[0][j];
                        //Enqueue the number for later use
                        lower.Enqueue(scalar);
                        //Perform the scale  
                        scaled = Matrix.Scale(m[0], scalar);

                        U[i] = Matrix.RowSubtract(m[i], scaled);
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
                        L[i][j] = lower.Dequeue();
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
            throw new NotImplementedException();
            //L Z = C
            //U X = Z
            IdentityMatrix B = new IdentityMatrix(id.NumCols);
            for (int i = 0; i < id.NumCols; i++)
            {

                //L * z = C
                //U * C = B
                for (int j = 0; j < id.NumCols; j++)
                {
                    
                }
            }
            return id;
        }

    }
}
