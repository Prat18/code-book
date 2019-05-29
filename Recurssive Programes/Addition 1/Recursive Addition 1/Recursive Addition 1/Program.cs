using System;

namespace Recursive_Addition_1
{
    class Program
    {
        class addition
        {
            public int RecursiveAdd(int[] a, int n) // Line C
            {
                if (n == 1) return a[n-1];
                Console.WriteLine("Am in Line B");
                return RecursiveAdd(a, n-1) + a[n-1]; //Line B
            }
        }

        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("Enter the number of inputs: ");
            n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            Console.WriteLine("Enter the numbber you want to add:");

            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            addition a = new addition();
            int result = a.RecursiveAdd(arr, n); // Line A

            Console.WriteLine("Sum: " + result);


            Console.ReadKey();
        }
    }
}
