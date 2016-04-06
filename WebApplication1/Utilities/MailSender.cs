using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebApplication1.Utilities
{
    public class MailSender
    {

        public static void Send(string subject, string htmlBody, MailAddress to)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "localhost";
            mail.To.Add(to);
            mail.From = new MailAddress("carlosomarblanco@itesm.com");
            mail.Subject = subject;
            mail.Body = htmlBody;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }

    }
}