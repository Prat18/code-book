using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubly_Linked_List
{
    class Program
    {
        public class Node
        {
            public Node next;
            public Node prev;
            public int key;
        }

        public class DoublyLinkedList
        {
            private Node Head;

            public void PrintAllNodes()
            {
                Node current = Head;
                if (Head == null) Console.WriteLine("List is empty.");
                while (current != null)
                {
                    Console.WriteLine(current.key);
                    current = current.next;
                }
            }

            public Node ListSearch(int key)
            {
                Node current = Head;

                while (current != null)
                {
                    if (current.key == key) return current;
                    current = current.next;
                }
                return null;
            }

            public void InsertFirst(int key)
            {
                Node toAdd = new Node
                {
                    next = Head,
                    key = key
                };

                if (Head == null) Head = toAdd;
                else
                {
                    Head.prev = toAdd;
                    Head = toAdd;
                }
            }

            public void InsertLast(int key)
            {
                Node current = Head;

                if (Head == null) InsertFirst(key);
                else
                {
                    while(current.next != null) current = current.next;

                    Node toAdd = new Node
                    {
                        prev = current,
                        key = key
                    };

                    current.next = toAdd;
                }
            }

            public void ListDelete(int key)
            {
                Node match = ListSearch(key);
                if (match == null) Console.WriteLine("No match found!");
                else if (match == Head && match.next != null)
                {
                    match.next.prev = null;
                    Head = match.next;
                }
                else if (match.next == null && match.prev != null) match.prev.next = null;
                else if (match == Head && match.next == null) Head = null;
                else
                {
                    match.prev.next = match.next;
                    match.next.prev = match.prev;
                }
            }
        }
        static void Main(string[] args)
        {
            DoublyLinkedList D = new DoublyLinkedList();

            int choice, key;
            Node match;

            while (true)
            {
                Console.WriteLine("Enter your choice: \n1. Print all nodes\n2. Search Through Linked List\n3. Insert at front\n4. Insert at last\n5. Delete\n6. EXIT\n");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                if (choice == 1)
                {
                    D.PrintAllNodes();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the data you want to search: ");
                    key = Convert.ToInt32(Console.ReadLine());

                    match = D.ListSearch(key);
                    if (match == null) Console.WriteLine("No match found.");
                    else
                    {
                        Console.WriteLine("Macth successful!");
                        if (match.next == null) Console.WriteLine("Next: " + "NULL");
                        else Console.WriteLine("Next: " + match.next.key);
                        if (match.prev == null) Console.WriteLine("Previous: " + "NULL");
                        else Console.WriteLine("Previous: " + match.prev.key);
                        Console.WriteLine("Data: " + match.key);
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter the data you want to add: ");
                    key = Convert.ToInt32(Console.ReadLine());

                    D.InsertFirst(key);

                }
                else if (choice == 4)
                {
                    Console.WriteLine("Enter the data you want to add: ");
                    key = Convert.ToInt32(Console.ReadLine());

                    D.InsertLast(key);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Enter the element you want to delete: ");
                    key = Convert.ToInt32(Console.ReadLine());

                    D.ListDelete(key);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
