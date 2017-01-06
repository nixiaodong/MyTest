using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;// For COMException 

namespace textdall
{
    public class ReadExcelHelper
    {
        public static DataSet ReadExcel(string filePath)
        {
            //String strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            String strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + filePath + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'"; //此連接可以操作.xls與.xlsx文件
            String sheetName = "sheet1";
            String strExcel = "select * from  [" + sheetName + "$] ";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "data");
            conn.Close();
            return ds;
        }
    }
}
