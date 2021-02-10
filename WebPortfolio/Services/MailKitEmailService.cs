using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPortfolio.Services
{
    public class MailKitEmailService : IEmailService
    {
        private readonly EmailServerConfiguration _eConfig;

        public MailKitEmailService(EmailServerConfiguration config)
        {
            _eConfig = config;
        }

        public async Task SendAsync(String subject, String content, String address, String name)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(name, address));
            message.From.Add(new MailboxAddress(_eConfig.EmailOwnerName, _eConfig.SenderEmailAddress));

            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = content
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;  // ToDo - only for dev

                await client.ConnectAsync(_eConfig.SmtpServer, _eConfig.SmtpPort, true);

                await client.AuthenticateAsync(_eConfig.SmtpUsername, _eConfig.SmtpPassword);

                await client.SendAsync(message);

                await client.DisconnectAsync(true);
            }
        }

        public async Task SendAsync(String subject, String content)
        {
            await SendAsync(subject, content, _eConfig.SenderEmailAddress, _eConfig.EmailOwnerName);
        }
    }
}
