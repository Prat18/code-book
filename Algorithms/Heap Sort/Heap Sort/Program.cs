using System;

namespace Heap_Sort
{
    class Program
    {
        private static int[] array;
        public static int[] Array
        {
            get { return array; }
            set { array = value; }
        }
        public class Heap
        {
            public int Parent(int i)
            {
                return i / 2;
            }

            public int Left(int i)
            {
                return 2 * i + 1;
            }

            public int Right(int i)
            {
                return 2 * i + 2;
            }

            public void MAX_HEAPIFY(int i)
            {
                int l = Left(i);
                int r = Right(i);
                int largest, temp;

                if (l < array.Length && array[l] > array[i]) largest = l;
                else largest = i;

                if (r < array.Length && array[r] > array[largest]) largest = r;

                if (i != largest)
                {
                    temp = array[largest];
                    array[largest] = array[i];
                    array[i] = temp;

                    MAX_HEAPIFY(largest);
                }
            }

            public void BUILD_MAX_HEAP()
            {
                for (int i = (array.Length / 2) - 1; i >= 0; i--)
                {
                    MAX_HEAPIFY(i);
                }
            }

            public void HEAPSORT()
            {
                BUILD_MAX_HEAP();
                int heapsize = array.Length;
                for(int i = array.Length - 1; i >= 1; i--)
                {
                    array[1] = array[i];
                    heapsize = heapsize - 1;
                    MAX_HEAPIFY(0);
                }
            }

            public void PRINT_ARRAY()
            {
                for (int i = 0; i < Program.array.Length; i++)
                {
                    Console.WriteLine(Program.array[i]);
                }
            }

            public void MAX_HEAP_INSERT()
            {

            }

            public void HEAP_EXTRACT_MAX()
            {

            }

            public void HEAP_INCREASE_KEY()
            {

            }

            public void HEAP_MAXIMUM()
            {

            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[size];

            Console.WriteLine("Enter the elements of the array: ");

            for (int i = 0; i < size; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Heap H = new Heap();
            Program.array = array;

            while (true)
            {
                Console.WriteLine("Enter your choice: \n1. MAX-HEAPIFY\n2. BUILD-MAX-HEAP\n3. HEAPSORT\n4. MAX-HEAP-INSERT\n5. HEAP-EXTRACT-MAX\n6. HEAP-INCREASE-KEY\n7. HEAP-MAXIMUM\n8. PRINT-ARRAY\n9. EXIT");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter the index of the node you want to Max Heapify: ");
                    int node = Convert.ToInt32(Console.ReadLine());
                    H.MAX_HEAPIFY(node);
                    Console.WriteLine("Array after Max-Heapify procedure: ");
                    H.PRINT_ARRAY();
                }
                else if (choice == 2)
                {
                    H.BUILD_MAX_HEAP();
                    Console.WriteLine("Array after Build-Max-Heap procedure: ");
                    H.PRINT_ARRAY();
                }
                else if(choice == 3)
                {
                    H.HEAPSORT();
                    Console.WriteLine("Array after Heap-Sort procedure: ");
                    H.PRINT_ARRAY();
                }
                else if (choice == 4)
                {

                }
                else if (choice == 5)
                {

                }
                else if (choice == 6)
                {

                }
                else if (choice == 7)
                {

                }
                else if (choice == 8)
                {
                    Console.Write("Array: ");
                    H.PRINT_ARRAY();
                }
                else if(choice == 9)
                {
                    break;
                }
            }
        }
    }
}

