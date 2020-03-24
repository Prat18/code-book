using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        public static int[] Stack { get; set; }
        public static int Top { get; set; }

        public class ClassStack
        {
            public bool StackEmpty()
            {
                if (Top < 0) return true;
                else return false;
            }

            public void Push(int element)
            {
                Top += 1;
                Stack[Top] = element;
                Console.WriteLine(element + " is successfully pushed in the stack.");
            }

            public int Pop()
            {
                if (StackEmpty()) Console.WriteLine("Error: Stack underflow");
                else
                {
                    Top -= 1;
                    return Stack[Top + 1];
                }

                return 0;
            }

            public void PrintStack()
            {
                if (StackEmpty()) Console.WriteLine("Stack is empty.");
                else
                {
                    for(int i=0; i<=Top; i++)
                    {
                        Console.WriteLine(Stack[i]);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int MAX = 1000, choice, element;
            int[] stack = new int[MAX];

            Stack = stack;
            Top = -1;

            ClassStack S = new ClassStack();

            while (true)
            {
                Console.WriteLine("\nEnter your choice:\n1. Print\n2. Push\n3. Pop\n4. EXIT\n\n");
                choice = Convert.ToInt32(Console.ReadLine());

                if(choice == 1)
                {
                    S.PrintStack();
                }else if(choice == 2)
                {
                    Console.WriteLine("Enter the element you want to push: ");
                    element = Convert.ToInt32(Console.ReadLine());

                    S.Push(element);
                }else if(choice == 3)
                {
                    element = S.Pop();
                    if (element != 0) Console.WriteLine(element + " is popped from the stack");
                }
                else
                {
                    break;
                }
            }
        }
    }
}
