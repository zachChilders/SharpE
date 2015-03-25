using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpe.Matrix;
using Sharpe.Numbers;

namespace MatrixTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Identity Matrix");
            IdentityMatrix idMatrix = new IdentityMatrix(3);
            Console.WriteLine(idMatrix.ToString());

            Console.WriteLine("Creating 3x3 Double Matrix");
            Matrix ZeroMatrix = new Matrix(3, 3);
            ZeroMatrix[2][2] = 1.0;
            Console.WriteLine(ZeroMatrix.ToString());

            Console.WriteLine("Creating Matrix from Data");
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = i;
            }
            Matrix loadMatrix = new Matrix(arr, 3);
            Console.WriteLine(loadMatrix.ToString());

            Console.WriteLine("Adding Matrix");
            Matrix AddMatrix = loadMatrix + loadMatrix;
            Console.WriteLine(AddMatrix.ToString());

            Console.WriteLine("Subtracting Matrix");
            Matrix SubtractMatrix = AddMatrix - loadMatrix;
            Console.WriteLine(SubtractMatrix.ToString());

            Console.WriteLine("Multiplying Matrix");
            Matrix MultiplyMatrix = SubtractMatrix * AddMatrix;
            Console.WriteLine(MultiplyMatrix.ToString());

            Console.WriteLine("Transposing Matrix");
            Matrix TransposeMatrix = MultiplyMatrix.Transpose();
            Console.WriteLine(TransposeMatrix.ToString());

            int[] arr2 = {25,5,1,64,8,1,144,12,1};

            Matrix pre = new Matrix(arr2, 3);
            Console.WriteLine("Decomposing Matrix");
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
