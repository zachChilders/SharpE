using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpe
{
    /// <summary>
    /// An Identity Matrix class for convenience.
    /// </summary>
    public class IdentityMatrix : Matrix
    {
        /// <summary>
        /// Creates an NxN Identity Matrix
        /// </summary>
        /// <param name="n">Number of dimensions.</param>
        public IdentityMatrix(int n) : base(n, n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        this[i][j] = 1.0;
                    }
                }
            }
        }
    }
}
