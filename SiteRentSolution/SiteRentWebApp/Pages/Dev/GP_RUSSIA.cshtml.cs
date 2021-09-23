using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;


namespace SiteRentWebApp.Pages
{

    public class GP_RUSSIA : PageModel
    {
        public int currentCount = 0;
        public string name = GetArfs();
        public static List<int> spisok_russia = new List<int>();

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
            string sqlExpression = "select Count([siterentdb].[dbo].[monitor].[house_id]) as Russia FROM [siterentdb].[dbo].[monitor] inner join [siterentdb].[dbo].[houses] on [siterentdb].[dbo].[monitor].[house_id]=[siterentdb].[dbo].[houses].[house_id] where exception=1 and disconnect_date is null";
            string result = "";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                string columnName1 = reader.GetName(0);
                spisok_russia.Clear();
                while (reader.Read()) // построчно считываем данные
                {
                    object russia = reader.GetValue(0);
                    int temprussia = Convert.ToInt32(russia);
                    spisok_russia.Add(temprussia);

                }
                result += "[" + String.Join(", ", spisok_russia) + "]";
                result += "|";
            
            }

            connection.Close();
            return result;
        }
    }
}