using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpe
{
    public class Matrix
    {
        private Number[][] matrix;

        public int NumRows
        {
            get;
            set;
        }
        public int NumCols
        {
            get;
            set;
        }

        /// <summary>
        /// Basic Constructor.  Makes m x n Matrix
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        public Matrix(int m, int n)
        {
            NumRows = m;
            NumCols = n;
            matrix = new Number[NumRows][];
            for (int i = 0; i < NumRows; i++)
            {
                matrix[i] = new Number[NumCols];
                for (int j = 0; j < NumCols; j++)
                {
                    matrix[i][j] = 0.0;
                }
            }
        }

        /// <summary>
        /// Copy data[] into matrix form.  Must specify the width of rows.
        /// 
        /// This works, but should pad instead of cut off.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rowWidth"></param>
        public Matrix(int[] data, int RowWidth)
        {
            NumRows = data.Length / RowWidth;
            NumCols = RowWidth;
            matrix = new Number[NumRows][];
            for (int i = 0; i < NumRows; i++)
            {
                matrix[i] = new Number[NumCols];
                for (int j = 0; j < NumCols; j++)
                {
                    matrix[i][j] = data[i * NumCols + j];
                }
            }
        }

        /// <summary>
        /// Copy data[] into matrix form.  Must specify the width of rows.
        /// 
        /// This works, but should pad instead of cut off.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rowWidth"></param>
        public Matrix(Double[] data, int RowWidth)
        {
            NumRows = data.Length / RowWidth;
            NumCols = RowWidth;
            matrix = new Number[NumRows][];
            for (int i = 0; i < NumRows; i++)
            {
                matrix[i] = new Number[NumCols];
                for (int j = 0; j < NumCols; j++)
                {
                    matrix[i][j] = data[i * NumCols + j];
                }
            }
        }

        /// <summary>
        /// Copy data[] into matrix form.  Must specify the width of rows.
        /// 
        /// This works, but should pad instead of cut off.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rowWidth"></param>
        public Matrix(float[] data, int RowWidth)
        {
            NumRows = data.Length / RowWidth;
            NumCols = RowWidth;
            matrix = new Number[NumRows][];
            for (int i = 0; i < NumRows; i++)
            {
                matrix[i] = new Number[NumCols];
                for (int j = 0; j < NumCols; j++)
                {
                    matrix[i][j] = data[i * NumCols + j];
                }
            }
        }

        /// <summary>
        /// Directly Copy a 2D array into a Matrix. This may need
        /// to be overloaded for each copy.
        /// </summary>
        /// <param name="data"></param>
        public Matrix(Number[][] data)
        {
            matrix = new Number[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                matrix[i] = new Number[data[i].Length];
                for (int j = 0; j < data[i].Length; j++)
                {
                    matrix[i][j] = data[i][j];
                }
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

        /// <summary>
        /// Allows Printing in Pretty Form
        /// </summary>
        /// <returns></returns>
        public new String ToString()
        {
            StringBuilder ts = new StringBuilder();
            for (int i = 0; i < NumRows; i++)
            {
                for (int j = 0; j < NumCols; j++)
                {
                    ts.Append(matrix[i][j].ToString());
                    ts.Append(" ");
                }
                ts.Append("\n");
            }

            return ts.ToString();
        }

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
                throw new InvalidOperationException(); ///Maybe this should be custom
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
                throw new InvalidOperationException(); ///Maybe this should be custom
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
        /// Transposes the matrix
        /// </summary>
        /// <returns></returns>
        public Matrix Transpose()
        {
            Matrix t = new Matrix(NumCols, NumRows);
            for (int i = 0; i < NumRows; i++)
            {
                t[i] = this.GetColumn(i);
            }

            return t;
        }

        /// <summary>
        /// Returns the Determinant of our matrix.
        /// </summary>
        /// <returns></returns>
        public Number Determinant()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the Main Diagonal of the matrix
        /// </summary>
        /// <returns></returns>
        public Number[] Diagonal()
        {
            List<Number> diag = new List<Number>();
            for (int i = 0; i < NumRows; i++)
            {
                for (int j = 0; j < NumCols; j++)
                {
                    if (i == j)
                    {
                        diag.Add(matrix[i][j]);
                    }
                }
            }
            return diag.ToArray();
        }

        /// <summary>
        /// Returns a Diagonalized Matrix
        /// </summary>
        /// <returns></returns>
        public Matrix Diagonalize()
        {
            Matrix diagonalized = new Matrix(NumRows, NumCols);
            for (int i =0; i < NumRows; i++)
            {
                for (int j = 0; j < NumCols; j++)
                {
                    if (i == j)
                    {
                        diagonalized[i][j] = matrix[i][j];
                    }
                }
            }
            return diagonalized;
        }
    }
}
