using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Comment : Base
    {
        [Display(Name = "Содержание")]
        public string Content { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime PostedDate { get; set; } = DateTime.Now;

        [Display(Name = "Id пользователя")]
        public string UserId { get; set; }

        [Display(Name = "Пользователь")]
        public ApplicationUser User { get; set; }

        [Display(Name = "Id поста")]
        public Guid PostId { get; set; }

        [Display(Name = "Пост")]
        public Post Post { get; set; }
    }
}
