using System;

namespace Insertion_Sort
{
    public class Sort
    {
        public void insertionSort(int[] array)
        {
            int size = array.Length, key, i;

            for(int j=1; j<size; j++)
            {
                key = array[j];
                i = j - 1;
                while(i >= 0 && array[i] > key)
                {
                    array[i + 1] = array[i];
                    i--;
                }
                array[i + 1] = key;
            }

            Console.WriteLine("Sorted array:");

            for(i=0; i<size; i++)
            {
                Console.WriteLine(array[i]);
            }

            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of array: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[size];

            Console.WriteLine("Enter the elements of the array:");
            for(int i=0; i<size; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Sort s = new Sort();
            s.insertionSort(array);
        }
    }
}
