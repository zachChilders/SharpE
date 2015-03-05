using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpe
{
    public partial class Matrix
    {
        /// <summary>
        /// Adds two matrices.  Throws Invalid Exception if sizes aren't equal.
        /// </summary>
        /// <param name="A">First Matrix</param>
        /// <param name="B">Second Matrx</param>
        /// <returns>Resultant Matrix </returns>
        public static Matrix operator +(Matrix A, Matrix B)
        {
            //Check to make sure the operation is allowed first.
            if ((A.NumRows != B.NumRows) || (A.NumCols != A.NumCols))
            {
                throw new InvalidOperationException(); //Maybe this should be custom
            }
            Matrix resultant = new Matrix(A.NumRows, B.NumCols);
            for (int i = 0; i < A.NumCols; i++)
            {
                for (int j = 0; j < A.NumRows; j++)
                {
                    resultant[i][j] = A[i][j] + B[i][j];
                }
            }

            return resultant;
        }

        /// <summary>
        /// Subtracts two matrices.  Throws Invalid Exception if sizes aren't equal.
        /// </summary>
        /// <param name="A">First Matrix</param>
        /// <param name="B">Second Matrx</param>
        /// <returns>Resultant Matrix </returns>
        public static Matrix operator -(Matrix A, Matrix B)
        {
            //Check to make sure the operation is allowed first.
            if ((A.NumRows != B.NumRows) || (A.NumCols != A.NumCols))
            {
                throw new InvalidOperationException(); //Maybe this should be custom
            }
            Matrix resultant = new Matrix(A.NumRows, B.NumCols);
            for (int i = 0; i < A.NumCols; i++)
            {
                for (int j = 0; j < A.NumRows; j++)
                {
                    resultant[i][j] = A[i][j] - B[i][j];
                }
            }

            return resultant;
        }

        /// <summary>
        /// Multiply by a scalar.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix A, Number B)
        {
            Matrix resultant = new Matrix(A.NumRows, A.NumCols);
            for (int i = 0; i < A.NumRows; i++)
            {
                for (int j = 0; j < A.NumCols; j++)
                {
                    resultant[i][j] = A[i][j] * B;
                }
            }

            return resultant;
        }

        /// <summary>
        /// Multiplies two matrices, if possible.  
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.NumCols != B.NumRows)
            {
                throw new InvalidOperationException();
            }

            Matrix resultant = new Matrix(A.NumRows, B.NumCols);

            for (int i = 0; i < A.NumRows; i++)
            {
                for (int j = 0; j < B.NumCols; j++)
                {
                    resultant[i][j] = dot(A[i], B.GetColumn(j));
                }
            }

            return resultant;
        }

        /// <summary>
        /// Multiplication overloaded to accept a standard Vector.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix A, Vector B)
        {
            Matrix resultant = new Matrix(A.NumRows, A.NumCols);

            for (int i = 0; i < A.NumRows; i++)
            {
                for (int j = 0; j < B.NumCols; j++)
                {
                    resultant[i][j] = dot(A[i], B[j]);
                }
            }

            return resultant;
        }

        /// <summary>
        /// Essentially a dot product
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Number dot(Number[] A, Number[] B)
        {
            Number sum = 0.0;
            for (int i = 0; i < A.Length; i++)
            {
                sum += A[i] * B[i];
            }
            return sum;
        }

        /// <summary>
        /// Returns a column at given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Number[] GetColumn(int index)
        {
            Number[] column = new Number[NumRows];
            for (int i = 0; i < NumRows; i++)
            {
                column[i] = matrix[i][index];
            }
            return column;
        }

        /// <summary>
        /// Allows for [][] indexing of matrices. Must be 0 based.
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Matrix Row i</returns>
        public Number[] this[int i]
        {
            get
            {
                return matrix[i];
            }
            set
            {
                matrix[i] = value;
            }
        }
    }
}
