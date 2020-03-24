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
                if (x == null || key == x.key) return x;
                if (key < x.key) return TreeSearch(key, x.left);
                else return TreeSearch(key, x.right);
            }

            public Node IterativeTreeSearch(int key, Node x)
            {
                while(x != null && key != x.key)
                {
                    if (key < x.key) x = x.left;
                    else x = x.right;
                }
                return x;
            }

            public Node TreeMaximum(Node x)
            {
                while (x.right != null) x = x.right;
                return x;
            }

            public Node TreeMinimum(Node x)
            {
                while (x.left != null) x = x.left;
                return x;
            }

            public Node TreeSuccessor(Node x)
            {
                if (x.right != null) return TreeMinimum(x.right);
                Node y = x.parent;
                while(y != null && x == y.right)
                {
                    x = y;
                    y = y.parent;
                }
                return y;
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

            public void Transplant(Node u, Node v)
            {
                if (u.parent == null) Root = v;
                else if (u == u.parent.left) u.parent.left = v;
                else u.parent.right = v;
                if (v != null) v.parent = u.parent;
            }

            public void TreeDelete(Node z)
            {
                if (z.left == null) Transplant(z, z.right);
                else if (z.right == null) Transplant(z, z.left);
                else
                {
                    Node y = TreeMinimum(z.right);
                    if(y.parent != z)
                    {
                        Transplant(y, y.right);
                        y.right = z.right;
                        y.right.parent = y;
                    }

                    Transplant(z, y);
                    y.left = z.left;
                    y.left.parent = y;
                }
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
                    Console.WriteLine("Enter the key you want to search iteratively: ");
                    int key = Convert.ToInt32(Console.ReadLine());
                    Node match = B.IterativeTreeSearch(key, B.Root);

                    if (match == null) Console.WriteLine("No such key exist.");
                    else
                    {
                        Console.WriteLine("key: " + match.key);
                        if (match.parent != null) Console.WriteLine("parent key: " + match.parent.key);
                        if (match.left != null) Console.WriteLine("Left child key: " + match.left.key);
                        if (match.right != null) Console.WriteLine("right child key: " + match.right.key);
                    }
                }
                else if (choice == 4)
                {
                    Node max = B.TreeMaximum(B.Root);
                    if (max != null) Console.WriteLine("MAXIMUM: " + max.key);
                    else Console.WriteLine("Tree is empty.");
                }
                else if (choice == 5)
                {
                    Node min = B.TreeMinimum(B.Root);
                    if (min != null) Console.WriteLine("MINIMUM: " + min.key);
                    else Console.WriteLine("Tree is empty.");
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Enter the key you want to find successor of: ");
                    int key = Convert.ToInt32(Console.ReadLine());
                    Node x = B.TreeSearch(key, B.Root);
                    Node successor = B.TreeSuccessor(x);
                    if (successor != null) Console.WriteLine("The successor of key " + key + " is " + successor.key);
                    else Console.WriteLine("successor don't exist.");
                }
                else if (choice == 7)
                {
                    Console.WriteLine("Enter the key you want to insert: ");
                    int key = Convert.ToInt32(Console.ReadLine());
                    B.TreeInsert(key);
                }
                else if (choice == 8)
                {
                    //B.Transplant();
                }
                else if (choice == 9)
                {
                    Console.WriteLine("Enter the key you want to delete: ");
                    int key = Convert.ToInt32(Console.ReadLine());
                    Node z = B.TreeSearch(key, B.Root);

                    if (z != null) B.TreeDelete(z);
                    else Console.WriteLine("No such key exist.");
                }
                else break;
            }
        }
    }
}