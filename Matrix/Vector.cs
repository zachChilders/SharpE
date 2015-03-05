using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpe
{
    /// <summary>
    /// An n-Dimensional Vector
    /// </summary>
    public class Vector : Matrix
    {
        /// <summary>
        /// Creates an n-Dimensional Vector.
        /// </summary>
        /// <param name="n">Number of dimensions.</param>
        public Vector(int n) : base(n, 1)
        {}
    }
}

