using Microsoft.Extensions.Options;
using Shared.Mail.Model;
using Shared.Mail.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Shared.Mail
{
    public class GmailClient : IMailClient
    {
        private MailClientOptions _emailSettings;

        public GmailClient(IOptions<MailClientOptions> emailSettings)
        {


            _emailSettings = emailSettings.Value;
        }


        public async Task Send(MailModel model)
        {


            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_emailSettings.UsernameEmail, _emailSettings.UsernameEmail)
            };

            foreach (var e in model.To)
            {
                mail.To.Add(new MailAddress(e));
            }


            if (!string.IsNullOrEmpty(model.CcEmail))
            {
                mail.CC.Add(new MailAddress(model.CcEmail));

            }

            mail.Subject = model.Subject;
            mail.Body = model.Content;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;



            using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
            {
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);

                await smtp.SendMailAsync(mail);
            }
        }
    }
}
