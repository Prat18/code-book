using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        public static int[] Queue { get; set; }
        public static int Head { get; set; }
        public static int Tail { get; set; }

        public class ClassQueue
        {
            public bool QueueEmpty()
            {
                if (Head == 0 && Tail == 0) return true;
                else return false;
            }
            public int Enqueue(int element)
            {
                Queue[Tail] = element;
                if (Tail == Queue.Length - 1) Tail = 0;
                else Tail += 1;

                return Queue[Tail - 1];
            }

            public int Dequeue()
            {
                int x = Queue[Head];
                if (Head == Queue.Length - 1) Head = 0;
                else Head += 1;

                return x;
            }

            public void PrintQueue()
            {
                if (QueueEmpty()) Console.WriteLine("Queue is empty.");
                else
                {
                    for (int i = Head; i < Tail; i++)
                    {
                        Console.WriteLine(Queue[i]);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int choice, element;

            Console.WriteLine("Enter the size of the queue: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] queue = new int[size];

            Queue = queue;
            Head = Tail = 0;

            ClassQueue Q = new ClassQueue();

            while (true)
            {
                Console.WriteLine("\nEnter your choice:\n1. Print\n2. Enqueue\n3. Dequeue\n4. EXIT\n\n");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                if(choice == 1)
                {
                    Q.PrintQueue();
                }else if(choice == 2)
                {
                    Console.WriteLine("Enter the element you want to enqueue: ");
                    element = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(Q.Enqueue(element) + " is enqueued successfully.");
                }
                else if(choice == 3)
                {
                    element = Q.Dequeue();
                    if (element != 0) Console.WriteLine(element + " is dequeued from the queue.");
                }
                else if(choice == 4)
                {
                    break;
                }
            }
        }
    }
}
