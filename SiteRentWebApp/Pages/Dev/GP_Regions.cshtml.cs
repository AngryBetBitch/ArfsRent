using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;


namespace SiteRentWebApp.Pages
{

    public class GP_Regions : PageModel
    {
        
        public string resultMOSCOW = String.Empty;
        public string resultEast = String.Empty;
        public string resultWest = String.Empty;
        public string resultCenter = String.Empty;
        public string resultSouth = String.Empty;

        public void OnGet()
        {
            resultMOSCOW = GetArfs("Москва");
            resultEast = GetArfs("Восток");
            resultWest = GetArfs("Запад");
            resultCenter = GetArfs("Центр");
            resultSouth= GetArfs("Юг");
        }
        public static string GetArfs(string regionInput)
        {
            string connectionString = "Server=MS-SQL009\\SQL09;Database=siterentdb;User id=Tolokonnikov;Password=Cbcflvby246";
            string sqlExpression = "Select rego,h, aab, Dyna from (SELECT [region]as rego, Count([siterentdb].[dbo].[monitor].[house_id]) as h ,SUM([ACTV09_CNT]) as  AAB FROM [siterentdb].[dbo].[monitor] inner join [siterentdb].[dbo].[houses] on [siterentdb].[dbo].[monitor].[house_id]=[siterentdb].[dbo].[houses].[house_id] where exception=1 and disconnect_date is null and region='"+ regionInput + "' group by region) as pudg inner join ( select REG AS REG1, dynamics AS Dyna from  (select REG, tes, tes2, (tes2-tes)as dynamics from(SELECT [region] AS REG, Count([siterentdb].[dbo].[monitor].[house_id])as tes2 FROM [siterentdb].[dbo].[monitor] inner join [siterentdb].[dbo].[houses] on [siterentdb].[dbo].[monitor].[house_id]=[siterentdb].[dbo].[houses].[house_id] where exception=1 and disconnect_date is null and region='"+ regionInput + "' group by region) as p2 inner join (select REGIUS, tes from (select top (1) [region] as REGIUS,gp as tes, filial FROM [siterentdb].[dbo].[arfs_dynamics] where region='"+ regionInput + "' and filial='Итого' order by [report_date] desc ) as p) as D1 on REG=REGIUS) AS Great) as Great2 on rego=REG1";
            string result = "";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    string columnName1 = reader.GetValue(0).ToString();
                    string columnName2 = reader.GetValue(1).ToString();
                    string columnName3 = reader.GetValue(2).ToString();
                    string columnName4 = reader.GetValue(3).ToString();
                    result += "[" + String.Join(", ", columnName1) + "]";
                    result += "|";
                    result += "[" + String.Join(", ", columnName2) + "]";
                    result += "|";
                    result += "[" + String.Join(", ", columnName3) + "]";
                    result += "|";
                    result += "[" + String.Join(", ", columnName4) + "]";
                }                

            }

            connection.Close();
            return result;
        }
    }


}