using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Message : Base
    {
        [Display(Name = "Содержание")]
        public string Content { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Id пользователя")]
        public string UserId { get; set; }

        [Display(Name = "Пользователь")]
        public ApplicationUser User { get; set; }

        [Display(Name = "Id чата")]
        public Guid ChatId { get; set; }

        [Display(Name = "Чат")]
        public Chat Chat { get; set; }
    }
}
