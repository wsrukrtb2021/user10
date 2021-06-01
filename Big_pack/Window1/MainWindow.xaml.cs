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
using System.Data.SqlClient;
using System.IO;
using Big_pack.Class1;
using Big_pack.Control1;


namespace Big_pack
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        internal void Load_Data(string a)
        {
            // Создание подключения к бд
            using (SqlConnection connection = new SqlConnection(connection.String))
            {
                //Создание запроса на выборку
                connection.Open();
                SqlCommand command = new SqlCommand($@"SELECT [ID]
                      ,[Title]
                      ,[CountInPack]
                      ,[Unit]
                      ,[CountInStock]
                      ,[MinCount]
                      ,[Description]
                      ,[Cost]
                      ,[Image]
                      ,[MaterialTypeID]
                  FROM [dbo].[Material]");

                SqlDataReader reader = command.ExecuteReader();
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            materials_control control = new materials_control();
                            control.title_label.Content = reader[0];
                            control.countinpack_label.Content = reader[1];
                            control.unit_label.Content = reader[2];
                            control.countinstock_label.Content = reader[3];
                            control.mincount_label.Content = reader[4];
                            control.description_label.Content = reader[5];
                            control.cost_label.Content = reader[6];
                            control.Material_logo.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\" + reader[7]));
                            control.materialTypeID_label.Content = reader[8];
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Material_edit_form edit = new Material_edit_form();
            edit.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Data("");
        }
    }
}