using Shared.Mail.Model;
using System.Threading.Tasks;

namespace Shared.Mail
{
    public interface IMailClient
    {
        Task Send(MailModel model);
    }
}
