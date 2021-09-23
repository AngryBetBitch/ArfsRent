using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;


namespace SiteRentWebApp.Pages
{

    public class GP_Counter : PageModel
    {
        public int currentCount = 0;
        public string name = GetArfs();
        public static List<string> spisok_regions = new List<string>();
        public static List<int> spisok_houses = new List<int>();

        public void OnGet()
        {

        }
        private void IncrementCount()
        {
            currentCount++;
            name = GetArfs();
        }
        public static string GetArfs()
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "SELECT [region], Count([siterentdb].[dbo].[monitor].[house_id]) FROM [siterentdb].[dbo].[monitor] inner join [siterentdb].[dbo].[houses] on [siterentdb].[dbo].[monitor].[house_id]=[siterentdb].[dbo].[houses].[house_id] where exception=1 and disconnect_date is null group by region;";
            string result = "";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                string columnName1 = reader.GetName(0);
                string columnName2 = reader.GetName(1);
                spisok_regions.Clear();
                spisok_houses.Clear();
                while (reader.Read()) // построчно считываем данные
                {
                    object region = reader.GetValue(0);
                    object houses = reader.GetValue(1);
                    string tempregion = Convert.ToString(region);
                    int temphouses = Convert.ToInt32(houses);
                    spisok_regions.Add(tempregion);
                    spisok_houses.Add(temphouses);

                }
                result += "[" + String.Join(", ", spisok_regions) + "]";
                result += "|";
                result += "[" + String.Join(", ", spisok_houses) + "]";
            }

            connection.Close();
            return result;
        }
    }
}

