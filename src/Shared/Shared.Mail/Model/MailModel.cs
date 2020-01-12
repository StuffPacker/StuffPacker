namespace Shared.Mail.Model
{
    public class MailModel
    {
        public string[] To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string From { get; set; }
        public string CcEmail { get; set; }
    }
}
