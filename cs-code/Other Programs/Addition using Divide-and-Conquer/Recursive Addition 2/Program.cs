using System;

namespace Recursive_Addition_2
{
    class Program
    {
        class addition
        {
            public int RecursiveAdd(int[] A, int low, int high) // Line C
            {
                int sum = 0;
                int mid;

                if (low == high)
                {
                    return A[low];
                }
                else
                {
                    mid = (low + high) / 2;
                    sum += RecursiveAdd(A, low, mid) + RecursiveAdd(A, mid + 1, high);
                    return sum;
                }
            }
        }

        static void Main(string[] args)
        {
            int high;

            Console.WriteLine("Enter the number of inputs: ");
            high = Convert.ToInt32(Console.ReadLine());
            int low = 0;

            int[] A = new int[high];

            Console.WriteLine("Enter the numbber you want to add:");

            for (int i = 0; i < high; i++)
            {
                A[i] = Convert.ToInt32(Console.ReadLine());
            }

            addition a = new addition();
            int result = a.RecursiveAdd(A, low, high-1); // Line A

            Console.WriteLine("Sum: " + result);


            Console.ReadKey();
        }
    }
}
