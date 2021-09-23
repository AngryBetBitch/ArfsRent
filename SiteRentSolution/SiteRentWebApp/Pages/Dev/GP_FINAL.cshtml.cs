using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;


namespace SiteRentWebApp.Pages
{

    public class GP_FINAL : PageModel
    {
        public int currentCount = 0;
        public string name = GetArfs();
        public static List<int> spisok_russia = new List<int>();
        public static List<int> spisok_ticket = new List<int>();
        public static List<string> spisok_reg = new List<string>();
        public static List<int> spisok_aab = new List<int>();
        public static List<DateTime> spisok_gpdate = new List<DateTime>();
        public static List<int> spisok_h = new List<int>();
        public string resultMOSCOW = String.Empty;
        public string resultEast = String.Empty;
        public string resultWest = String.Empty;
        public string resultCenter = String.Empty;
        public string resultSouth = String.Empty;
        public List<string> publicListOfTickets = GetArfsTickets();
        public List<string> publicListOfMonth = GetArfsmonth();
        public List<string> publicListOHouses = GetArfsTHouse();
        public List<string> publicListOfDays = GetArfsDays();
        public string SumDays = "";
        public string SumDates = "";
        // public int sumReg = resultSouth.Split("|")[1] + resultCenter.Split("|")[1] + resultWest.Split("|")[1] + resultEast.Split("|")[1] + resultMOSCOW.Split("|")[1];
        public int SumR;
        public string Sumon;
        //string[] array = publicListOfTickets.ToArray();

        public void OnGet()
        {
            resultMOSCOW = GetArfsRegions("Москва");
            resultEast = GetArfsRegions("Восток");
            resultWest = GetArfsRegions("Запад");
            resultCenter = GetArfsRegions("Центр");
            resultSouth = GetArfsRegions("Юг");
            string MonthResult = "";
            for (int i = 0; i < publicListOfMonth.Count; i++)
            {
                MonthResult += publicListOfMonth[i];
            }
            SumDays += "["+ MonthResult +"]";
            SumDays = SumDays.Substring(0, 149);
            SumDays = SumDays + "]";
            string DaysResult = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                DaysResult += publicListOfDays[j];
            }
            SumDates += "[" + DaysResult + "]";
            SumDates = SumDates.Substring(0, 329);
            SumDates = SumDates + "]";
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
                result += String.Join(", ", spisok_russia);
                result += "|";

            }

            connection.Close();
            return result;
        }

        public static List<string> GetArfsTickets()
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = " SELECT top(5) MIN([gp_number]) AS [gp_ID] ,[region] ,[ACTV09_CNT] as aab ,gp_cdate  ,COUNT(*) as H FROM [siterentdb].[dbo].[monitor] inner join [siterentdb].[dbo].[houses] on [siterentdb].[dbo].[monitor].[house_id]=[siterentdb].[dbo].[houses].[house_id] where exception=1 and disconnect_date is null group by [region] ,[ACTV09_CNT] ,gp_cdate HAVING COUNT(*) >= 1 ORDER BY [gp_cdate] DESC";
            SqlConnection connectionT = new SqlConnection(connectionString);

            List<string> resultTickets = new List<string>();

            connectionT.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionT);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    //массив object[FieldCount]


                    string CurrentReaderRow = reader.GetValue(0) + "|" + reader.GetValue(1) + "|" + reader.GetValue(2) + "|" + reader.GetValue(3) + "|" + reader.GetValue(4);
                    resultTickets.Add(CurrentReaderRow);
                }

            }
            connectionT.Close();
            return resultTickets;

        }

        public static string GetArfsRegions(string regionInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "Select rego,tes3,h,Dyna, aab from (SELECT [region]as rego, Count([siterentdb].[dbo].[monitor].[house_id]) as h ,SUM([ACTV09_CNT]) as  AAB FROM [siterentdb].[dbo].[monitor] inner join [siterentdb].[dbo].[houses] on [siterentdb].[dbo].[monitor].[house_id]=[siterentdb].[dbo].[houses].[house_id] where exception=1 and disconnect_date is null and region='" + regionInput + "' group by region) as pudg inner join ( select REG AS REG1,tes as tes3, dynamics AS Dyna from  (select REG, tes, tes2, (tes2-tes)as dynamics from(SELECT [region] AS REG, Count([siterentdb].[dbo].[monitor].[house_id])as tes2 FROM [siterentdb].[dbo].[monitor] inner join [siterentdb].[dbo].[houses] on [siterentdb].[dbo].[monitor].[house_id]=[siterentdb].[dbo].[houses].[house_id] where exception=1 and disconnect_date is null and region='" + regionInput + "' group by region) as p2 inner join (select REGIUS, tes from (select top (1) [region] as REGIUS,gp as tes, filial FROM [siterentdb].[dbo].[arfs_dynamics] where region='" + regionInput + "' and filial='Итого' order by [report_date] desc ) as p) as D1 on REG=REGIUS) AS Great) as Great2 on rego=REG1";
            string result = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    string columnName2 = reader.GetValue(1).ToString();
                    string columnName3 = reader.GetValue(2).ToString();
                    string columnName4 = reader.GetValue(3).ToString();
                    string columnName5 = reader.GetValue(4).ToString();
                    result += String.Join(", ", columnName1);
                    result += "|";
                    result +=  String.Join(", ", columnName2);
                    result += "|";
                    result += String.Join(", ", columnName3);
                    result += "|";
                    result += String.Join(", ", columnName4);
                    result += "|";
                    result += String.Join(", ", columnName5);
                }

            }

            connectionR.Close();
            return result;
        }

        public static List<string> GetArfsmonth()
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = " select gp from (SELECT TOP (30)report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Россия' and filial='Итого' order by report_date desc)as fu order by report_date asc";

            SqlConnection connectionMon = new SqlConnection(connectionString);
            List<string> resultMonths = new List<string>();
            connectionMon.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionMon);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    //массив object[FieldCount]


                    string CurrentReaderRowMon = reader.GetValue(0) + ", ";
                    resultMonths.Add(CurrentReaderRowMon);
                }

            }
            connectionMon.Close();
            return resultMonths;
           
        }

        public static List<string> GetArfsTHouse()
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "SELECT top(5) count([siterentdb].[dbo].[monitor].[house_id]) as Cou ,gp_number as gg ,region,sum([ACTV09_CNT]) as CNT FROM [siterentdb].[dbo].[monitor] INNER join [siterentdb].[dbo].[houses] on [siterentdb].[dbo].[monitor].house_id=[siterentdb].[dbo].[houses].house_id where disconnect_date is NULL AND exception = '1' group by[gp_number], region  order by Cou Desc";
            SqlConnection connectionH = new SqlConnection(connectionString);

            List<string> resultHouse = new List<string>();

            connectionH.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionH);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    //массив object[FieldCount]


                    string CurrentReaderRow = reader.GetValue(0) + "|" + reader.GetValue(1) + "|" + reader.GetValue(2) + "|" + reader.GetValue(3) + "|";
                    resultHouse.Add(CurrentReaderRow);
                }

            }
            connectionH.Close();
            return resultHouse;

        }

        public static List<string> GetArfsDays()
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select report_date from (SELECT TOP (30)report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Россия' and filial='Итого' order by report_date desc)as fu order by report_date asc";

            SqlConnection connectionDays = new SqlConnection(connectionString);
            List<string> resultDays = new List<string>();
            connectionDays.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionDays);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    //массив object[FieldCount]


                    string CurrentReaderRowDay = "\" " + reader.GetValue(0);
                    CurrentReaderRowDay = CurrentReaderRowDay.Substring(0, 13);
                    CurrentReaderRowDay = CurrentReaderRowDay +  ", ";
                    CurrentReaderRowDay = CurrentReaderRowDay.Substring(1, 13);
                   // CurrentReaderRowDay = CurrentReaderRowDay.Replace("\","" ");
                    resultDays.Add(CurrentReaderRowDay);
                }

            }
            connectionDays.Close();
            return resultDays;

        }
    }
}


