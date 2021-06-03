using Lopyshok.Scripts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Lopyshok
{
    /// <summary>
    /// Логика взаимодействия для EditOrAdd.xaml
    /// </summary>
    public partial class EditOrAdd : Window
    {
        static string id = "";

        public EditOrAdd(int typeThis, string id_)
        {
            InitializeComponent();

            id = id_;
            Console.WriteLine(id_);
            List<string[]> row = DatabaseManager.Select("SELECT Title FROM ProductType");
            for (int i = 0; i < row.Count; i++)
                typeProduct.Items.Insert(i, row[i][0]);
            typeProduct.SelectedIndex = 0;

            if (typeThis == 1)
            {
                LoadingData(id_);
                GridEdit.Visibility = Visibility.Visible;
                GridAdd.Visibility = Visibility.Hidden;
                Title += "Изменение продукции";
            }
            else if (typeThis == 2)
            {
                GridEdit.Visibility = Visibility.Hidden;
                GridAdd.Visibility = Visibility.Visible;
                Title += "Добавление продукции";
            }

        }

        private void LoadingData(string id_)
        {
            List<string[]> row = DatabaseManager.Select($@"SELECT        Product.Title, ProductType.Title AS Expr1, Product.ArticleNumber, Product.Description, Product.Image, Product.ProductionPersonCount, Product.ProductionWorkshopNumber, Product.MinCostForAgent
FROM            Product INNER JOIN
                         ProductType ON Product.ProductTypeID = ProductType.ID
WHERE Product.ID = {id_}");

            if (row.Count > 0)
            {
                TitleProduct.Text = row[0][0];
                typeProduct.Text = row[0][1];
                Article.Text = row[0][2];
                Description.Text = row[0][3];
                try
                {
                    Image.Source = new BitmapImage(
                    new Uri(Directory.GetCurrentDirectory() + row[0][4].Replace(".jpg", ".jpeg"))
                );
                } catch (Exception e) { Console.WriteLine(e.Message); }
                ImageText.Text = row[0][4];
                CountPerson.Text = row[0][5];
                NumberWorshop.Text = row[0][6];
                MinCost.Text = row[0][7];
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = DatabaseManager.IDU($"DELETE FROM [dbo].[Product] WHERE Product.ID = {id}");
                if (count > 0)
                {
                    MessageBox.Show("Удаление", "Удаление прошло успехно");
                    Close();
                }
                else
                    MessageBox.Show("Удаление", "В удаление произошла ошибка");
            } catch (Exception er) { Console.WriteLine(er.Message); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = DatabaseManager.IDU($@"UPDATE Product
                    SET Title = '{TitleProduct.Text}', 
                        ProductTypeID = {typeProduct.SelectedIndex + 1}, 
                        ArticleNumber = {Article.Text}, 
                        Description = '{Description.Text}', 
                        Image = '{ImageText.Text}', 
                        ProductionPersonCount = {CountPerson.Text}, 
                        ProductionWorkshopNumber = {NumberWorshop.Text}, 
                        MinCostForAgent = {MinCost.Text.Replace(',', '.')}
                    WHERE Product.ID = {id}");
                if (count > 0)
                {
                    MessageBox.Show("Изменение", "Изменение прошло успехно");
                    Close();
                }
                else
                    MessageBox.Show("Изменение", "В изменение произошла ошибка");
            } catch (Exception er) { Console.WriteLine(er.Message); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = DatabaseManager.IDU($@"
        INSERT INTO Product
            (Title, ProductTypeID, ArticleNumber, Description, Image, ProductionPersonCount, ProductionWorkshopNumber, MinCostForAgent)
        VALUES (
            '{TitleProduct.Text}',
            {typeProduct.SelectedIndex + 1},
            {Article.Text},
            '{Description.Text}',
            '{ImageText.Text}',
            {CountPerson.Text},
            {NumberWorshop.Text},
            {MinCost.Text.Replace(',', '.')})");
                if (count > 0)
                {
                    MessageBox.Show("Добавление", "Добавление прошло успехно");
                    Close();
                }
                else
                    MessageBox.Show("Добавление", "В добавление произошла ошибка");
            }
            catch (Exception er) { Console.WriteLine(er.Message); }
        }
    }
}
