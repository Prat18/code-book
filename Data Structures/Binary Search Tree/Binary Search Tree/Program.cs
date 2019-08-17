using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree
{
    class Program
    {
        public static Node Root { get; set; }

        public class Node
        {
            public Node left;
            public Node right;
            public Node parent;
            public int key;
        }

        public class BST
        {
            public Node Root;

            public void InorderTreeWalk(Node x)
            {
                if (x != null)
                {
                    InorderTreeWalk(x.left);
                    Console.WriteLine(x.key);
                    InorderTreeWalk(x.right);
                }
            }

            public Node TreeSearch(int key, Node x)
            {
                if (x == null && key == x.key) return x;
                if (key < x.key) return TreeSearch(key, x.left);
                else return TreeSearch(key, x.right);
            }

            public void IterativeTreeSearch()
            {

            }

            public void TreeMaximum()
            {

            }

            public void TreeMinimum()
            {

            }

            public void TreeSuccessor()
            {

            }

            public void TreeInsert(int key)
            {
                Node toAdd = new Node
                {
                    key = key
                };

                Node y = null;
                Node x = Root;

                while(x != null)
                {
                    y = x;
                    if (toAdd.key < x.key) x = x.left;
                    else x = x.right;
                }

                toAdd.parent = y;
                if (y == null) Root = toAdd;
                else if (toAdd.key < y.key) y.left = toAdd;
                else y.right = toAdd;
            }

            public void Transplant()
            {

            }

            public void TreeDelete()
            {

            }
        }

        static void Main(string[] args)
        {
            BST B = new BST();

            int choice;

            while (true)
            {
                Console.WriteLine("Enter your choice: \n1. Inorder Tree Walk\n2. Tree Search\n3. Iterative Tree Search\n4. Tree Maximum\n5. Tree Minimum\n6. Tree Successor\n7. Tree Insert\n8. Transplant\n9. Tree Delete\n10. EXIT");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                if(choice == 1)
                {
                    B.InorderTreeWalk(B.Root);
                }else if (choice == 2)
                {
                    Console.WriteLine("Enter the key you want to search: ");
                    int key = Convert.ToInt32(Console.ReadLine());
                    Node match = B.TreeSearch(key, B.Root);

                    if (match == null) Console.WriteLine("No such key exist.");
                    else
                    {
                        Console.WriteLine("key: " + match.key);
                        if (match.parent != null) Console.WriteLine("parent key: " + match.parent.key);
                        if (match.left != null) Console.WriteLine("Left child key: " + match.left.key);
                        if (match.right != null) Console.WriteLine("right child key: " + match.right.key);
                    }
                }
                else if (choice == 3)
                {
                    B.IterativeTreeSearch();
                }
                else if (choice == 4)
                {
                    B.TreeMaximum();
                }
                else if (choice == 5)
                {
                    B.TreeMinimum();
                }
                else if (choice == 6)
                {
                    B.TreeSuccessor();
                }
                else if (choice == 7)
                {
                    Console.WriteLine("Enter the key you want to insert: ");
                    int key = Convert.ToInt32(Console.ReadLine());
                    B.TreeInsert(key);
                }
                else if (choice == 8)
                {
                    B.Transplant();
                }
                else if (choice == 9)
                {
                    B.TreeDelete();
                }
                else break;
            }
        }
    }
}
