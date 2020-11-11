using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Review : Base
    {
        [Display(Name = "Балл")]
        public int Score { get; set; }

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
