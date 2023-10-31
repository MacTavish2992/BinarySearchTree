using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BinaryTree
{
    /// <summary>
    /// Логика взаимодействия для Simmetry.xaml
    /// </summary>
    public partial class Simmetry : Window
    {
        //BinarySearchTreePart2 tree2 = new BinarySearchTreePart2();
        public Simmetry()
        {
            InitializeComponent();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //int[] values = { 5, 3, 7, 4, 25, 8, 10, 15, 20, 6, 30 };
            //foreach (int num in values)
            //{
            //    tree2.InsertPart2(num);
            //}

            //tree2.ThreadedInorder(); // Выполняем симметричную прошивку

            //// После прошивки выводим результат в lb1.Content
            //string inorderResult = tree2.InorderTraversalThreaded();
            //lb1.Content = "Симметричный обход:\n" + inorderResult;
        }





        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            //int searchKey = 2;
            //TreeNodePart2 foundNode = tree2.SearchThreaded(searchKey);
            //if (foundNode != null)
            //{
            //    MessageBox.Show($"Поиск {searchKey}: НАЙДЕНО {foundNode.Data}\nЦепочка поиска: {tree2.SearchPath(searchKey)}");
            //}
            //else
            //{
            //    MessageBox.Show($"Поиск {searchKey}: не найдено");
            //}
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            //int insertValue = 1;
            //tree2.InsertPart2(insertValue);
            //tree2.ThreadedInorder();

            //// Обновляем данные в lb1 после вставки
            //string inorderResult = tree2.InorderTraversalThreaded();
            //lb1.Content = "Симметричный обход:\n" + inorderResult;
        }
    }
    //class TreeNode
    //{
    //    public int Data;
    //    public TreeNode Left;
    //    public TreeNode Right;
    //    public TreeNode RightThread;
    //    public bool RightThreaded;

    //    public TreeNode(int data)
    //    {
    //        Data = data;
    //        Left = null;
    //        Right = null;
    //        RightThread = null;
    //        RightThreaded = false;
    //    }
    //}

    //class BinarySearchTree
    //{
    //    private TreeNode root;

    //    public BinarySearchTree()
    //    {
    //        root = null;
    //    }

    //    public void Insert(int data)
    //    {
    //        root = InsertRec(root, data);
    //    }

    //    private TreeNode InsertRec(TreeNode root, int data)
    //    {
    //        if (root == null)
    //        {
    //            root = new TreeNode(data);
    //            return root;
    //        }

    //        if (data < root.Data)
    //        {
    //            root.Left = InsertRec(root.Left, data);
    //        }
    //        else if (data > root.Data)
    //        {
    //            root.Right = InsertRec(root.Right, data);
    //        }

    //        return root;
    //    }

    //    public void ThreadedInorder()
    //    {
    //        TreeNode current = Leftmost(root);
    //        TreeNode prev = null;

    //        while (current != null)
    //        {
    //            if (current.Left == null)
    //            {
    //                if (current.Right == null)
    //                {
    //                    current.RightThread = prev;
    //                    current.RightThreaded = true;
    //                }
    //                prev = current;
    //                current = current.RightThread;
    //            }
    //            else
    //            {
    //                TreeNode predecessor = Rightmost(current.Left);
    //                if (predecessor.RightThreaded)
    //                {
    //                    predecessor.RightThread = current;
    //                    current.RightThreaded = true;
    //                    current = current.Left;
    //                }
    //                else
    //                {
    //                    predecessor.RightThreaded = true;
    //                    predecessor.RightThread = current;
    //                    current = current.Right;
    //                }
    //            }
    //        }
    //    }

    //    public void InorderTraversalThreaded(Action<int> action)
    //    {
    //        TreeNode current = Leftmost(root);

    //        while (current != null)
    //        {
    //            action(current.Data);

    //            if (current.RightThreaded)
    //            {
    //                current = current.RightThread;
    //            }
    //            else
    //            {
    //                current = current.Right;
    //            }
    //        }
    //    }

    //    public TreeNode Search(int key)
    //    {
    //        TreeNode current = Leftmost(root);

    //        while (current != null)
    //        {
    //            if (current.Data == key)
    //            {
    //                return current;
    //            }
    //            else if (current.Data < key)
    //            {
    //                current = current.Right;
    //            }
    //            else
    //            {
    //                current = current.RightThread;
    //            }
    //        }

    //        return null;
    //    }

    //    private TreeNode Leftmost(TreeNode node)
    //    {
    //        while (node != null && node.Left != null)
    //        {
    //            node = node.Left;
    //        }
    //        return node;
    //    }

    //    private TreeNode Rightmost(TreeNode node)
    //    {
    //        while (node != null && node.Right != null)
    //        {
    //            node = node.Right;
    //        }
    //        return node;
    //    }
    //}

}
