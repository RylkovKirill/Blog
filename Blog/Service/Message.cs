using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class Message
    {
        private readonly ILogger<Message> _logger;

        public Message(ILogger<Message> logger)
        {
            _logger = logger;
        }

        public void SendMessage(MailMessage message)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Credentials = new NetworkCredential("asp.net.core.blog@gmail.com", "8qNecfEuVq");
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(message);
                    _logger.LogInformation("Сообщение отправлено");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.GetBaseException().Message);
            }
        }

        /*public void SendMessage()
        {
            try
            {

            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);
            }
        }*/
    }
}
