﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpe.Numbers;
using Sharpe.Support;

namespace Sharpe.Matrix
{
    /// <summary>
    /// lowerQueue Upper Matrix class for decomposition
    /// </summary>
    public class LUMatrix
    {
        private Tuple<Matrix, Matrix> LU;

        //This is used for Inverting the matrix.
        private IdentityMatrix id;

        private CircularQueue<Number> lowerQueue = new CircularQueue<Number>();
        private CircularStack<Number> upperStack = new CircularStack<Number>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public LUMatrix(Matrix m)
        {
            id = new IdentityMatrix(m.NumRows);

            Matrix u = new Matrix(m.NumRows, m.NumCols);
            //Begin a Decomposition.
            //Copy the first row, it remains unchanged
            u[0] = m[0];

            for (int i = 1; i < m.NumRows; i++)
            {
                //Get the number we're supposed to scale by
                Number scalar;
                RowVector scaled = new RowVector(m.NumCols);
                RowVector subtracted = new RowVector(m.NumCols);
                for (int j = 0; j < i; j++)
                {

                    if (j > 0)
                    {
                        scalar = u[i][j] / u[i - 1][j];

                        //Enqueue the number for later use
                        lowerQueue.Enqueue(scalar);
                        //Perform the scale  
                        scaled = scalar * u[i - 1];
                        subtracted = u[i] - scaled;
                    }

                    else
                    {
                        scalar = m[i][j] / m[0][j];
                        //Enqueue the number for later use
                        lowerQueue.Enqueue(scalar);
                        //Perform the scale  
                        scaled = m[0] * scalar;
                        subtracted = m[i] - scaled;
                    }

                    u[i] = subtracted;
                }
            }
            for (int i = 0; i < m.NumRows; i++)
            {
                for (int j = 0; j < m.NumCols; j++)
                {
                    if (u[i][j] != 0.0)
                        upperStack.Push(u[i][j]);
                }
            }

            Matrix l = new IdentityMatrix(m.NumRows);

            for (int i = 0; i < m.NumRows; i++)
            {
                for (int j = 0; j < m.NumCols; j++)
                {
                    if (j < i)
                    {
                        l[i][j] = lowerQueue.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            lowerQueue.Reset();

            LU = Tuple.Create(l, u);
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
            return diagonal.Aggregate<Number, Number>(1.0, (current, n) => current * n);
        }

        /// <summary>
        /// Generate the Inverse of a matrix
        /// </summary>
        /// <returns></returns>
        public Matrix Inverse()
        {
            //L d = b
            //U x = d
            IdentityMatrix identity = new IdentityMatrix(id.NumCols);
            for (int i = 0; i < id.NumCols; i++)
            {
                //The current column in the Identity Matrix
                Vector b = identity.GetColumn(i);

                //Unknowns we need to solve for.
                Number[] d = new Number[b.Size];
                Number[] x = new Number[b.Size];

                Number tmp;

                //Forward Substitution
                d[0] = b[0];
                for (int j = 1; j < id.NumRows; j++)
                {
                    d[j] = b[j];
                    for (int k = 1; k <= j; k++)
                    {
                        tmp = lowerQueue.Dequeue();
                        d[j] -= d[j - k] * tmp;
                    }
                }

                //Backward Substitution
                for (int j = id.NumRows - 1; j >= 0; j--)
                {
                    x[j] = d[j];
                    for (int k = j; k < id.NumRows - 1; k++)
                    {
                        tmp = upperStack.Pop();
                        x[j] -= tmp * x[k];
                    }
                    tmp = upperStack.Pop();
                    b[j] = x[j] / tmp;
                }

                id.SetColumn(b, i);
                upperStack.Reset();
                lowerQueue.Reset();
            }

            return id;
        }

    }
}
