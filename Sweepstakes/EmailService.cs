using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
namespace Sweepstakes
{
    public static class EmailService
    {
        public static async void SendEmail(EmailModel model)
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(new MailboxAddress(model.FromDisplayName, model.FromEmailAddress));
            email.To.Add(new MailboxAddress(model.ToName, model.ToEmailAddress));
            email.Subject = model.Subject;
            var body = new BodyBuilder { TextBody = model.Message };
            email.Body = body.ToMessageBody();
            using (SmtpClient emailClient = new SmtpClient())
            {
                await emailClient.ConnectAsync("smtp.gmail.com", 587, true);
                await emailClient.AuthenticateAsync(EmailInfo.Address, EmailInfo.Pass);
                await emailClient.SendAsync(email);
            }
        }
    }
}
