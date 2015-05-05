using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpe.Matrix
{
    /// <summary>
    /// A class representing a rectangular matrix.
    /// </summary>
    public partial class Matrix
    {
        private List<RowVector> matrix;

        /// <summary>
        /// Number of Rows.
        /// </summary>
        public int NumRows
        {
            get;
            private set;
        }
        /// <summary>
        /// Number of Columns.
        /// </summary>
        public int NumCols
        {
            get;
            private set;
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
            matrix = new List<RowVector>(m);
            Parallel.For(0, NumRows, i =>
            {
                RowVector r = new RowVector(NumCols);
                matrix.Add(r);
            });
        }

        /// <summary>
        /// Copy data[] into matrix form.  Must specify the width of rows.
        /// 
        /// This works, but should pad instead of cut off.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rowWidth"></param>
        public Matrix(int[] data, int rowWidth)
        {
            NumRows = data.Length / rowWidth;
            NumCols = rowWidth;
            matrix = new List<RowVector>(NumRows);
            for(int i = 0; i < NumRows; i++)
            {
                RowVector r = new RowVector(NumCols);
                for (int j = 0; j < NumCols; j++)
                {
                    r[j] = data[i * NumCols + j];
                }
                matrix.Add(r);
            }
        }

        /// <summary>
        /// Copy data[] into matrix form.  Must specify the width of rows.
        /// 
        /// This works, but should pad instead of cut off.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rowWidth"></param>
        public Matrix(Double[] data, int rowWidth)
        {
            NumRows = data.Length / rowWidth;
            NumCols = rowWidth;
            matrix = new List<RowVector>(NumRows);
            for (int i = 0; i < NumRows; i++)
            {
                RowVector r = new RowVector(NumCols);
                for (int j = 0; j < NumCols; j++)
                {
                    r[j] = data[i * NumCols + j];
                }
                matrix.Add(r);
            }
        }

        /// <summary>
        /// Copy data[] into matrix form.  Must specify the width of rows.
        /// 
        /// This works, but should pad instead of cut off.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rowWidth"></param>
        public Matrix(float[] data, int rowWidth)
        {
            NumRows = data.Length / rowWidth;
            NumCols = rowWidth;
            matrix = new List<RowVector>(NumRows);
            for (int i = 0; i < NumRows; i++)
            {
                RowVector r = new RowVector(NumCols);
                for (int j = 0; j < NumCols; j++)
                {
                    r[j] = data[i * NumCols + j];
                }
                matrix.Add(r);
            }
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public void Append(Vector v)
        {
            Parallel.For(0, v.Size, i =>
            {
                matrix[i].Append(v[i]);
            });
            NumCols++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        public void Append(RowVector r)
        {
            matrix.Add(r);
            NumRows++;
        }

        public void Append(Matrix m)
        {
            for (int i = 0; i < m.NumRows; i++)
            {
                matrix.Add(m[i]);
            }
            NumRows += m.NumRows;
        }

        public void ColumnAppend(Matrix m)
        {
            Parallel.For(0, m.NumRows, i =>
            {
                matrix[i].Append(m[i]);
            });

            NumCols += m.NumCols;
        }

        ///// <summary>
        ///// Directly Copy a 2D array into a Matrix. This may need
        ///// to be overloaded for each copy.
        ///// </summary>
        ///// <param name="data"></param>
        //public Matrix(Number[][] data)
        //{
        //    matrix = new Number[data.Length][];
        //    Parallel.For(0, NumRows, i =>
        //    {
        //        matrix[i] = new Number[data[i].Length];
        //        for (int j = 0; j < data[i].Length; j++)
        //        {
        //            matrix[i][j] = data[i][j];
        //        }
        //    });
        //}

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

    }
}
