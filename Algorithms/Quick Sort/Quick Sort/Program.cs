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

                if(p < r)
                {
                    q = Partition(p, r);
                    QuickSort(p, q - 1);
                    QuickSort(q + 1, r);
                }
            }

            public int Partition(int p, int r)
            {
                int x = Array[r];
                int i = p - 1;
                int temp;

                for(int j = p; j < r-1; j++)
                {
                    if(Array[j] <= x)
                    {
                        i += 1;
                        temp = Array[i];
                        Array[i] = Array[j];
                        Array[j] = temp;
                    }
                }
                temp = Array[i + 1];
                Array[i + 1] = Array[r];
                Array[r] = temp;
                return i + 1;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];

            Console.WriteLine("Enter the elements of the array: ");
            for(int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Array = array;

            ClassQuickSort q = new ClassQuickSort();
            q.QuickSort(0, Array.Length - 1);

            Console.WriteLine("Array after quick sort procedure:");
            for(int i = 0; i<Array.Length; i++)
            {
                Console.WriteLine(Array[i]);
            }

            Console.ReadKey();
        }
    }
}
