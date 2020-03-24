using System;

namespace Quick_Sort
{
    class Program
    {
        public static int[] Array { set; get; }

        public class ClassQuickSort
        {
            public void QuickSort(int p, int r)
            {
                int q;

                if (p < r)
                {
                    q = Partition(p, r);
                    Console.WriteLine("pivot index: " + q);
                    QuickSort(p, q - 1);
                    QuickSort(q + 1, r);
                }
            }

            public int Partition(int p, int r)
            {
                int x = Array[r];
                int i = p - 1;

                for (int j = p; j < r; j++)
                {
                    if (Array[j] <= x)
                    {
                        i += 1;
                        Swap(i, j);
                    }
                }
                Swap(i + 1, r);
                PrintArray();
                Console.WriteLine("; Returns: " + (i + 1));
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
                Console.Write("\nArray:");
                for (int i = 0; i < Array.Length; i++)
                {
                    Console.Write(Array[i] + ",");
                }
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Enter the size of the array: ");
                int n = Convert.ToInt32(Console.ReadLine());

                int[] array = new int[n];

                Console.WriteLine("Enter the elements of the array: ");
                for (int i = 0; i < n; i++)
                {
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }

                Array = array;

                ClassQuickSort q = new ClassQuickSort();
                q.QuickSort(0, Array.Length - 1);
                q.PrintArray();
                Console.ReadKey();
            }
        }
    }
}
