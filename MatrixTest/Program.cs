using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpe.Matrix;
using Sharpe.Numbers;

namespace MatrixTest
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Identity Matrix");
            IdentityMatrix idMatrix = new IdentityMatrix(3);
            Console.WriteLine(idMatrix.ToString());

            Console.WriteLine("Creating 3x3 Double Matrix");
            Matrix zeroMatrix = new Matrix(3, 3);
            zeroMatrix[2][2] = 1.0;
            Console.WriteLine(zeroMatrix.ToString());

            Console.WriteLine("Creating Matrix from Data");
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = i;
            }
            Matrix loadMatrix = new Matrix(arr, 3);
            Console.WriteLine(loadMatrix.ToString());

            Console.WriteLine("Adding Matrix");
            Matrix addMatrix = loadMatrix + loadMatrix;
            Console.WriteLine(addMatrix.ToString());

            Console.WriteLine("Subtracting Matrix");
            Matrix subtractMatrix = addMatrix - loadMatrix;
            Console.WriteLine(subtractMatrix.ToString());

            Console.WriteLine("Multiplying Matrix");
            Matrix multiplyMatrix = subtractMatrix * addMatrix;
            Console.WriteLine(multiplyMatrix.ToString());

            Console.WriteLine("Transposing Matrix");
            Matrix transposeMatrix = multiplyMatrix.Transpose();
            Console.WriteLine(transposeMatrix.ToString());

            Console.WriteLine("================");
            Console.WriteLine("  EIGENSOLVER   ");
            Console.WriteLine("================");

            int[] vectorArray = { 1, 1, 1 };
            Vector v = new Vector(vectorArray);

            int[] arr3 = { 5, -2, -2, 8};
            Matrix vMatrix = new Matrix(arr3, 2);
            Console.WriteLine("Eigen Matrix");
            Console.WriteLine(vMatrix.ToString());

            EigenSolver e = new EigenSolver(vMatrix);
            Console.WriteLine("Dominant Eigen");
            Console.WriteLine(e.GetEigenVector().ToString());

            Console.WriteLine("Dominant Eigenvalue");
            Console.WriteLine(e.GetEigenValue().ToString() + "\n");


            Console.WriteLine("Dominant Eigen");
            Console.WriteLine(e.GetEigenVector().ToString());


            Console.WriteLine("Dominant Eigenvalue");
            Console.WriteLine(e.GetEigenValue().ToString() + "\n");

            Console.WriteLine("================");
            Console.WriteLine("LU DECOMPOSITION");
            Console.WriteLine("================");

            int[] arr2 = { 25, 5, 1, 64, 8, 1, 144, 12, 1 };
            Matrix pre = new Matrix(arr2, 3);
            LUMatrix lu = new LUMatrix(pre);

            Console.WriteLine("Original Matrix");
            Console.WriteLine(pre.ToString());

            Console.WriteLine("Upper Matrix");
            Matrix upper = lu.GetUpper();
            Console.WriteLine(upper.ToString());

            Console.WriteLine("Lower Matrix");
            Matrix lower = lu.GetLower();
            Console.WriteLine(lower.ToString());

            Console.WriteLine("Testing Decomposition");
            Matrix result = lower * upper;
            Console.WriteLine(result.ToString());

            Console.WriteLine("Determining Determinant");
            Number diagonal = lu.Determinant();
            Console.WriteLine(diagonal.ToString() + "\n");

            //Inverse is a little broken.
            Console.WriteLine("Finding Inverse");
            Matrix inverse = lu.Inverse();
            Console.WriteLine(inverse.ToString());

            Console.WriteLine("Testing Inverse");
            result = pre * inverse;
            Console.WriteLine(result.ToString());
            
            Console.Read();
        }
    }


}
