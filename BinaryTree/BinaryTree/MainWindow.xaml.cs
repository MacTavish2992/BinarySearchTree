using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BinaryTree
{
    public partial class MainWindow : Window
    {
        BinarySearchTree tree = new BinarySearchTree();// создаём объект с которым будем работать
        string str1 = "Прямой обход:";//это для вывода результата обходов
        string str2 = "\nСимметричный обход:";
        string str3 = "\nОбратный обход:";
        List<int> lst = new List<int>();
        

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            

            // заполнение дерева(объекта tree) из textboxoв
            for (int i = 1; i <= 12; i++)
            {
                string textBoxName = "BX" + i;
                TextBox textBox = FindName(textBoxName) as TextBox;

                if (textBox != null)
                {
                    if (int.TryParse(textBox.Text, out int num))
                    {
                        lst.Add(num);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка ввода числа: " + textBox.Text);
                        return;
                    }
                }
            }
            foreach (int num in lst)
            {
                tree.Insert(num);//метод вставки Insert
            }

            

            string preorderResult = tree.PreorderTraversal();// метод прямого обхода
            string inorderResult = tree.InorderTraversal();// метод симметричного обхода
            string postorderResult = tree.PostorderTraversal();// метод обратного обхода

            lb.Content = $"{str1}\n{preorderResult}{str2}\n{inorderResult}{str3}\n{postorderResult}";// вывод в лэйбл
            obhod.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)// метод поиска в дереве
        {
            

            if (int.TryParse(tx1.Text, out int searchValue))// проверки на инт
            {
                int? foundValue = tree.Search(searchValue);

                string searchResult = foundValue.HasValue ? $"Поиск {searchValue}: НАЙДЕНО {foundValue}" : $"Поиск {searchValue}: не найдено";//запись результата по условию

                
                MessageBox.Show(searchResult);
            }
            else
            {
                MessageBox.Show("Ошибка ввода числа: " + tx1.Text);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)// метод удаления элемента дерева
        {
            if (int.TryParse(tx2.Text, out int deleteValue))
            {
                StringBuilder steps = new StringBuilder();
                tree.Delete(deleteValue, steps);

                // Обновляем результаты обхода в lb.Content
                string updatedPreorderResult = tree.PreorderTraversal();
                string updatedInorderResult = tree.InorderTraversal();
                string updatedPostorderResult = tree.PostorderTraversal();

                lb.Content = $"{str1}\n{updatedPreorderResult}{str2}\n{updatedInorderResult}{str3}\n{updatedPostorderResult}\nУдаление {deleteValue} выполнено.\n\nШаги удаления:\n{steps.ToString()}";//записываем результат в лэйбл
            }
            else
            {
                MessageBox.Show("Ошибка ввода числа: " + tx2.Text);
            }
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)// метод вставки элемента в дерево
        {

            if (int.TryParse(tx3.Text, out int insertValue))
            {
                // Вставляем элемент в дерево
                tree.Insert(insertValue);

                // Обновляем результаты обхода в lb.Content
                string updatedPreorderResult = tree.PreorderTraversal();
                string updatedInorderResult = tree.InorderTraversal();
                string updatedPostorderResult = tree.PostorderTraversal();

                lb.Content = $"{str1}\n{updatedPreorderResult}{str2}\n{updatedInorderResult}{str3}\n{updatedPostorderResult}\nВставка {insertValue} выполнена.";//записываем результат в лэйбл
            }
            else
            {
                MessageBox.Show("Ошибка ввода числа: " + tx3.Text);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            BX1.Text = "";
            BX2.Text = "";
            BX3.Text = "";
            BX4.Text = "";
            BX5.Text = "";
            BX6.Text = "";
            BX7.Text = "";
            BX8.Text = "";
            BX9.Text = "";
            BX10.Text = "";
            BX11.Text = "";
            BX12.Text = "";
            tree.Clear();
            lst.Clear();
            lb.Content = "";
            obhod.IsEnabled = true;
            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Simmetry a = new Simmetry();
            a.Show();
        }
    }

    class TreeNode//класс узла дерева
    {
        public int Data;//число
        public TreeNode Left;//ссылка на левый узел
        public TreeNode Right;//ссылка на правый узел

        public TreeNode(int data)//конструктор
        {
            Data = data;
            Left = Right = null;
        }
    }

    class BinarySearchTree// класс бинарного поиска
    {
        private TreeNode root;//оъект класс treenode

        public BinarySearchTree()//конструктор
        {
            root = null;
        }
        public void Clear()
        {
            root = null; // Устанавливаем корень дерева в null, чтобы очистить все элементы
        }
        public void Insert(int data)//метод вставки
        {
            root = InsertRec(root, data);//записываем в root нужные позиции
        }

        private TreeNode InsertRec(TreeNode root, int data)
        {
            if (root == null)
            {
                root = new TreeNode(data);//задание корня
                return root;
            }

            if (data < root.Data)
            {
                root.Left = InsertRec(root.Left, data);// если меньше корня то влево(рекурсивный вызов)
            }

            else { root.Right = InsertRec(root.Right, data); }// иначе вправо(рекурсивный вызов)


            return root;
        }

        public void Delete(int data, StringBuilder steps)
        {
            root = DeleteRec(root, data,steps);
        }

        private TreeNode DeleteRec(TreeNode root, int data, StringBuilder steps)
        {
            if (root == null)
            {
                return root;
            }

            steps.AppendLine($"Шаг: Узел {root.Data}");

            if (data < root.Data)
            {
                root.Left = DeleteRec(root.Left, data, steps);
            }

            else if (data > root.Data)
            {
                root.Right = DeleteRec(root.Right, data, steps);
            }

            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }

                else if (root.Right == null)
                {
                    return root.Left;
                }

                root.Data = MinValue(root.Right);
                steps.AppendLine($"Шаг: Узел {root.Data} удален");
                root.Right = DeleteRec(root.Right, root.Data, steps);
            }

            return root;
        }


        private int MinValue(TreeNode root)
        {
            int minValue = root.Data;
            while (root.Left != null)
            {
                minValue = root.Left.Data;
                root = root.Left;
            }
            return minValue;
        }

        public string InorderTraversal()
        {
            StringBuilder result = new StringBuilder();
            InorderTraversal(root, result);
            return result.ToString();
        }

        private void InorderTraversal(TreeNode node, StringBuilder result)
        {
            if (node == null)
            {
                return;
            }

            InorderTraversal(node.Left, result);
            result.Append(node.Data).Append(" ");
            InorderTraversal(node.Right, result);
        }

        public string PreorderTraversal()
        {
            StringBuilder result = new StringBuilder();
            PreorderTraversal(root, result);
            return result.ToString();
        }

        private void PreorderTraversal(TreeNode node, StringBuilder result)
        {
            if (node == null)
            {
                return;
            }

            result.Append(node.Data).Append(" ");
            PreorderTraversal(node.Left, result);
            PreorderTraversal(node.Right, result);
        }

        public string PostorderTraversal()
        {
            StringBuilder result = new StringBuilder();
            PostorderTraversal(root, result);
            return result.ToString();
        }

        private void PostorderTraversal(TreeNode node, StringBuilder result)
        {
            if (node == null)
            {
                return;
            }

            PostorderTraversal(node.Left, result);
            PostorderTraversal(node.Right, result);
            result.Append(node.Data).Append(" ");
        }

        public int? Search(int data)
        {
            TreeNode node = Search(root, data);
            if (node != null)
            {
                return node.Data;
            }
            return null;
        }

        private TreeNode Search(TreeNode root, int data)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Data == data)
            {
                return root;
            }

            if (data < root.Data)
            {
                return Search(root.Left, data);
            }
            else { return Search(root.Right, data); }
                
        }
        ////////////////////////////////////////////////////////////////////////   вторая часть
       
    }
    
}
