
using System;
using System.Data.SqlClient;
using System.IO;


namespace TestCodeLibrary
    {
     
class Program
        {
        static void Main(string[] args)
            {          //File Variables
            string vProgramName = @"SendReports";
            string vProgramDir = @"\C:\Users\Desktop\GLDataTest";
            string vOutputPath = @"C:\Users\Desktop\GLDataTest\Output\";
            string vArchivePath0 = @"C:\Users\Desktop\GLDataTest\Archive0\";
            string vArchivePath1 = @"C:\Users\Desktop\GLDataTest\Archive1\";
            string vToday = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff");
            string vLogPath = @"C:\Users\Desktop\GLDataTest\log.txt";
            string vSheetName = "Daily Invoice";
            string vFileName = "Items Report";
            string vFileId = DateTime.Now.Millisecond.ToString();
            string vFileType = ".xlsx";
            string[] vPathsToBeClear;
            //SQL connection string
            string vSQLConnectionString = "";
            //SQL variables 
            string vSQLServer = "";
            string vDBName = "";
            string vUserName = "";
            string vPassword = "";
            SqlCommand sqlCommand = new SqlCommand();
            string vSQLCmd1 = "select *from dbo.test";
            string vSQLCmd2 = "select *from dbo.test";
            //SMTP variables
            string vFromEmail = "";
            string[] vToList = { "" };
            string[] vCCList = { "" };
            string[] vBCCList = { "" };
            String vSubject = "Daily Reports" + vToday;
            String vMailBody = "Greetings," + "\n" + "     Report for the last week is attached." + "\n" + "\n" + "Thank you," + "\n" + "CLA" + "\n" + "\n" + "\n" + "\n" + "\n" + "{CLA}";
            try
                { // Clear Output Folder
                //vPathsToBeClear = Directory.GetFiles(vOutputPath);
                //foreach (string filePath in vPathsToBeClear)
                //    {
                //    File.Delete(filePath);
                //    }
           
                // Create excel file
                SQL.SqlToExcel( vOutputPath , vFileName ,vFileType,vSheetName, vSQLConnectionString, vSQLCmd1);
                //if (File.Exists(vOutputPath + vFileName + vFileType))
                    {
                    //Send report email
                    SendEmails.SendReports(vProgramName,  vFromEmail, vToList, vBCCList, vCCList, vSubject, vMailBody, new[] { vOutputPath + vFileName + vFileType });
                    }
                //Copy to archive
                File.Copy(vOutputPath + vFileName + vFileType, vArchivePath0 + vFileName + vToday + vFileId + vFileType);
                // Create excel file
                SQL.SqlToExcel(vOutputPath, vFileName, vFileType, vSheetName, vSQLConnectionString, vSQLCmd2);
                //if (File.Exists(vOutputPath + vFileName + vFileType))
                //    {
                //    //Send report email
                //    SendEmails.SendReports(vProgramName, vProgramDir, vLogPath, vFromEmail, vToList, vBCCList, vCCList, vSubject, vMailBody, new[] { vOutputPath + vFileName + vFileType });
                ////    }   //Copy to archive
             File.Copy(vOutputPath + vFileName + vFileType, vArchivePath1 + vFileName + vToday + vFileId + vFileType);
                GC.Collect();
                }
            catch (Exception ex)
                {
                //Send exception email
                SendEmails.SendExceptionOccur(vProgramName,ex.HelpLink, ex.Message, ex.GetType().ToString(), ex.TargetSite.ToString());
                //Write to log file
                File.AppendAllText(vLogPath, "\n*******************************" + vToday + "\n" + ex.TargetSite + "\n " + ex.Message + "\n" + ex.Data + "\n" + ex.StackTrace + "\n*******************************");
                }
            }
        }
    }

