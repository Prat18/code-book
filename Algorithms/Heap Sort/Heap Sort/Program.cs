using System;

namespace Heap_Sort
{
    class Program
    {

        public class Heap
        {
            public int parent(int i)
            {
                return i / 2;
            }

            public int left(int i)
            {
                return 2 * i;
            }

            public int right(int i)
            {
                return 2 * i + 1;
            }

            public void MAX_HEAPIFY(int[] A, int i)
            {
                int l = left(i);
                int r = right(i);
                int largest, temp;

                if (l < A.Length && A[l] > A[i]) largest = l;
                else largest = i;

                if (r < A.Length && A[r] > A[largest]) largest = r;

                if(i != largest)
                {
                    temp = A[largest];
                    A[largest] = A[i];
                    A[i] = temp;
                    MAX_HEAPIFY(A, largest);
                }

                Console.WriteLine("Array after Max-Heapify procedure: ");

                for (i=0; i<A.Length; i++)
                {
                    Console.WriteLine(A[i]);
                }
            }

            public void BUILD_MAX_HEAP()
            {

            }

            public void HEAPSORT()
            {

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

            for(int i=0; i<size; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Heap H = new Heap();

            Console.WriteLine("Enter the index of the node you want to Max Heapify: ");
            int node = Convert.ToInt32(Console.ReadLine());

            H.MAX_HEAPIFY(array, node);

            Console.ReadKey();
        }
    }
}
