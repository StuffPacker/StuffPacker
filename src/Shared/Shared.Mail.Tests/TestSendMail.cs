using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Mail.Model;
using Shared.Mail.Options;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
namespace Shared.Mail.Tests
{
   
        [TestClass]
        public class TestSendMail
        {
            private readonly IMailClient _mailClient;

            public TestSendMail()
            {
                var emailSetting = new MailClientOptions
                {
                    PrimaryDomain = "smtp.gmail.com",
                    PrimaryPort = 587,
                    UsernameEmail = "*",
                    UsernamePassword = "*"
                };


                var someOptions = Microsoft.Extensions.Options.Options.Create(emailSetting);

                _mailClient = new GmailClient(someOptions);
            }

            [TestMethod]
            [Ignore]
            public async Task SendTestMail()
            {
                var target = this.GetTarget();
            var model = new MailModel
            {
                Content="Test mail from stuffpacker",
                From="*",
                Subject="Test mail from stuffpacker",
                To=new []{ "*" }
            };
                await target.Send(model);
            }

            private SendMail GetTarget()
            {
                return new SendMail(_mailClient);
            }
        }
    
}
