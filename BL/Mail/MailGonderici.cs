using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace BL.Mail
{
    public class MailGonderici
    {
        public static void Gonder(string email, string body, string subject)
        {

            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.To.Add(email);

            mail.From = new MailAddress("telefonprojesi@gmail.com", subject, System.Text.Encoding.UTF8);
            mail.Subject = subject;
            mail.Body = body;

            SmtpClient smp = new SmtpClient();

            smp.Credentials = new NetworkCredential("telefonprojesi@gmail.com", "P122008952");
            smp.Port = 587;
            smp.Host = "smtp.gmail.com";
            smp.EnableSsl = true;
            smp.Send(mail);
        }

    }
}