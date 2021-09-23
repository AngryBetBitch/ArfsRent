using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Globalization;

namespace SiteRentWebApp.Pages
{
   
    public class GP_Tickets : PageModel
    {

        public string resultMOSCOW = String.Empty; 
        public int currentCount = 0;
        public string name = GetArfs();
        public static List<int> spisok_ticket = new List<int>();
        public static List<string> spisok_reg = new List<string>();
        public static List<int> spisok_aab = new List<int>();
        public static List<DateTime> spisok_gpdate = new List<DateTime>();
        public static List<int> spisok_h = new List<int>();

        public void OnGet()
        {

        }
        public static void DateCur(string[] args)
        {
            DateTime dt = DateTime.Now;
            String[] format = {
            "d", "D",
            "f", "F",
            "g", "G",
            "m",
            "r",
            "s",
            "t", "T",
            "u", "U",
            "y",
            "dddd, MMMM dd yyyy",
            "ddd, MMM d \"'\"yy",
            "dddd, MMMM dd",
            "M/yy",
            "dd-MM-yy",
        };
            String date;
            for (int i = 0; i < format.Length; i++)
            {
                date = dt.ToString(format[i], DateTimeFormatInfo.InvariantInfo);
            }
        }
        private void IncrementCount()
        {
            currentCount++;
            name = GetArfs();
        }
        public static string GetArfs()
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = " SELECT top(20) MIN([gp_number]) AS [gp_ID] ,[region] ,[ACTV09_CNT] as aab ,gp_cdate  ,COUNT(*) as H FROM [siterentdb].[dbo].[monitor] inner join [siterentdb].[dbo].[houses] on [siterentdb].[dbo].[monitor].[house_id]=[siterentdb].[dbo].[houses].[house_id] where exception=1 and disconnect_date is null group by [region] ,[ACTV09_CNT] ,gp_cdate HAVING COUNT(*) >= 1 ORDER BY [gp_cdate] DESC";
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
                string columnName3 = reader.GetName(2);
                string columnName4 = reader.GetName(3);
                string columnName5 = reader.GetName(4);
                spisok_ticket.Clear();
                spisok_reg.Clear();
                spisok_aab.Clear();
                spisok_gpdate.Clear();
                spisok_h.Clear();
                while (reader.Read()) // построчно считываем данные
                {
                    object ticket = reader.GetValue(0);
                    object reg = reader.GetValue(1);
                    object aab = reader.GetValue(2);
                    object gpdate = reader.GetValue(3);
                    object h = reader.GetValue(4);
                    int tempticket = Convert.ToInt32(ticket);
                    string tempreg = Convert.ToString(reg);
                    int tempaab = Convert.ToInt32(aab);
                    DateTime tempgpdate = Convert.ToDateTime(gpdate);
                    int temph= Convert.ToInt32(h);
                    spisok_ticket.Add(tempticket);
                    spisok_reg.Add(tempreg); 
                    spisok_gpdate.Add(tempgpdate);
                    spisok_aab.Add(tempaab);
                    spisok_h.Add(temph);

                }
                result += "[" + String.Join(", ", spisok_ticket) + "]";
                result += "|";
                result += "[" + String.Join(", ", spisok_reg) + "]";
                result += "|";
                result += "[" + String.Join(", ", spisok_aab) + "]";
                result += "|";
                result += "[" + String.Join(", ", spisok_gpdate) + "]";
                result += "|";
                result += "[" + String.Join(", ", spisok_h) + "]";

            }

            connection.Close();
            return result;
        }
    }
}