using System;

namespace maximum_subarray_problem
{
    class Program
    {
        public class FindMaximumSubarray
        {
            public int findMaxSub(int[] A, int low, int high)
            {
                int mid;
                int leftsum, rightsum, crosssum;

                if (low == high)
                {
                    return A[low];
                }
                else
                {
                    mid = (low + high) / 2;
                    leftsum = findMaxSub(A, low, mid);
                    rightsum = findMaxSub(A, mid + 1, high);
                    crosssum = findMaxCrossSub(A, low, mid, high);
                }
                if (leftsum > rightsum && leftsum > crosssum) return leftsum;
                if (rightsum > leftsum && rightsum > crosssum) return rightsum;
                return crosssum;
            }

            public int findMaxCrossSub(int[] A, int low, int mid, int high)
            {
                int leftsum = int.MinValue;
                int rightsum = int.MinValue;
                int sum = 0;

                for(int i = mid; i>=0; i--)
                {
                    sum += A[i];
                    if (sum > leftsum)
                    {
                        leftsum = sum;
                    }
                }

                sum = 0;

                for(int j = mid+1; j<=high; j++)
                {
                    sum += A[j];
                    if (sum > rightsum)
                    {
                        rightsum = sum;
                    }
                }
                return leftsum+rightsum;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];

            Console.WriteLine();
            Console.WriteLine("Enter the elements:");

            for(int i=0; i<n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            FindMaximumSubarray F = new FindMaximumSubarray();
            int results = F.findMaxSub(array, 0, n-1);

            Console.WriteLine();
            Console.WriteLine("The maximum sub-array is: " + results);
            Console.ReadKey();
        }
    }
}
