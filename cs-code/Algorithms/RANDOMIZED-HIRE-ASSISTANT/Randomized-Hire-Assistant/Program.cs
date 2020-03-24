using System;

namespace Randomized_Hire_Assistant
{
    class Program
    {
        public class Permutation
        {
            public void permutationBySorting(int[] array)
            {
                int size = array.Length;
                int[] parray = new int[size];
                int[] farray = new int[size];

                Random rnd = new Random();

                for(int i=0; i<size; i++)
                {
                    parray[i] = rnd.Next(1, size * size * size);
                }

                Console.WriteLine("Priority array:");

                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine(parray[i]);
                }

                int min = parray[0], k = 0, index = 0;

                while (k < size)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (min > parray[i] && parray[i] != 0)
                        {
                            min = parray[i];
                            index = i;
                        }
                    }
                    farray[k] = array[index];
                    k++;
                    parray[index] = 999999999;
                    min = 9999999;
                }

                Console.WriteLine("List after randomization:");

                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine(farray[i]);
                }

                randomizedHireAssistant(farray);
            }

            public void randomizeInPlace(int[] array)
            {
                int size = array.Length;
                int temp, index;
                Random rnd = new Random();
                for(int i=0; i<size; i++)
                {
                    temp = array[i];
                    index = rnd.Next(i, size);
                    array[i] = array[index];
                    array[index] = temp;
                }

                Console.WriteLine("List after randomization:");

                for(int i=0; i<size; i++)
                {
                    Console.WriteLine(array[i]);
                }

                randomizedHireAssistant(array);
            }

            void randomizedHireAssistant(int[] array)
            {
                int best = 0, candidate;
                for(int i=0; i<array.Length; i++)
                {
                    candidate = array[i];
                    if(candidate > best)
                    {
                        best = array[i];
                        Console.WriteLine("Hire Candidate " + array[i] + ".");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of clients: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] clients = new int[n];

            Console.WriteLine("Enter the rank of clients: ");

            for(int i=0; i<n; i++)
            {
                clients[i] = Convert.ToInt32(Console.ReadLine());
            }

            Permutation p = new Permutation();

            Console.WriteLine("Enter your choice for permuting the client's array: \n1. Permutation by sorting  \n2. Randomize in place");
            int choice = Convert.ToInt32(Console.ReadLine());

            if(choice == 1)
            {
                p.permutationBySorting(clients);
            }
            else
            {
                p.randomizeInPlace(clients);
            }

            Console.ReadKey();
        }
    }
}
