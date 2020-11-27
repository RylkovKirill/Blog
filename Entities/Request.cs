using Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Request : Base
    {
        [Display(Name = "Id пользователя отправителя")]
        public string UserSenderId { get; set; }

        [Display(Name = "Пользователь отправитель")]
        public ApplicationUser UserSender { get; set; }

        [Display(Name = "Id пользователя получателя")]
        public string UserReceiverId { get; set; }

        [Display(Name = "Пользователь получатель")]
        public ApplicationUser UserReceiver { get; set; }

        [Display(Name = "Статус запроса")]
        public RequestStatus RequestStatus { get; set; } = RequestStatus.WAITING;
    }
}
