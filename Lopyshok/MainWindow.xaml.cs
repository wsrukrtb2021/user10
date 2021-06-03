using Lopyshok.Scripts;
using Lopyshok.UserControls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lopyshok
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            loadTypeProduct();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();

            foreach (ComboBox control in new ComboBox[] { OrderBy, OrderByType, TypeProduct })
                control.SelectionChanged += SelectionChanged;
            
        }


        private void LoadData()
        {
            Main.Children.Clear();
            List<string[]> row = DatabaseManager.Select($@"SELECT        Product.Image, ProductType.Title, Product.Title AS Expr1, Product.ArticleNumber, Product.ID
FROM            Product INNER JOIN
                         ProductType ON Product.ProductTypeID = ProductType.ID
{getCurrentWhere()}
{getCurrentOrder(OrderBy.SelectedIndex, OrderByType.SelectedIndex)}
");
            foreach (string[] column in row)
            {
                Main.Children.Add(
                        new Product(column[0], column[1], column[2], column[3], column[4])
                    );
            }

        }

        private void loadTypeProduct()
        {
            TypeProduct.Items.Insert(0, "Все типы");
            List<string[]> row = DatabaseManager.Select(@"SELECT ProductType.Title FROM ProductType");
            for (int i = 0; i < row.Count; i++)
                TypeProduct.Items.Insert(i + 1, row[i][0]);

            TypeProduct.SelectedIndex = 0;
        }

        string getCurrentOrder(int iOrder, int iOrderType)
        {
            switch (iOrder)
            {
                case 0:
                    return $"ORDER BY {getCurrentOrderType(iOrderType)} ASC";
                case 1:
                    return $"ORDER BY {getCurrentOrderType(iOrderType)} DESC";
            }
            return "";
        }

        string getCurrentOrderType(int i)
        {
            switch (i)
            {
                case 0:
                    return "Product.Title";
                case 1:
                    return "Product.ProductionWorkshopNumber";
                case 2:
                    return "Product.MinCostForAgent";
            }
            return "";
        }

        string getCurrentWhere()
        {
            return $" WHERE Product.Title LIKE '{Search.Text}%' and ProductType.Title LIKE '{getCurrentTypeProduct(TypeProduct.SelectedIndex)}%' ";
        }

        string getCurrentTypeProduct(int i)
        {
            switch (i)
            {
                case 0:
                    return "";
                default:
                    return TypeProduct.SelectedItem.ToString();
            }
        }
       
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new EditOrAdd(2, "0").ShowDialog();
        }
    }
}
