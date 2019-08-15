using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree
{
    class Program
    {
        public class Node
        {
            public Node leftChild;
            public Node rightChild;
            public Node parentNode;
            public int key;
        }

        public class BST
        {
            private Node Root;

            public void InorderTreeWalk()
            {

            }

            public void TreeSearch()
            {

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

            public void TreeInsert()
            {

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
                Console.WriteLine("Enter your choice: \n1. Inorder Tree Walk\n2. Tree Search\n3. Iterative Tree Search\n4. Tree Maximum\n5. Tree Minimum\n6. Tree Successor\n7. TreeInsert\n8. Transplant\n9. Tree Delete\n10. EXIT");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                if(choice == 1)
                {
                    B.InorderTreeWalk();
                }else if (choice == 2)
                {
                    B.TreeSearch();
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
                    B.TreeInsert();
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
