using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using NETCore.MailKit;
using MailKit.Net.Smtp;

namespace RadioConsole.Web.Models.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfigModel _emailConfig;

        public EmailSender(EmailConfigModel emailConfig)
        {
            emailConfig = _emailConfig;
        }

        public void SendEmail(Message message)
        {
            var email = CreateEmailMessage(message);
            Send(email);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_emailConfig.From));
            email.To.AddRange(message.To);
            email.Subject = message.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return email;
        }

        private void Send(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(emailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
