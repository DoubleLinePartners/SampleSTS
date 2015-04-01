using System;
using System.Configuration;
using System.Net.Mail;

namespace SampleSTS.Resources.Utilities
{
    public static class EmailUtility
    {
        public static void SendMessage(string toEmail, string fromEmail, string fromName, string subject, string text)
        {
            var myMessage = new MailMessage();
            myMessage.To.Add(toEmail);
            myMessage.From = new MailAddress(fromEmail, fromName);
            myMessage.Subject = subject;
            myMessage.Body = text;

            // Init SmtpClient and send
            var smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPServer"], Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]));
            if (ConfigurationManager.AppSettings["SMTPAnonymousAccess"] == "true")
            {
                smtpClient.UseDefaultCredentials = false;
            }
            else
            {
                var credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUserName"],
                    ConfigurationManager.AppSettings["SMTPPassword"]);
                smtpClient.Credentials = credentials;
            }

            smtpClient.Send(myMessage);
        }
    }
}
