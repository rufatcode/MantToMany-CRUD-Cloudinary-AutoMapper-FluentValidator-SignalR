using System;
using Lab10_FrontToBack.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Lab10_FrontToBack.Services
{
    public class SendEmail : ISendEmail
    {
        public SendEmail()
        {
        }

        public void Send(string from, string displayName, string to, string messageBody, string subject)
        {
            try
            {
                MailMessage mailMessage = new();
                mailMessage.From = new MailAddress(from, "Pb101");
                mailMessage.To.Add(new MailAddress(to));
                mailMessage.Subject = subject;
                mailMessage.Body = messageBody;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("mypathacademy.com@gmail.com", "euek fhkv dwys mqgh");
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception("something went wrong");
            }
        }
    }
}

