using Shared.Mail.Model;
using System.Threading.Tasks;

namespace Shared.Mail
{
    public class SendMail : ISendMail
    {
        private readonly IMailClient _mailClient;

        public SendMail(IMailClient mailClient)
        {
            _mailClient = mailClient;
        }

        public async Task Send(MailModel model)
        {
            await this._mailClient.Send(model);
        }
    }
}
