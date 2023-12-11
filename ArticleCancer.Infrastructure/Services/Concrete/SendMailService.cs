using ArticleCancer.Application.DTOs.Mails;
using ArticleCancer.Infrastructure.Services.Abstract;
using MailKit.Net.Smtp;
using MimeKit;


namespace ArticleCancer.Infrastructure.Services.Concrete
{
    public class SendMailService : ISendMailService
	{
        public Task<bool> SendContactMail(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Portfolyo Project İletişim", mailRequest.SenderMail);

            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("SuperAdmin", "enssfevzi@gmail.com");
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Message;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.SenderMail + " tarafından gönderilen  " + mailRequest.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("portfolyoproject@gmail.com", "wajrzicyhixvymug");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return Task.FromResult(true);
        }

        public Task<bool> SendMail()
		{
			throw new NotImplementedException();
		}

		public async Task<bool> SendPasswordChange(string email, string scheme, string host)
		{
			return true;
		}
	}
}
