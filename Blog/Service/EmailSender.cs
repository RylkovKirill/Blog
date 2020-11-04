using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Blog.Service
{
    internal class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        async Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(_configuration["EmailSettings:addres"], _configuration["EmailSettings:displayName"]),
                    Subject = subject,
                    Body = htmlMessage
                };
                message.To.Add(email);

                using SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Credentials = new NetworkCredential(_configuration["EmailSettings:userName"], _configuration["EmailSettings:password"]),
                    Port = 587,
                    EnableSsl = true
                };
                await smtpClient.SendMailAsync(message);

                _logger.LogInformation("Сообщение отправлено");
            }
            catch (Exception e)
            {
                _logger.LogError(e.GetBaseException().Message);
            }
        }
    }
}
