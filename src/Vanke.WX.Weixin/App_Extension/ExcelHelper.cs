using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace Vanke.WX.Weixin.App_Extension
{
    public class ExcelHelper
    {
        public static DataTable GetExcelDataTable(string filePath)
        {
            using (var connection = new OleDbConnection(GetConnString(filePath)))
            {
                string excelQuery = "select * from [sheet1$]";
                using (var command = new OleDbDataAdapter(excelQuery, connection))
                {
                    var ds = new DataSet();
                    command.Fill(ds);

                    return ds.Tables[0];
                }
            }
        }

        private static string GetConnString(string filePath)
        {
            var connectionString = string.Empty;
            if (filePath != null)
            {
                //Excel版本不一样，连接字符串不一样
                if (filePath.EndsWith(".xls"))
                {   
                    //Excel2003
                    connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + filePath + "; Extended Properties=Excel 8.0";
                }
                else
                {   
                    //Excel2007 up
                    connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" + filePath + "; Extended Properties=Excel 12.0";
                }
            }
            return connectionString;
        }
    }
}