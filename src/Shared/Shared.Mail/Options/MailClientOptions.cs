using System;

namespace Shared.Mail.Options
{
    public class MailClientOptions
    {
        public String PrimaryDomain { get; set; }

        public int PrimaryPort { get; set; }

        public String UsernameEmail { get; set; }

        public String UsernamePassword { get; set; }
    }
}
