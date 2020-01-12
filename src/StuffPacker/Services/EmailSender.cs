using Microsoft.AspNetCore.Identity.UI.Services;
using Shared.Mail;
using Shared.Mail.Model;
using Shared.Mail.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace StuffPacker.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ISendMail _sendmail;
        private readonly MailClientOptions _mailoptions;

        public EmailSender(ISendMail sendmail, IOptions<MailClientOptions> mailoptions)
        {
            _sendmail = sendmail;
            _mailoptions = mailoptions.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var model = new MailModel
            {
                CcEmail = _mailoptions.UsernameEmail,
                Content=htmlMessage,
                From= _mailoptions.UsernameEmail,
                Subject="Stuffpacker - "+subject,
                To=new[] {email}
            };
            await _sendmail.Send(model);
        }
    }
}
