using System;
using System.Data;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace TestCodeLibrary
    {
    class SQL
        {
        private static SqlConnection sqlconnection;
        private static SqlCommand sqlCommand;
        private static SqlDataAdapter sqlDataAdapter;
        private static DataTable dataTable = new DataTable();
        private static Excel.Application excelApplication = new Excel.Application();
        private static Excel.Workbook excelWorkbook;
        public static void SqlToExcel(string vOutputPath, string vFileName, string vFileType, string vSheetName, string vSQLConnectionString, string vSQLCmd)
            {
            try
                {
                using (sqlconnection = new SqlConnection(vSQLConnectionString))
                    {
                    sqlconnection.Open();
                    sqlCommand = new SqlCommand(vSQLCmd, sqlconnection);
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    excelWorkbook = excelApplication.Workbooks.Open(vOutputPath + vFileName + vFileType, true);
                    Excel.Worksheet workSheet = (Excel.Worksheet)excelWorkbook.Sheets[vSheetName];
                    object[,] arraySQLData = new object[dataTable.Rows.Count, dataTable.Columns.Count];
                    for (int row = 0; row < dataTable.Rows.Count; row++)
                        {
                        DataRow dataRow = dataTable.Rows[row];
                        for (int column = 0; column < dataTable.Columns.Count; column++)
                            {
                            arraySQLData[row, column] = dataRow[column];
                            }
                        }
                    Excel.Range range0 = (Excel.Range)workSheet.Cells[1, 1];
                    Excel.Range range1 = (Excel.Range)workSheet.Cells[dataTable.Rows.Count, dataTable.Columns.Count];
                    Excel.Range range = workSheet.get_Range(range0, range1);
                    range.Value = arraySQLData;
                    sqlconnection.Close();
                    excelWorkbook.Save();
                    excelWorkbook.Close();
                    excelApplication.Quit();
                    }
                }
            catch (Exception ex)
                {
                }
            }
        }
    }
