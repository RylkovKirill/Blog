using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Blog.Service
{
    internal class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }

        async Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                MailMessage message = new MailMessage();

                message.From = new MailAddress("asp.net.core.blog@gmail.com", "Blog");
                message.To.Add(email);
                message.Subject = subject;
                message.Body = htmlMessage;

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Credentials = new NetworkCredential("asp.net.core.blog@gmail.com", "8qNecfEuVq");
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    await smtpClient.SendMailAsync(message);
                    _logger.LogInformation("Сообщение отправлено");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.GetBaseException().Message);
            }
        }
    }
}
