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
        /// <param name="a">First Matrix</param>
        /// <param name="b">Second Matrx</param>
        /// <returns>Resultant Matrix </returns>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            //Check to make sure the operation is allowed first.
            if ((a.NumRows != b.NumRows) || (a.NumCols != b.NumCols))
            {
                throw new InvalidOperationException(); //Maybe this should be custom
            }
            Matrix resultant = new Matrix(a.NumRows, b.NumCols);
            Parallel.For(0, a.NumCols, i =>
            {
                for (int j = 0; j < a.NumRows; j++)
                {
                    resultant[i][j] = a[i][j] + b[i][j];
                }
            });

            return resultant;
        }

        /// <summary>
        /// Subtracts two matrices.  Throws Invalid Exception if sizes aren't equal.
        /// </summary>
        /// <param name="a">First Matrix</param>
        /// <param name="b">Second Matrx</param>
        /// <returns>Resultant Matrix </returns>
        public static Matrix operator -(Matrix a, Matrix b)
        {
            //Check to make sure the operation is allowed first.
            if ((a.NumRows != b.NumRows) || (a.NumCols != b.NumCols))
            {
                throw new InvalidOperationException(); //Maybe this should be custom
            }
            Matrix resultant = new Matrix(a.NumRows, b.NumCols);
            Parallel.For(0, a.NumCols, i =>
            {
                for (int j = 0; j < a.NumRows; j++)
                {
                    resultant[i][j] = a[i][j] - b[i][j];
                }
            });

            return resultant;
        }

        /// <summary>
        /// Multiply by a scalar.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix a, Number b)
        {
            Matrix resultant = new Matrix(a.NumRows, a.NumCols);
            Parallel.For(0, a.NumRows, i =>
            {
                for (int j = 0; j < a.NumCols; j++)
                {
                    resultant[i][j] = a[i][j]*b;
                }
            });

            return resultant;
        }

        /// <summary>
        /// Multiplies two matrices, if possible.  
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.NumCols != b.NumRows)
            {
                throw new InvalidOperationException();
            }

            Matrix resultant = new Matrix(a.NumRows, b.NumCols);

            Parallel.For(0, a.NumRows, i =>
            {
                for (int j = 0; j < b.NumCols; j++)
                {
                    resultant[i][j] = Dot(a[i], b.GetColumn(j));
                }
            });

            return resultant;
        }



        /// <summary>
        /// Essentially a dot product
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Number Dot(Number[] a, Number[] b)
        {
            Number sum = 0.0;
            Parallel.For(0, a.Length, i =>
            {
                sum += a[i] * b[i];
            }
            );
            return sum;
        }

        /// <summary>
        /// Scales a set of numbers by a scalar.
        /// </summary>
        /// <param name="vector">A Row, Column, or Vector.</param>
        /// <param name="scalar">A scale factor.</param>
        /// <returns>The scaled vector</returns>
        public static Number[] Scale(Number[] vector, Number scalar)
        {
            Number[] resultant = new Number[vector.Length];
            Parallel.For(0, vector.Length, i =>
            {
                resultant[i] = vector[i]*scalar;
            });
            return resultant;
        }

        /// <summary>
        /// Subtracts Row2 from Row1.
        /// </summary>
        /// <param name="row1">A row, column, or Vector</param>
        /// <param name="row2">A row, column, or Vector</param>
        /// <returns>Row2 - Row1.</returns>
        public static Number[] RowSubtract(Number[] row1, Number[] row2)
        {
            if (row1.Length != row2.Length)
            {
                throw new InvalidOperationException();
            }
            Number[] resultant = new Number[row1.Length];
            Parallel.For(0, row1.Length, i =>
            {
                resultant[i] = row1[i] - row2[i];
            });
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
            Parallel.For(0, NumRows, i =>
            {
                column[i] = matrix[i][index];
            });
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
            Parallel.For(0, NumRows, i =>
            {
                matrix[index][i] = data[i];
            });
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
