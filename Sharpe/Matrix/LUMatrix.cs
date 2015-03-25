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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public LUMatrix(Matrix m)
        {
            Matrix U = new Matrix(m.NumRows, m.NumCols);
            Console.WriteLine(m.ToString());
            //Begin a Decomposition.
            Queue<Number> Lower = new Queue<Number>();

            //Copy the first row, it remains unchanged
            U[0] = m[0];
            for (int i = 1; i < m.NumRows; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    //Get the number we're supposed to scale by
                    Number scalar = m[i][j] / m[i - 1][j];
                     //Enqueue the number for later use
                    Lower.Enqueue(scalar);
                    //Perform the scale  
                    Number[] scaled = Matrix.Scale(m[i - 1], scalar);
                    //Subtract
                    U[i] = Matrix.RowSubtract(m[i], scaled);
                }
            }

            for (int j = 0; j < m.NumCols; j++)
            {
                //Get the number we're supposed to scale by
                Number scalar = m[m.NumRows - 1][j] / m[m.NumRows - 2][j];
                //Enqueue the number for later use
                Lower.Enqueue(scalar);
                //Perform the scale  
                Number[] scaled = Matrix.Scale(m[m.NumRows - 2], scalar);
                //Subtract
                U[m.NumRows - 1] = Matrix.RowSubtract(m[m.NumRows - 1], scaled);
            }

            Console.Read();
            Console.WriteLine(U.ToString());

            Matrix L = new IdentityMatrix(m.NumRows);
            //int count = 1;
            //while (Lower.Count > 0)
            //{
            //    L[count+1][count] = Lower.Dequeue();
            //    count++;
            //}

            LU = Tuple.Create<Matrix, Matrix>(L, U);
            Console.Read();
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
    }
}
