using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Comment : Base
    {
        [Display(Name = "Содержание")]
        public string Content { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }

        [Display(Name = "Пользователь")]
        public ApplicationUser User { get; set; }

        public Guid? PostId { get; set; }

        [Display(Name = "Пост")]
        public Post Post { get; set; }
    }
}
