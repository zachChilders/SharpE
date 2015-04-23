using System;
using Sharpe.Numbers;


namespace Sharpe.Matrix
{
    /// <summary>
    /// 
    /// </summary>
    public class EigenSolver
    {
        private readonly Matrix origMatrix;
        private Vector eigenVector;

        /// <summary>
        /// 
        /// </summary>
        public float EpsHighPrecision = 0.0000000000000000000000000001f;

        /// <summary>
        /// 
        /// </summary>
        public float EpsDefault = 0.000000000000001f;

        /// <summary>
        /// 
        /// </summary>
        public float EpsHighPerformace = 0.001f;

        /// <summary>
        /// A tolerance value for eigen precision.
        /// Bigger numbers give less precise eigens
        /// Smaller numbers take longer to solve.
        /// </summary>
        public Double epsilon { private get; set; }

        /// <summary>
        /// Initializes an eigensolver for a given matrix.
        /// </summary>
        /// <param name="m"></param>
        public EigenSolver(Matrix m)
        {
            if (m.NumRows != m.NumCols)
            {
                throw new InvalidOperationException("Matrices must be square to calculate eigenvalues.");
            }
            origMatrix = m;
            epsilon = EpsDefault;
        }

        /// <summary>
        /// Calculates the dominant eigenvector using 
        /// power iteration
        /// </summary>
        /// <returns></returns>
        public Vector GetEigenVector()
        {
            if (origMatrix == null)
            {
                throw new InvalidOperationException();
            }

            Vector eigenValues = new Vector(origMatrix.NumRows);
            for (int i = 0; i < origMatrix.NumRows; i++)
            {
                eigenValues[i] = 1;
            }

            Double percentError = 0.0;

            Number lastNumerator = (origMatrix * eigenValues) * (origMatrix * eigenValues);
            Number lastDenominator = eigenValues * eigenValues;
            Number lastApproximation = Math.Sqrt(lastNumerator / lastDenominator);

            Number numerator;
            Number denominator;
            Number approximation;

            while (Math.Abs(percentError - 1.0) > epsilon)
            {
                eigenValues = origMatrix * eigenValues;
                eigenValues /= eigenValues.MaxElement(); //Scaling

                //Eigenvalue approximation to figure out when to stop.
                numerator = (origMatrix * eigenValues) * (origMatrix * eigenValues);
                denominator = eigenValues * eigenValues;
                approximation = Math.Sqrt(numerator / denominator);

                //Calculate percent error
                percentError = lastApproximation / approximation;
                lastApproximation = approximation;
            }

            //Repeat for n vectors
            eigenVector = eigenValues;
            return eigenValues;
        }

        /// <summary>
        /// Computes the Raleigh quotient
        /// </summary>
        /// <returns></returns>
        public Number GetEigenValue()
        {
            if (eigenVector == null)
            {
                GetEigenVector();
            }
            Vector tmp = origMatrix * eigenVector;
            Number numerator = tmp * eigenVector;
            Number denominator = eigenVector * eigenVector;
            return (numerator / denominator);
        }
    }
}
