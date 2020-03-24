using System;

namespace Merge_Sort
{
    class Program
    {
        class mergeSort
        {
            public void merge_sort(int[] A, int p, int r)
            {
                if (p < r)
                {
                    int q = (p + r) / 2;
                    merge_sort(A, p, q);
                    merge_sort(A, q + 1, r);
                    merge(A, p, q, r); 
                }
            }

            public void merge(int[] A, int p, int q, int r)
            {
                int n1 = p - q;
                int n2 = r - q;
                int[] L = new int[n1 + 1];
                int[] R = new int[n2 + 1];
                for(int l = 0; l<n1; l++)
                {
                    L[l] = A[p + l - 1];
                }
                for (int m = 0; m < n2; m++)
                {
                    R[m] = A[q + m];
                }
                //R[n1 + 1] = 99999;
                //L[n2 + 1] = 99999;

                int i = 1;
                int j = 1;

                for(int k = p; k < r; k++)
                {
                    if(L[i] <= R[j])
                    {
                        A[k] = L[i];
                        i++;
                    }
                    else
                    {
                        A[k] = R[j];
                        j++;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int n;

            Console.Write("Enter the nuber of inputs: ");
            n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            Console.WriteLine("Enter the numbber you want to sort:");

            for(int i = 0; i<n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            mergeSort m = new mergeSort();
            m.merge_sort(arr, 0, n-1);

            Console.WriteLine(" Sortefd list: ");

            foreach (int e in arr)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}
