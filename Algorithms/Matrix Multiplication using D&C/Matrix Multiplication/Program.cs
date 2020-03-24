using System;

namespace Matrix_Multiplication
{
    class Program
    {
        public class FindMatrixProduct
        {
            public void matrixProduct(int[,] A, int[,] B, int[,] C, int n)
            {

            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the size of matrix: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] A = new int[n, n];
            int[,] B = new int[n, n];
            int[,] C = new int[n, n];

            Console.WriteLine("Enter the elemrnts of first matrix: ");

            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    A[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Enter the elemrnts of second matrix: ");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    B[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            FindMatrixProduct F = new FindMatrixProduct();
            F.matrixProduct(A, B, C, n);
        }
    }
}
