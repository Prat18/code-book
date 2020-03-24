using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANDOMIZED_SELECT
{
    class Program
    {
        public static int[] Array { get; set; }

        public class ClassRandomizedSelect
        {
            public int RandomizedSelect(int p, int r, int i)
            {
                if (p == r) return Array[p];
                int q = RandomizedPartition(p, r);
                int k = q - p + 1;
                if (i == k) return Array[q];
                else if (i < k) return RandomizedSelect(p, q - 1, i);
                else return RandomizedSelect(q + 1, r, i - k);
            }

            public int RandomizedPartition(int p, int r)
            {
                int x = Array[r];
                Random rnd = new Random();
                int q = rnd.Next(p, r);
                Swap(r, q);

                int i = p - 1;
                for(int j=p; j < r; j++)
                {
                    if(Array[j] < Array[r])
                    {
                        i += 1;
                        Swap(j, i);
                    }
                }
                Swap(i + 1, r);
                return i + 1;
            }

            public void Swap(int i, int j)
            {
                int temp;
                temp = Array[i];
                Array[i] = Array[j];
                Array[j] = temp;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];
            Console.WriteLine("Enter the elements of the array: ");
            for(int i=0; i<n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Array = array;

            Console.WriteLine("Enter the order of element you want to fetch: ");
            int ithorder = Convert.ToInt32(Console.ReadLine());

            ClassRandomizedSelect R = new ClassRandomizedSelect();
            int result = R.RandomizedSelect(0, Array.Length - 1, ithorder);
            Console.WriteLine("The ith smallest order element is " + result);
            Console.ReadKey();
        }
    }
}
