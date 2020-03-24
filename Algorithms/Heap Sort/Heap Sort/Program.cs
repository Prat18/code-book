using System;

namespace Heap_Sort
{
    class Program
    {
        public static int[] Array { get; set; }
        public static int HeapSize { get; set; }

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

                if (l < HeapSize && Array[l] > Array[i]) largest = l;
                else largest = i;

                if (r < HeapSize && Array[r] > Array[largest]) largest = r;

                if (i != largest)
                {
                    temp = Array[largest];
                    Array[largest] = Array[i];
                    Array[i] = temp;

                    MAX_HEAPIFY(largest);
                }
            }

            public void BUILD_MAX_HEAP()
            {
                HeapSize = Array.Length;
                for (int i = (Array.Length / 2) - 1; i >= 0; i--)
                {
                    MAX_HEAPIFY(i);
                }
            }

            public void HEAPSORT()
            {
                int temp;
                BUILD_MAX_HEAP();
                for(int i = Array.Length - 1; i >= 1; i--)
                {
                    temp = Array[i];
                    Array[i] = Array[0];
                    Array[0] = temp;
                    HeapSize = HeapSize - 2;
                    MAX_HEAPIFY(0);
                }
            }

            public void PRINT_ARRAY()
            {
                for (int i = 0; i < Program.Array.Length; i++)
                {
                    Console.WriteLine(Program.Array[i]);
                }
            }

            public void MAX_HEAP_INSERT()
            {

            }

            public int HEAP_EXTRACT_MAX()
            {
                BUILD_MAX_HEAP();

                if (HeapSize < 1)
                {
                    Console.WriteLine("Error: Heap underflow");
                    return 0;
                }

                int max = Array[0];
                Array[0] = Array[HeapSize - 1];
                HeapSize -= 1;
                MAX_HEAPIFY(0);
                return max;

            }

            public void HEAP_INCREASE_KEY(int i, int key)
            {
                int temp;

                if (key < Array[i])
                {
                    Console.WriteLine("Error: New key is smaller than current key.");
                    return;
                }

                Array[i] = key;

                while (i > 0 && Array[Parent(i)] < Array[i])
                {
                    temp = Array[i];
                    Array[i] = Array[Parent(i)];
                    Array[Parent(i)] = temp;
                    i = Parent(i);
                }
            }

            public int HEAP_MAXIMUM()
            {
                BUILD_MAX_HEAP();
                return Array[0];
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
            Program.Array = array;

            while (true)
            {
                Console.WriteLine("\n\nEnter your choice: \n1. MAX-HEAPIFY\n2. BUILD-MAX-HEAP\n3. HEAPSORT\n4. MAX-HEAP-INSERT\n5. HEAP-EXTRACT-MAX\n6. HEAP-INCREASE-KEY\n7. HEAP-MAXIMUM\n8. PRINT-ARRAY\n9. EXIT\n\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

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
                    int heapExtractMax = H.HEAP_EXTRACT_MAX();
                    Console.WriteLine("Maximum extracted element from heap: " + heapExtractMax);
                }
                else if (choice == 6)
                {
                    Console.Write("Enter the index number: ");
                    int i = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\nEnter the value of new key: ");
                    int key = Convert.ToInt32(Console.ReadLine());

                    H.HEAP_INCREASE_KEY(i,key);

                    Console.WriteLine("Array after Heap-Increase-Key procedure: ");
                    H.PRINT_ARRAY();
                }
                else if (choice == 7)
                {
                    int heapMax = H.HEAP_MAXIMUM();
                    Console.WriteLine("The maximum element of heap: " + heapMax);
                }
                else if (choice == 8)
                {
                    Console.WriteLine("Array: ");
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

