using System.Net;
using System.Net.Mail;
using Malek_wafik.Models;
namespace Malek_wafik.Helpers
{
    public static class EmailSettings
    {
        public static void SendEmail(IConfiguration config,Email email)
        {
            var smtpSettings = config.GetSection("SmtpSettings");
            var Client = new SmtpClient(smtpSettings["Host"], int.Parse(smtpSettings["Port"]))
            {
                Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]),
                EnableSsl = true
            };
            Client.Send(smtpSettings["From"], email.To, email.Subject, email.Body);
        }
    }
}
