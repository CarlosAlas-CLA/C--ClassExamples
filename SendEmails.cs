using System.Net;
using System.Net.Mail;
namespace TestCodeLibrary
    {
    class SendEmails
        {
        public static void SendReports(string vProgramName, string vFromEmail, string[] vToList, string[] vCCList, string[] vBCCList, string vSubject, string vMailBody, string[] vAttachmentList)
            {
            // Smtp setting
            var vSmtp = new SmtpClient();
            string vSmtpUser = " ";
            string vSmtpPass = " ";
            vSmtp.Host = " ";
            vSmtp.Port = 587;
            vSmtp.EnableSsl = true;
            vSmtp.Credentials = new NetworkCredential(vSmtpUser, vSmtpPass);
            vSmtp.Timeout = 20000;
            //Variables for email
            MailMessage vMail = new MailMessage();
            foreach (string vTo in vToList)
                {
                vMail.To.Add(vTo);
                }
            foreach (string vBcc in vBCCList)
                {
                vMail.Bcc.Add(vBcc);
                }
            foreach (string vAttch in vAttachmentList)
                {
                vMail.Attachments.Add(new Attachment(vAttch));
                }
            vMail.From = new MailAddress(" ");
            vMail.Subject = vSubject;
            vMail.Body = vMailBody;
            //Start program
            try
                {
                vSmtp.Send(vMail);
                }
            catch (System.Exception vException)
                {
                SendEmails.SendExceptionOccur("SQLClass", vException.HelpLink, vException.Message, vException.GetType().ToString(), vException.TargetSite.ToString());
                }
            }
        public static void SendExceptionOccur(string vProgramName, string exception0, string exception1, string exception2, string exception3) { }
        }
