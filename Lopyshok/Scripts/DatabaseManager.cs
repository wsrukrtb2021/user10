using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopyshok.Scripts
{
    class DatabaseManager
    {
        static SqlConnection conn = new SqlConnection("Data Source = WSR; Initial Catalog = user10; User = user10; Password = passuser10;");

        public static List<string[]> Select(string command)
        {
            List<string[]> row = new List<string[]>();
            try
            {
                conn.Open();
                SqlDataReader dr = new SqlCommand(command, conn).ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        string[] column = new string[dr.FieldCount];
                        for (int i = 0; i < dr.FieldCount; i++)
                            column[i] = dr[i].ToString();
                        row.Add(column);
                    }
                dr.Close();
                conn.Close();
            }
            catch (Exception e) { Console.WriteLine(e.Message); conn.Close(); }
            return row;
        }

        public static int IDU(string command)
        {
            int count = 0;
            try
            {
                conn.Open();
                count = new SqlCommand(command, conn).ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e) { Console.WriteLine(e.Message); conn.Close(); }
            return count;
        }
    }
}
