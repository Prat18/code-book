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

            public Node ListSearch(int data)
            {
                Node current = Head, prev = Head;

                while (current != null)
                {
                    if(current.data == data) return prev;

                    prev = current;
                    current = current.next;
                }

                return null;
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
                    Node toAdd = new Node
                    {
                        data = data,
                        next = null
                    };

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
                Node node = ListSearch(data);

                if (node == null) Console.WriteLine("Data not found");
                else
                {
                    if(node == Head && node.data == data)
                    {
                        if (node.next == null) Head = null;
                        else Head = node.next;
                    }else if(node.next.next == null) node.next = null;
                    else node.next = node.next.next;
                }
            }
        }

        static void Main(string[] args)
        {
            ClassLinkedList L = new ClassLinkedList();

            int choice, key, data;
            Node match;

            while (true)
            {
                Console.WriteLine("Enter your choice: \n1. Print all nodes\n2. Search Through Linked List\n3. Insert at front\n4. Insert at last\n5. Delete\n6. EXIT\n");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                if(choice == 1)
                {
                    L.PrintAllNodes();
                }
                else if(choice == 2)
                {
                    Console.WriteLine("Enter the data you want to search: ");
                    key = Convert.ToInt32(Console.ReadLine());

                    match = L.ListSearch(key);
                    if (match == null) Console.WriteLine("No match found.");
                    else
                    {
                        Console.WriteLine("Macth successful!");
                        if (match.next.next == null) Console.WriteLine("Next: " + "NULL");
                        else Console.WriteLine("Next: " + match.next.next.data);
                        Console.WriteLine("Data: " + match.data);
                    }
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
