using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simultaneous_minimum_and_maximum
{
    class Program
    {
        public class ClassFindMaxMin
        {
            public void FindMaxMin(int[] A)
            {
                int size = A.Length;
                int max;
                int min;

                if (size % 2 == 0)
                {
                    if (A[0] > A[1])
                    {
                        max = A[0];
                        min = A[1];
                    }
                    else
                    {
                        max = A[1];
                        min = A[0];
                    }

                    for (int i = 2; i < size - 1; i += 2)
                    {
                        if (A[i] > A[i + 1])
                        {
                            if (A[i] > max) max = A[i];
                            if (A[i + 1] < min) min = A[i + 1];
                        }
                        else
                        {
                            if (A[i + 1] > max) max = A[i + 1];
                            if (A[i] < min) min = A[i];
                        }
                    }
                }
                else
                {
                    max = min = A[0];

                    for (int i = 1; i < size - 1; i += 2)
                    {
                        if (A[i] > A[i + 1])
                        {
                            if (A[i] > max) max = A[i];
                            if (A[i + 1] < min) min = A[i + 1];
                        }
                        else
                        {
                            if (A[i + 1] > max) max = A[i + 1];
                            if (A[i] < min) min = A[i];
                        }
                    }
                }

                Console.WriteLine("MAXIMUM: " + max + "\nMINIMUM: " + min);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            ClassFindMaxMin C = new ClassFindMaxMin();
            C.FindMaxMin(array);

            Console.ReadKey();
        }
    }
}
