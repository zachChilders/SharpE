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
        private Matrix deflatedMatrix;
        private Vector eigenVector;
        private Number eigenValue { get; set; }

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
                throw new InvalidOperationException("Matrices must be square to calculate Eigen Value.");
            }
            origMatrix = m;
            deflatedMatrix = origMatrix;
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
                throw new InvalidOperationException("Unitialized matrix given.");
            }

            Vector dominantVector = new Vector(origMatrix.NumRows);
            for (int i = 0; i < origMatrix.NumRows; i++)
            {
                dominantVector[i] = 0;
            }
            dominantVector[0] = 1;

            Double percentError = 0.0;

            Number lastNumerator = (deflatedMatrix * dominantVector) * (deflatedMatrix * dominantVector);
            Number lastDenominator = dominantVector * dominantVector;
            Number lastApproximation = Math.Sqrt(lastNumerator / lastDenominator);

            Number numerator;
            Number denominator;
            Number approximation;
            int iterations = 0;
            while (Math.Abs(percentError - 1.0) > epsilon)
            {
                dominantVector = deflatedMatrix * dominantVector;
                dominantVector /= dominantVector.MaxElement(); //Scaling

                //Eigenvalue approximation to figure out when to stop.
                numerator = (deflatedMatrix * dominantVector) * (deflatedMatrix * dominantVector);
                denominator = dominantVector * dominantVector;
                approximation = Math.Sqrt(numerator / denominator);

                //Calculate percent error
                percentError = lastApproximation / approximation;
                lastApproximation = approximation;
               
            }

           
            //Repeat for n vectors
            eigenVector = dominantVector;

            CalculateEigenValue();

            //Deflate 
            Vector U = eigenVector.UnitVector();
            RowVector Ut = eigenVector.UnitVector().Transpose();
            deflatedMatrix = deflatedMatrix - ((U *  Ut) * GetEigenValue());

            return dominantVector;
        }

        /// <summary>
        /// Computes the Raleigh quotient
        /// </summary>
        /// <returns></returns>
        private void CalculateEigenValue()
        {
            if (eigenVector == null)
            {
                GetEigenVector();
            }
            Vector tmp = origMatrix * eigenVector;
            Number numerator = tmp * eigenVector;
            Number denominator = eigenVector * eigenVector;
            eigenValue = (numerator / denominator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Number GetEigenValue()
        {
            return eigenValue;
        }

    }
}
