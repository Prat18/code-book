using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANDOMIZED_QUICKSORT
{
    class Program
    {
        public static int[] Array { get; set; }

        public class ClassRandomizedQuicksort
        {
            public int RandomizedPartition(int p, int r)
            {
                Random rnd = new Random();
                //Console.WriteLine(p + "<---" + "--->" + r);
                int i = p + rnd.Next(100) % (r - p);
                Swap(r, i);
                Console.Write("\nAfter randomizing at index " + i + "\n");
                PrintArray();
                return Partition(p, r);
            }

            public void RandomizedQuicksort(int p, int r)
            {
                if (p < r)
                {
                    int q = RandomizedPartition(p, r);
                    RandomizedQuicksort(p, q - 1);
                    RandomizedPartition(q + 1, r);
                }
            }

            public int Partition(int p, int r)
            {
                int pivotelement = Array[r];
                int i = p - 1;
                for(int j = p; j < r; j++)
                {
                    if(Array[j] <= pivotelement)
                    {
                        i = i + 1;
                        Swap(i, j);
                    }
                }
                Swap(i + 1, r);
                PrintArray();
                return i + 1;
            }

            public void Swap(int i, int j)
            {
                int temp;

                temp = Array[i];
                Array[i] = Array[j];
                Array[j] = temp;
            }

            public void PrintArray()
            {
                Console.Write("\nArray: ");
                for(int i = 0; i < Array.Length; i++)
                {
                    Console.Write(Array[i] + " ");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];
            for(int i = 0; i<n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Array = array;
            ClassRandomizedQuicksort R = new ClassRandomizedQuicksort();

            R.RandomizedQuicksort(0, Array.Length - 1);

            Console.WriteLine("\n\nArray after Randmized-Quicksort procedure: \n");
            R.PrintArray();

            Console.ReadKey();
        }
    }
}
