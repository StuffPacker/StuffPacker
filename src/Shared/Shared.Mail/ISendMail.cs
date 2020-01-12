using Shared.Mail.Model;
using System.Threading.Tasks;

namespace Shared.Mail
{
    public interface ISendMail
    {       
        Task Send(MailModel model);

    }
}
