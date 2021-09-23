using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SiteRentWebApp.Pages
{

    public class GP_West : PageModel
    {
        public int currentCount = 0;
        public string name = GetArfs();
        public static List<int> spisok_russia = new List<int>();
        public static List<int> spisok_ticket = new List<int>();
        public static List<string> spisok_reg = new List<string>();
        public static List<int> spisok_aab = new List<int>();
        public static List<DateTime> spisok_gpdate = new List<DateTime>();
        public static List<int> spisok_h = new List<int>();
        public static List<string> publicListOfMonthArch = new List<string>();
        public static List<string> publicListOfMonthVologda = new List<string>();
        public static List<string> publicListOfMonthIvanovo = new List<string>();
        public static List<string> publicListOfMonthKaliningrad = new List<string>();
        public static List<string> publicListOfMonthKaluga = new List<string>();
        public static List<string> publicListOfMonthKostroma = new List<string>();
        public static List<string> publicListOfMonthMurmansk = new List<string>();
        public static List<string> publicListOfMonthPeter = new List<string>();
        public static List<string> publicListOfMonthSmolensk = new List<string>();
        public static List<string> publicListOfMonthTver = new List<string>();
        public static List<string> publicListOfMonthTula = new List<string>();
        public static List<string> publicListOfMonthYaro = new List<string>();
        public static List<string> publicListOflineArch = new List<string>();
        public string resultMOSCOW = String.Empty;
        public string resultEast = String.Empty;
        public string resultWest = String.Empty;
        public string resultCenter = String.Empty;
        public string resultSouth = String.Empty;
        public string resultArh = String.Empty;
        public string resultVologda = String.Empty;
        public string resultIvanovo = String.Empty;
        public string resultkalinin = String.Empty;
        public string resultkaluga = String.Empty;
        public string resultkostroma = String.Empty;
        public string resultmurmansk = String.Empty;
        public string resultpeter = String.Empty;
        public string resultSmolensk = String.Empty;
        public string resultTver = String.Empty;
        public string resultTula = String.Empty;
        public string resultYaro = String.Empty;
        public List<string> publicListOfTickets = GetArfsTickets();
        public List<string> publicListOfMonth = GetArfsmonth();
        public List<string> publicListOHouses = GetArfsTHouse();
        public List<string> publicListOfDays = GetArfsDays();
        public List<string> publicListofGpWest = GetWestCountGP();
        public List<string> publiclistofFilWest = GetWestFilials();
        public List<string> publiclistofarfsWest = GetArfsmonthArfsWest();
        //public List<string> publiclistofBigArfsWest = GetBigArfsWestListAsync().Result;
        public string SumDays = "";
        public string LARFSW = "";
        public string SumDates = "";
        public string SumArch = "";
        public string SumVologda = "";
        public string SumIvanovo = "";
        public string SumKalinin = "";
        public string SumKaluga = "";
        public string SumKostroma = "";
        public string SumMurmansk = "";
        public string SumPeter = "";
        public string SumSmol = "";
        public string SumTver = "";
        public string SumTula= "";
        public string SumYaros = "";
        public string SumGPWest = "";
        public string SumFilWest = "";
        public string SumItogo = "";
        public string LineArch = "";
        public string LineVologda = "";
        public string LineKalinin = "";
        public string LineKaluga = "";
        public string LineKostroma = "";
        public string LineMurmansk = "";
        public string LinePeter = "";
        public string LineSmol = "";
        public string LineTver = "";
        public string LineTula = "";
        public string LineYaro = "";
        public string LineIvanovo = "";
        public string LineWest = "";
        // public int sumReg = resultSouth.Split("|")[1] + resultCenter.Split("|")[1] + resultWest.Split("|")[1] + resultEast.Split("|")[1] + resultMOSCOW.Split("|")[1];
        public int SumR;
        public string Sumon;
        public TimeSpan DtLoad = TimeSpan.Zero;
        //string[] array = publicListOfTickets.ToArray();

        public void OnGet()
        {
            DateTime DtStart = DateTime.Now;
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
            SumDays += "["+ MonthResult;
            SumDays = SumDays.Substring(0, SumDays.Length-2);
            SumDays = SumDays + "]";
            
            string DaysResult = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                DaysResult += publicListOfDays[j];
            }
            SumDates += "[" + DaysResult + "]";
            SumDates = SumDates.Substring(0, 8*publicListOfDays.Count);
            SumDates = SumDates + "]";

            string WarfsResult = "";
            for (int i = 0; i < publiclistofarfsWest.Count; i++)
            {
                WarfsResult += publiclistofarfsWest[i];
            }
            LARFSW += "[" + WarfsResult;
            LARFSW = LARFSW.Substring(0, LARFSW.Length - 2);
            LARFSW = LARFSW + "]";
            #region BigSelect
            //Проба для большого
            // string BigArfsResult = "";
            // for (int m = 0; m < publiclistofBigArfsWest.Count/13; m++)
            // {
            //     BigArfsResult += publiclistofBigArfsWest[m];
            // }
            // SumArch += "[" + BigArfsResult + "]";
            // SumArch = SumArch.Substring(0, 8 * publiclistofBigArfsWest.Count/13);
            // SumArch = SumArch.Replace(",", ".");
            // SumArch = SumArch.Replace("!", ",");
            // SumArch = SumArch + "]";

            // string BigArfsResultVologda = "";
            // for (int m = publiclistofBigArfsWest.Count / 13+1; m < (publiclistofBigArfsWest.Count / 13)*2; m++)
            // {
            //     BigArfsResultVologda += publiclistofBigArfsWest[m];
            // }
            // SumVologda += "[" + BigArfsResultVologda.Substring(0, BigArfsResultVologda.Length - 2) + "]";
            // SumVologda = SumVologda.Replace(",", ".");
            // SumVologda = SumVologda.Replace("!", ",");

            // string BigArfsResultIvanovo = "";
            // for (int m = (publiclistofBigArfsWest.Count / 13) * 2+1; m <= (publiclistofBigArfsWest.Count / 13) * 3; m++)
            // {
            //     BigArfsResultIvanovo += publiclistofBigArfsWest[m];
            // }
            // SumIvanovo += "[" + BigArfsResultIvanovo + "]";
            // SumIvanovo = SumIvanovo.Substring(0, 8 * publiclistofBigArfsWest.Count / 13);
            // SumIvanovo = SumIvanovo.Replace(",", ".");
            // SumIvanovo = SumIvanovo.Replace("!", ",");
            // SumIvanovo = SumIvanovo + "]";

            // //string BigArfsResultItogo = "";
            // //for (int m = publiclistofBigArfsWest.Count / 13*3 + 1; m < (publiclistofBigArfsWest.Count / 13) * 4; m++)
            // //{
            //   //  BigArfsResultItogo += BigArfsResultItogo[m];
            // //  }
            // //SumItogo += "[" + BigArfsResultItogo.Substring(0, BigArfsResultItogo.Length - 2) + "]";
            // //SumItogo = SumItogo.Replace(",", ".");
            //// SumItogo = SumItogo.Replace("!", ",");

            // string BigArfsResultKalinin = "";
            // for (int m = publiclistofBigArfsWest.Count / 13 * 4 + 1; m < (publiclistofBigArfsWest.Count / 13) * 5; m++)
            // {
            //     BigArfsResultKalinin += publiclistofBigArfsWest[m];
            // }
            // SumKalinin += "[" + BigArfsResultKalinin.Substring(0, BigArfsResultKalinin.Length - 2) + "]";
            // SumKalinin = SumKalinin.Replace(",", ".");
            // SumKalinin = SumKalinin.Replace("!", ",");

            // string BigArfsResultKakuga = "";
            // for (int m = publiclistofBigArfsWest.Count / 13 * 5 + 1; m < (publiclistofBigArfsWest.Count / 13) * 6; m++)
            // {
            //     BigArfsResultKakuga += publiclistofBigArfsWest[m];
            // }
            // SumKaluga += "[" + BigArfsResultKakuga.Substring(0, BigArfsResultKakuga.Length - 2) + "]";
            // SumKaluga = SumKaluga.Replace(",", ".");
            // SumKaluga = SumKaluga.Replace("!", ",");

            // string BigArfsResultKostroma = "";
            // for (int m = publiclistofBigArfsWest.Count / 13 * 6 + 1; m < (publiclistofBigArfsWest.Count / 13) * 7; m++)
            // {
            //     BigArfsResultKostroma += publiclistofBigArfsWest[m];
            // }
            // SumKostroma += "[" + BigArfsResultKostroma.Substring(0, BigArfsResultKostroma.Length - 2) + "]";
            // SumKostroma = SumKostroma.Replace(",", ".");
            // SumKostroma = SumKostroma.Replace("!", ",");

            // string BigArfsResultMurmansk = "";
            // for (int m = publiclistofBigArfsWest.Count / 13 * 7 + 1; m < (publiclistofBigArfsWest.Count / 13) * 8; m++)
            // {
            //     BigArfsResultMurmansk += publiclistofBigArfsWest[m];
            // }
            // SumMurmansk += "[" + BigArfsResultKostroma.Substring(0, BigArfsResultKostroma.Length - 2) + "]";
            // SumMurmansk = SumMurmansk.Replace(",", ".");
            // SumMurmansk = SumMurmansk.Replace("!", ",");

            // string BigArfsResultPeter = "";
            // for (int m = publiclistofBigArfsWest.Count / 13 * 8 + 1; m < (publiclistofBigArfsWest.Count / 13) * 9; m++)
            // {
            //     BigArfsResultPeter += publiclistofBigArfsWest[m];
            // }
            // SumPeter += "[" + BigArfsResultPeter.Substring(0, BigArfsResultPeter.Length - 2) + "]";
            // SumPeter = SumPeter.Replace(",", ".");
            // SumPeter = SumPeter.Replace("!", ",");

            // string BigArfsResultSmol = "";
            // for (int m = publiclistofBigArfsWest.Count / 13 * 9 + 1; m < (publiclistofBigArfsWest.Count / 13) * 10; m++)
            // {
            //     BigArfsResultSmol += publiclistofBigArfsWest[m];
            // }
            // SumSmol += "[" + BigArfsResultSmol.Substring(0, BigArfsResultSmol.Length - 2) + "]";
            // SumSmol = SumSmol.Replace(",", ".");
            // SumSmol = SumSmol.Replace("!", ",");

            // string BigArfsResultTver = "";
            // for (int m = publiclistofBigArfsWest.Count / 13 * 10 + 1; m < (publiclistofBigArfsWest.Count / 13) * 11; m++)
            // {
            //     BigArfsResultTver += publiclistofBigArfsWest[m];
            // }
            // SumTver += "[" + BigArfsResultTver.Substring(0, BigArfsResultTver.Length - 2) + "]";
            // SumTver = SumTver.Replace(",", ".");
            // SumTver = SumTver.Replace("!", ",");

            // string BigArfsResultTula = "";
            // for (int m = publiclistofBigArfsWest.Count / 13 * 11 + 1; m < (publiclistofBigArfsWest.Count / 13) * 12; m++)
            // {
            //     BigArfsResultTula += publiclistofBigArfsWest[m];
            // }
            // SumTula += "[" + BigArfsResultTula.Substring(0, BigArfsResultTula.Length - 2) + "]";
            // SumTula = SumTula.Replace(",", ".");
            // SumTula = SumTula.Replace("!", ",");

            // string BigArfsResultYaro = "";
            // for (int m = publiclistofBigArfsWest.Count / 13 * 12 + 1; m < (publiclistofBigArfsWest.Count / 13) * 13; m++)
            // {
            //     BigArfsResultYaro += publiclistofBigArfsWest[m];
            // }
            // SumYaros += "[" + BigArfsResultYaro.Substring(0, BigArfsResultYaro.Length - 2) + "]";
            // SumYaros = SumYaros.Replace(",", ".");
            // SumYaros = SumYaros.Replace("!", ",");

            #endregion BigSelect

            //Проба для Архангельска
            resultArh = GetArfsmonthWestByFilial("Архангельский ф-л");
            SumArch = "[" + resultArh.Substring(0, resultArh.Length - 2) + "]";
            
            string Archline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Archline = Archline.Insert(0,"0.73, ");
            }
            LineArch += "[" + Archline + "]";
            LineArch = LineArch.Substring(0, 6 * publicListOfDays.Count-1);
            LineArch = LineArch + "]";



            //Проба для Вологды
            resultVologda = GetArfsmonthWestByFilial("Вологодский ф-л");
            SumVologda = "[" + resultVologda.Substring(0, resultVologda.Length - 2) + "]";

            string Volline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Volline = Volline.Insert(0, "0.34, ");
            }
            LineVologda += "[" + Volline + "]";
            LineVologda = LineVologda.Substring(0, 6 * publicListOfDays.Count - 1);
            LineVologda = LineVologda + "]";

            //Проба для Иваново
            resultIvanovo = GetArfsmonthWestByFilial("Ивановский ф-л");
               SumIvanovo = "[" + resultIvanovo.Substring(0, resultIvanovo.Length - 2) + "]";

            string Ivanovoline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Ivanovoline = Ivanovoline.Insert(0, "3.98, ");
            }
            LineIvanovo += "[" + Ivanovoline + "]";
            LineIvanovo = LineIvanovo.Substring(0, 6 * publicListOfDays.Count - 1);
            LineIvanovo = LineIvanovo + "]";

            //Проба для Калининграда
            resultkalinin = GetArfsmonthWestByFilial("Калининградский ф-л");
               SumKalinin = "[" + resultkalinin.Substring(0, resultkalinin.Length - 2) + "]";
       
            string Kalininline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Kalininline = Kalininline.Insert(0, "0.25, ");
            }
            LineKalinin += "[" + Kalininline + "]";
            LineKalinin = LineKalinin.Substring(0, 6 * publicListOfDays.Count - 1);
            LineKalinin = LineKalinin + "]";

               //Проба для Костромы
               resultkostroma = GetArfsmonthWestByFilial("Костромской ф-л");
               SumKostroma = "[" + resultkostroma.Substring(0, resultkostroma.Length - 2) + "]";

            string Kostromaline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Kostromaline = Kostromaline.Insert(0, "0.31, ");
            }
            LineKostroma += "[" + Kostromaline + "]";
            LineKostroma = LineKostroma.Substring(0, 6 * publicListOfDays.Count - 1);
            LineKostroma = LineKostroma + "]";

            //Проба для Калуги
            resultkaluga = GetArfsmonthWestByFilial("Калужский ф-л");
               SumKaluga = "[" + resultkaluga.Substring(0, resultkaluga.Length - 2) + "]";

            string Kalugaline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Kalugaline = Kalugaline.Insert(0, "0.3, ");
            }
            LineKaluga += "[" + Kalugaline + "]";
            LineKaluga = LineKaluga.Substring(0, 5 * publicListOfDays.Count - 1);
            LineKaluga = LineKaluga + "]";


               //Проба для Мурманска
               resultmurmansk = GetArfsmonthWestByFilial("Мурманский ф-л");
               SumMurmansk = "[" + resultmurmansk.Substring(0, resultmurmansk.Length - 2) + "]";

            string Murmanskline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Murmanskline = Murmanskline.Insert(0, "1.64, ");
            }
            LineMurmansk += "[" + Murmanskline + "]";
            LineMurmansk = LineMurmansk.Substring(0, 6 * publicListOfDays.Count - 1);
            LineMurmansk = LineMurmansk + "]";


            //Проба для пи ера
            resultpeter = GetArfsmonthWestByFilial("Санкт-Петербургский ф-л");
               SumPeter = "[" + resultpeter.Substring(0, resultpeter.Length - 2) + "]";

            string Peterline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Peterline = Peterline.Insert(0, "0.76, ");
            }
            LinePeter += "[" + Peterline + "]";
            LinePeter = LinePeter.Substring(0, 6 * publicListOfDays.Count - 1);
            LinePeter = LinePeter + "]";

            //Проба для Cмоленска
            resultSmolensk = GetArfsmonthWestByFilial("Смоленский ф-л");
               SumSmol = "[" + resultSmolensk.Substring(0, resultSmolensk.Length - 2) + "]";

            string Smolline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Smolline = Smolline.Insert(0, "0.34, ");
            }
            LineSmol += "[" + Smolline + "]";
            LineSmol = LineSmol.Substring(0, 6 * publicListOfDays.Count - 1);
            LineSmol = LineSmol + "]";

            //Проба для Твери
            resultTver = GetArfsmonthWestByFilial("Тверской ф-л");
               SumTver = "[" + resultTver.Substring(0, resultTver.Length - 2) + "]";

            string Tverline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Tverline = Tverline.Insert(0, "0.78, ");
            }
            LineTver += "[" + Tverline + "]";
            LineTver = LineTver.Substring(0, 6 * publicListOfDays.Count - 1);
            LineTver = LineTver + "]";

            //Проба для Тулы
            resultTula = GetArfsmonthWestByFilial("Тульский ф-л");
               SumTula = "[" + resultTula.Substring(0, resultTula.Length - 2) + "]";

            string Tulaline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Tulaline = Tulaline.Insert(0, "0.4, ");
            }
            LineTula += "[" + Tulaline + "]";
            LineTula = LineTula.Substring(0, 5 * publicListOfDays.Count - 1);
            LineTula = LineTula + "]";


            //Проба для Ярика
            resultYaro = GetArfsmonthWestByFilial("Ярославский ф-л");
               SumYaros = "[" + resultYaro.Substring(0, resultYaro.Length - 2) + "]";
            string Yaroline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Yaroline = Yaroline.Insert(0, "0.35, ");
            }
            LineYaro += "[" + Yaroline + "]";
            LineYaro = LineYaro.Substring(0, 6 * publicListOfDays.Count - 1);
            LineYaro = LineYaro + "]";


            //Линия Запад
            string Westline = "";
            for (int j = 0; j < publicListOfDays.Count; j++)
            {
                Westline = Westline.Insert(0, "0.72, ");
            }
            LineWest += "[" + Westline + "]";
            LineWest = LineWest.Substring(0, 6 * publicListOfDays.Count - 1);
            LineWest = LineWest + "]";


            string WestGpResult = "";
            for (int i = 0; i < publicListofGpWest.Count; i++)
            {
                WestGpResult += publicListofGpWest[i];
            }
            SumGPWest += "[" + WestGpResult;
            SumGPWest = SumGPWest.Substring(0, SumGPWest.Length - 2);
            SumGPWest = SumGPWest + "]";

            string WestFilResult = "";
            for (int j = 0; j < publiclistofFilWest.Count; j++)
            {
                WestFilResult += publiclistofFilWest[j];
            }
            SumFilWest += "[" + WestFilResult + "]";
            SumFilWest = SumFilWest.Substring(0, SumFilWest.Length-2);
            SumFilWest = SumFilWest + "]";
            DateTime DtEnd = DateTime.Now;
            DtLoad = DtEnd - DtStart;
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
            string sqlExpression = "SELECT top(10) MIN([gp_number]) AS [gp_ID] ,[region] ,[ACTV09_CNT] as aab ,gp_cdate  ,COUNT(*) as H FROM [siterentdb].[dbo].[monitor] inner join [siterentdb].[dbo].[houses] on [siterentdb].[dbo].[monitor].[house_id]=[siterentdb].[dbo].[houses].[house_id] where region='Запад' and exception=1 and disconnect_date is null group by [region] ,[ACTV09_CNT] ,gp_cdate HAVING COUNT(*) >= 1 ORDER BY [gp_cdate] DESC";
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
            string sqlExpression = "select gp from (SELECT report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='Итого' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";

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

        public static List<string> GetArfsmonthArfsWest()
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='Итого' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";

            SqlConnection connectionMon = new SqlConnection(connectionString);
            List<string> resultArfsWestList = new List<string>();
            connectionMon.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionMon);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    //массив object[FieldCount]


                    string CurrentReaderRowMon = reader.GetValue(0) + "! ";
                    CurrentReaderRowMon= CurrentReaderRowMon.Replace(",", ".");
                    CurrentReaderRowMon = CurrentReaderRowMon.Replace("!", ",");
                    resultArfsWestList.Add(CurrentReaderRowMon);
                }
            }
            connectionMon.Close();
            return resultArfsWestList;

        }

        public static List<string> GetArfsTHouse()
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "SELECT top(10) count([siterentdb].[dbo].[monitor].[house_id]) as Cou ,gp_number as gg ,region,sum([ACTV09_CNT]) as CNT FROM [siterentdb].[dbo].[monitor] INNER join [siterentdb].[dbo].[houses] on [siterentdb].[dbo].[monitor].house_id=[siterentdb].[dbo].[houses].house_id where region='Запад' and disconnect_date is NULL AND exception = '1' group by[gp_number], region  order by Cou Desc";
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
            string sqlExpression = "select report_date from (SELECT report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='Итого' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";

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

                    char c = '"';
                    string CurrentReaderRowDay = c + reader.GetValue(0).ToString().Substring(0,5) + c;
                    //CurrentReaderRowDay = CurrentReaderRowDay.Substring(0, 13);
                    CurrentReaderRowDay = CurrentReaderRowDay +  ",";
                    //CurrentReaderRowDay = CurrentReaderRowDay.Substring(1, 13);
                   // CurrentReaderRowDay = CurrentReaderRowDay.Replace("\","" ");
                    resultDays.Add(CurrentReaderRowDay);
                }

            }
            connectionDays.Close();
            return resultDays;

        }
        public static string GetArfsmonthWest(string filialInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='" + filialInput + "' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";
            string resultWest = "";
            string WestR = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    publicListOfMonthArch.Clear();
                    WestR += columnName1;
                    WestR = WestR + "! ";
                    publicListOfMonthArch.Add(WestR);
                   // Рабочее
                   //resultWest += columnName1;
                   //resultWest = resultWest + ", ";

                }

                resultWest += String.Join("", publicListOfMonthArch);
                resultWest = resultWest.Replace(",", ".");
                resultWest = resultWest.Replace("!", ",");
            }

            connectionR.Close();
           // publicListOfMonthArch.Add(resultWest);
            return resultWest;
        }

        public static string GetArfsmonthWestVologda(string filialInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='" + filialInput + "' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";
            string resultWest = "";
            string WestR = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    publicListOfMonthVologda.Clear();
                    WestR += columnName1;
                    WestR = WestR + "! ";
                    publicListOfMonthVologda.Add(WestR);
                    // Рабочее
                    //resultWest += columnName1;
                    //resultWest = resultWest + ", ";

                }

                resultWest += String.Join("", publicListOfMonthVologda);
                resultWest = resultWest.Replace(",", ".");
                resultWest = resultWest.Replace("!", ",");
            }

            connectionR.Close();
            // publicListOfMonthArch.Add(resultWest);
            return resultWest;
        }

        public static string GetArfsmonthWestIvanovo(string filialInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='" + filialInput + "' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";
            string resultWest = "";
            string WestR = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    publicListOfMonthIvanovo.Clear();
                    WestR += columnName1;
                    WestR = WestR + "! ";
                    publicListOfMonthIvanovo.Add(WestR);
                    // Рабочее
                    //resultWest += columnName1;
                    //resultWest = resultWest + ", ";

                }

                resultWest += String.Join("", publicListOfMonthIvanovo);
                resultWest = resultWest.Replace(",", ".");
                resultWest = resultWest.Replace("!", ",");
            }

            connectionR.Close();
            // publicListOfMonthArch.Add(resultWest);
            return resultWest;
        }

        public static string GetArfsmonthWestKaliningrad(string filialInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='" + filialInput + "' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";
            string resultWest = "";
            string WestR = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    publicListOfMonthKaliningrad.Clear();
                    WestR += columnName1;
                    WestR = WestR + "! ";
                    publicListOfMonthKaliningrad.Add(WestR);
                    // Рабочее
                    //resultWest += columnName1;
                    //resultWest = resultWest + ", ";

                }

                resultWest += String.Join("", publicListOfMonthKaliningrad);
                resultWest = resultWest.Replace(",", ".");
                resultWest = resultWest.Replace("!", ",");
            }

            connectionR.Close();
            // publicListOfMonthArch.Add(resultWest);
            return resultWest;
        }


        public static string GetArfsmonthWestKaluga(string filialInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='" + filialInput + "' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";
            string resultWest = "";
            string WestR = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    publicListOfMonthKaluga.Clear();
                    WestR += columnName1;
                    WestR = WestR + "! ";
                    publicListOfMonthKaluga.Add(WestR);
                    // Рабочее
                    //resultWest += columnName1;
                    //resultWest = resultWest + ", ";

                }

                resultWest += String.Join("", publicListOfMonthKaluga);
                resultWest = resultWest.Replace(",", ".");
                resultWest = resultWest.Replace("!", ",");
            }

            connectionR.Close();
            // publicListOfMonthArch.Add(resultWest);
            return resultWest;
        }

        public static string GetArfsmonthWestKostroma(string filialInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='" + filialInput + "' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";
            string resultWest = "";
            string WestR = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    publicListOfMonthKostroma.Clear();
                    WestR += columnName1;
                    WestR = WestR + "! ";
                    publicListOfMonthKostroma.Add(WestR);
                    // Рабочее
                    //resultWest += columnName1;
                    //resultWest = resultWest + ", ";

                }

                resultWest += String.Join("", publicListOfMonthKostroma);
                resultWest = resultWest.Replace(",", ".");
                resultWest = resultWest.Replace("!", ",");
            }

            connectionR.Close();
            // publicListOfMonthArch.Add(resultWest);
            return resultWest;
        }

        public static string GetArfsmonthWestMurmansk(string filialInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='" + filialInput + "' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";
            string resultWest = "";
            string WestR = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    publicListOfMonthMurmansk.Clear();
                    WestR += columnName1;
                    WestR = WestR + "! ";
                    publicListOfMonthMurmansk.Add(WestR);
                    // Рабочее
                    //resultWest += columnName1;
                    //resultWest = resultWest + ", ";

                }

                resultWest += String.Join("", publicListOfMonthMurmansk);
                resultWest = resultWest.Replace(",", ".");
                resultWest = resultWest.Replace("!", ",");
            }

            connectionR.Close();
            // publicListOfMonthArch.Add(resultWest);
            return resultWest;
        }

        public static string GetArfsmonthWestPeter(string filialInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='" + filialInput + "' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";
            string resultWest = "";
            string WestR = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    publicListOfMonthPeter.Clear();
                    WestR += columnName1;
                    WestR = WestR + "! ";
                   // WestR = WestR.Replace(".", ",");
                    publicListOfMonthPeter.Add(WestR);
                    // Рабочее
                    //resultWest += columnName1;
                    //resultWest = resultWest + ", ";

                }

                resultWest += String.Join("", publicListOfMonthPeter);
                resultWest = resultWest.Replace(",", ".");
                resultWest= resultWest.Replace("!", ",");
            }

            connectionR.Close();
            // publicListOfMonthArch.Add(resultWest);
            return resultWest;
        }

        public static string GetArfsmonthWestSmolensk(string filialInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='" + filialInput + "' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";
            string resultWest = "";
            string WestR = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    publicListOfMonthSmolensk.Clear();
                    WestR += columnName1;
                    WestR = WestR + "! ";
                    publicListOfMonthSmolensk.Add(WestR);
                    // Рабочее
                    //resultWest += columnName1;
                    //resultWest = resultWest + ", ";

                }

                resultWest += String.Join("", publicListOfMonthSmolensk);
                resultWest = resultWest.Replace(",", ".");
                resultWest = resultWest.Replace("!", ",");
            }

            connectionR.Close();
            // publicListOfMonthArch.Add(resultWest);
            return resultWest;
        }

        public static string GetArfsmonthWestTver(string filialInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='" + filialInput + "' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";
            string resultWest = "";
            string WestR = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    publicListOfMonthTver.Clear();
                    WestR += columnName1;
                    WestR = WestR + "! ";
                    publicListOfMonthTver.Add(WestR);
                    // Рабочее
                    //resultWest += columnName1;
                    //resultWest = resultWest + ", ";

                }

                resultWest += String.Join("", publicListOfMonthTver);
                resultWest = resultWest.Replace(",", ".");
                resultWest = resultWest.Replace("!", ",");
            }

            connectionR.Close();
            // publicListOfMonthArch.Add(resultWest);
            return resultWest;
        }

        public static string GetArfsmonthWestTula(string filialInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='" + filialInput + "' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";
            string resultWest = "";
            string WestR = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    publicListOfMonthTula.Clear();
                    WestR += columnName1;
                    WestR = WestR + "! ";
                    publicListOfMonthTula.Add(WestR);
                    // Рабочее
                    //resultWest += columnName1;
                    //resultWest = resultWest + ", ";

                }

                resultWest += String.Join("", publicListOfMonthTula);
                resultWest = resultWest.Replace(",", ".");
                resultWest = resultWest.Replace("!", ",");
            }

            connectionR.Close();
            // publicListOfMonthArch.Add(resultWest);
            return resultWest;
        }
        public static string GetArfsmonthWestByFilial(string filial)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "select arfs from (SELECT arfs, report_date, [gp] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад' and filial='"+ filial+"' order by report_date desc Offset 0 Rows)as fu order by report_date asc ";
            string resultWest = "";
            string WestR = "";
            SqlConnection connectionR = new SqlConnection(connectionString);
            connectionR.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionR);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    publicListOfMonthYaro.Clear();
                    WestR += columnName1;
                    WestR = WestR + "! ";
                    publicListOfMonthYaro.Add(WestR);
                    // Рабочее
                    //resultWest += columnName1;
                    //resultWest = resultWest + ", ";

                }

                resultWest += String.Join("", publicListOfMonthYaro);
                resultWest = resultWest.Replace(",", ".");
                resultWest = resultWest.Replace("!", ",");
            }

            connectionR.Close();
            // publicListOfMonthArch.Add(resultWest);
            return resultWest;
        }

        public static async ValueTask<string> GetArfsmonthWestByFilialAsync(string filial)
        {
            return await Task.Run(() => GetArfsmonthWestByFilial(filial));
        }


        public static List<string> GetWestCountGP()
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "Select  Count(*) as FI FROM [siterentdb].[dbo].[global_problems] inner join [siterentdb].[dbo].houses on [siterentdb].[dbo].[global_problems].house_id=[siterentdb].[dbo].houses.house_id where report_date=(Select Max(report_date) from [siterentdb].[dbo].[global_problems]) and region='Запад' group by [filial], report_date order by report_date desc";

            SqlConnection connectionMon = new SqlConnection(connectionString);
            List<string> resultGPWest = new List<string>();
            connectionMon.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionMon);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    //массив object[FieldCount]


                    string CurrentReaderGPWest = reader.GetValue(0) + ", ";
                    resultGPWest.Add(CurrentReaderGPWest);
                }

            }
            connectionMon.Close();
            return resultGPWest;

        }
        public static List<string> GetWestFilials()
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "  Select  filial as FI FROM [siterentdb].[dbo].[global_problems] inner join [siterentdb].[dbo].houses on [siterentdb].[dbo].[global_problems].house_id=[siterentdb].[dbo].houses.house_id where report_date=(Select Max(report_date) from [siterentdb].[dbo].[global_problems])  and  region='Запад' group by [filial], report_date order by report_date desc";

            SqlConnection connectionDays = new SqlConnection(connectionString);
            List<string> resultFilWest = new List<string>();
            connectionDays.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionDays);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    //массив object[FieldCount]

                    char c = '"';
                    string CurrentReaderWestFil = c + reader.GetValue(0).ToString() +c;
                    CurrentReaderWestFil = CurrentReaderWestFil + ",";
                    resultFilWest.Add(CurrentReaderWestFil);
                }

            }
            connectionDays.Close();
            return resultFilWest;

        }


        public static List<string> GetBigArfsWestList()
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "SELECT [arfs] FROM [siterentdb].[dbo].[arfs_dynamics] where region='Запад'  order by filial, report_date";
            SqlConnection connectionT = new SqlConnection(connectionString);

            List<string> resultWestBig = new List<string>();

            connectionT.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connectionT);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    //массив object[FieldCount]


                    string CurrentReaderRow = reader.GetValue(0).ToString()+"! ";
                    resultWestBig.Add(CurrentReaderRow);
                }

            }
            connectionT.Close();
            return resultWestBig;

        }
        public static async ValueTask<List<string>> GetBigArfsWestListAsync()
        {
            return await Task.Run(() => GetBigArfsWestList());
        }

    }
}


