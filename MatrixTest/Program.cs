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

            Console.WriteLine("Decomposing Matrix");
            int[] arr2 = { 25, 5, 1, 64, 8, 1, 144, 12, 1 };
            Matrix pre = new Matrix(arr2, 3);
            LUMatrix lu = new LUMatrix(pre);

            Console.WriteLine("Upper Matrix");
            Matrix upper = lu.GetUpper();
            Console.WriteLine(upper.ToString());

            Console.WriteLine("Lower Matrix");
            Matrix lower = lu.GetLower();
            Console.WriteLine(lower.ToString());

            Console.Read();
        }
    }


}
