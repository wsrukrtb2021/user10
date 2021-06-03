using Lopyshok.Scripts;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Lopyshok.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : UserControl
    {

        public string id = "";

        public Product(string image_, string type_, string name_, string article_, string productID)
        {
            InitializeComponent();

            try
            {
                Image.Source = new BitmapImage(
                    new Uri(Directory.GetCurrentDirectory() + image_.Replace(".jpg", ".jpeg"))
                );
            } catch (Exception e) { Console.WriteLine(e.Message); }
            TypeAndName.Content = $"{type_} | {name_}";
            Article.Content = article_;
            id = productID;
            Console.WriteLine(productID);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            int cost = 0;
            List<string[]> row = DatabaseManager.Select($@"SELECT        Material.Title, Material.Cost, ProductMaterial.Count
FROM            Material INNER JOIN
                         ProductMaterial ON Material.ID = ProductMaterial.MaterialID
WHERE [ProductID] = '{id}'");

            string[] s = new string[row.Count];
            for (int i = 0; i < row.Count; i ++)
            {
                s[i] = row[i][0];
                cost += Convert.ToInt32(row[i][1].Replace(",00", "")) * Convert.ToInt32(row[i][2]);
            }

            Materials.Text = string.Join(", ", s);
            Cost.Content = cost.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new EditOrAdd(1, id).ShowDialog();
        }
    }
}
