using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List
{
    class Program
    {
        public class Node
        {
            public Node next;
            //public Node prev;
            public int data;
        }

        public class ClassLinkedList
        {
            private Node Head;

            public void PrintAllNodes()
            {
                Node current = Head;

                while(current != null)
                {
                    Console.WriteLine(current.data);
                    current = current.next;
                }
            }

            public int ListSearch(int data)
            {
                Node current = Head;
                int match = 0;

                while (current != null)
                {
                    if(current.data == data)
                    {
                        Console.WriteLine("Macth successful!");
                        Console.WriteLine("Next: " + current.next);
                        Console.WriteLine("Data: " + current.data);
                        match = 1;
                    }
                    current = current.next;
                }

                return match;
            }

            public void InsertFirst(int data)
            {
                Node toAdd = new Node
                {
                    data = data,
                    next = Head
                };

                Head = toAdd;
            }

            public void InsertLast(int data)
            {
                if(Head == null)
                {
                    Head = new Node
                    {
                        data = data,
                        next = null
                    };
                }
                else
                {
                    Node toAdd = new Node();
                    toAdd.data = data;

                    Node current = Head;
                    while(current.next != null)
                    {
                        current = current.next;
                    }

                    current.next = toAdd;
                }
            }

            public void ListDelete(int data)
            {

            }
        }

        static void Main(string[] args)
        {
            ClassLinkedList L = new ClassLinkedList();

            int choice, key, data, match;

            while (true)
            {
                Console.WriteLine("Enter your choice: \n1. Print all nodes\n2. Search Through Linked List\n3. Insert at front\n4. Insert at last\n5. Delete\n6. EXIT\n");
                choice = Convert.ToInt32(Console.ReadLine());

                if(choice == 1)
                {
                    L.PrintAllNodes();
                }
                else if(choice == 2)
                {
                    Console.WriteLine("Enter the data you want to search: ");
                    key = Convert.ToInt32(Console.ReadLine());

                    match = L.ListSearch(key);
                    if (match == 0) Console.WriteLine("No match found.");
                }
                else if(choice == 3)
                {
                    Console.WriteLine("Enter the data you want to add: ");
                    data = Convert.ToInt32(Console.ReadLine());

                    L.InsertFirst(data);

                }
                else if(choice == 4)
                {
                    Console.WriteLine("Enter the data you want to add: ");
                    data = Convert.ToInt32(Console.ReadLine());

                    L.InsertLast(data);
                }
                else if(choice == 5)
                {
                    Console.WriteLine("Enter the element you want to delete: ");
                    data = Convert.ToInt32(Console.ReadLine());

                    L.ListDelete(data);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
