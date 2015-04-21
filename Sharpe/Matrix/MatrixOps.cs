using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpe.Numbers;

namespace Sharpe.Matrix
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
        /// Scales a set of numbers by a scalar.
        /// </summary>
        /// <param name="Vector">A Row, Column, or Vector.</param>
        /// <param name="Scalar">A scale factor.</param>
        /// <returns>The scaled vector</returns>
        public static Number[] Scale(Number[] Vector, Number Scalar)
        {
            Number[] resultant = new Number[Vector.Length];
            for (int i = 0; i < Vector.Length; i++)
            {
                resultant [i] = Vector[i] * Scalar;
            }
            return resultant;
        }

        /// <summary>
        /// Subtracts Row2 from Row1.
        /// </summary>
        /// <param name="Row1">A row, column, or Vector</param>
        /// <param name="Row2">A row, column, or Vector</param>
        /// <returns>Row2 - Row1.</returns>
        public static Number[] RowSubtract(Number[] Row1, Number[] Row2)
        {
            if (Row1.Length != Row2.Length)
            {
                throw new InvalidOperationException();
            }
            Number[] resultant = new Number[Row1.Length];
            for (int i = 0; i < Row1.Length; i++)
            {
                resultant[i] = Row1[i] - Row2[i];
            }
            return resultant;
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
        /// Sets a column to an array of numbers
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        public void SetColumn(Number[] data, int index)
        {
            if (data.Length != NumRows)
            {
                throw new InvalidOperationException();
            }
            for (int i = 0; i < NumRows; i++)
            {
                matrix[index][i] = data[i];
            }
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
