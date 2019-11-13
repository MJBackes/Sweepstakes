﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
namespace Sweepstakes
{
    public static class EmailService
    {
        public static async Task SendEmail(EmailModel model)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(model.FromDisplayName, model.FromEmailAddress));
            email.To.Add(new MailboxAddress(model.ToName, model.ToEmailAddress));
            email.Subject = model.Subject;
            var body = new BodyBuilder { TextBody = model.Message };
            email.Body = body.ToMessageBody();
            using (var emailClient = new SmtpClient())
            {
                emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await emailClient.ConnectAsync("smtp.gmail.com", 465, true).ConfigureAwait(false);
                await emailClient.AuthenticateAsync(EmailInfo.Address, EmailInfo.Pass).ConfigureAwait(false);
                await emailClient.SendAsync(email).ConfigureAwait(false);
                await emailClient.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}
