using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class BinaryTree
    {
        public Person Data;
        public BinaryTree Left, Right;

        public BinaryTree() { }
        public BinaryTree(Person p) { Data = p; }

        public override string ToString() { return Data.ToString(); }

        //Рекурсивная функция, которая строит идеально сбалансированное дерево указанного размера.
        static public BinaryTree IdealTree(BinaryTree root, int size, Random rand)
        {
            if (size == 0) return null;
            if (size > 1)
            {
                size--;
                root.Left = IdealTree(new BinaryTree(), size, rand);
                root.Right = IdealTree(new BinaryTree(), size, rand);
            }
            root.Data = new Person("Mob", rand.Next(10, 81), true);
            return root;
        }

        /* Рекурсивная функция, которая выводит на консоль дерево в виде:
         *        Left
         * Root
         *        Right
         */
        public static void Show(BinaryTree root, [Optional] int l)
        {
            if (root != null)
            {
                Show(root.Left, l + 3);
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(root.Data.Age);
                Show(root.Right, l + 3);
            }
        }

        //Рекурсивная функция, которая преобразует идеально сбалансированное дерево в дерево поиска.
        public static BinaryTree ToSearchTree(BinaryTree root, List<Person> list)
        {
            if (root == null) return null;
            BinaryTree SearchTree = new BinaryTree();
            ToSearchTree(root.Left, list);
            root.Data = list[0];
            list.RemoveAt(0);
            ToSearchTree(root.Right, list);
            return root;
        }

        //Рекурсивная функция, преобразующая дерево в список.
        public static List<Person> ToList(BinaryTree root)
        {
            if (root == null) return null;
            List<Person> list = new List<Person>();
            if (root.Data != null) list.Add(root.Data);
            if (root.Left != null) list.AddRange(ToList(root.Left));
            if (root.Right != null) list.AddRange(ToList(root.Right));
            list.Sort();
            return list;
        }
    }
}
