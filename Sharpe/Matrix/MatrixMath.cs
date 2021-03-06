﻿using System;
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
        /// Rewrites Columns as Rows.
        /// </summary>
        /// <returns>Transposed Matrix</returns>
        public Matrix Transpose()
        {
            Matrix t = new Matrix();
            for(int i = 0; i < NumCols; i++)
            {
                t.Append(GetColumn(i).Transpose());
            };

            return t;
        }

        ///// <summary>
        ///// Calculate the Determinant of a matrix.
        ///// </summary>
        ///// <returns>The Determinant</returns>
        //public Number Determinant()
        //{
        //    LUMatrix lu = new LUMatrix(this);
        //    return lu.Determinant();
        //}

        /// <summary>
        /// Returns the Main Diagonal of the matrix.
        /// </summary>
        /// <returns>An array of Numbers along the Diagonal.</returns>
        public Number[] Diagonal()
        {
            List<Number> diag = new List<Number>();
            Parallel.For(0, NumRows, i =>
            {
                for (int j = 0; j < NumCols; j++)
                {
                    if (i == j)
                    {
                        diag.Add(matrix[i][j]);
                    }
                }
            });
            return diag.ToArray();
        }

        /// <summary>
        /// Sets every number not on the Main Diagonal of a matrix to zero.
        /// </summary>
        /// <returns>The Diagonalized matrix.</returns>
        public Matrix Diagonalize()
        {
            Matrix diagonalized = new Matrix(NumRows, NumCols);
            for (int i = 0; i < NumRows; i++)
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
