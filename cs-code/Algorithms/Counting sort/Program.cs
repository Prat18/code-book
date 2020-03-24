using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counting_sort
{
    class Program
    {
        public static int[] A { get; set; }
        public static int[] C { get; set; }
        public static int[] B { get; set; }

        public class ClassCountingSort
        {
            public void CountingSort(int k)
            {
                Console.WriteLine("Array C: ");
                for(int i=0; i<A.Length; i++)
                {
                    C[A[i]] = C[A[i]] + 1;
                }

                for(int i=0; i<C.Length; i++)
                {
                    Console.Write(C[i]);
                }


                for(int j=1; j<=k; j++)
                {
                    C[j] = C[j] + C[j - 1];
                }

                B = new int[A.Length];
                for(int i=A.Length - 1; i>=0; i--)
                {
                    B[--C[A[i]]] = A[i];
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the max element of the array: ");
            int k = Convert.ToInt32(Console.ReadLine());
            int[] c = new int[k+1];
            for(int i =0; i<k; i++)
            {
                c[i] = 0;
            }

            Program.C = c;

            Console.Write("Enter the size of the array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];
            Console.WriteLine("Enter the elements of the array: ");
            for(int i = 0; i<n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            A = array;
            
            ClassCountingSort C = new ClassCountingSort();
            C.CountingSort(k);

            for(int i=0; i<B.Length; i++)
            {
                Console.WriteLine(B[i]);
            }

            Console.ReadKey();
        }
    }
}
