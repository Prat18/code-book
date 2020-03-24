using System;

namespace matrix_multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] matrix1 = new int[n, n];
            int[,] matrix2 = new int[n, n];
            int[,] result = new int[n, n];

            Console.WriteLine("Enter the elements of first matrix: ");

            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    matrix1[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Enter the elements of second matrix: ");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix2[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    result[i, j] = 0;
                    for(int k=0; k<n; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine(result[i, j]);
                }
            }

            Console.ReadKey();
        }
    }
}
