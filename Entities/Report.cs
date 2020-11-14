using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Report : Base
    {
        [Display(Name = "Id пользователя")]
        public string UserId { get; set; }

        [Display(Name = "Пользователь")]
        public ApplicationUser User { get; set; }

        [Display(Name = "Id поста")]
        public Guid PostId { get; set; }

        [Display(Name = "Пост")]
        public Post Post { get; set; }

        [Display(Name = "Id категории жалоб")]
        public Guid CategoryId { get; set; }

        [Display(Name = "Категория жалоб")]
        public ReportCategory Category { get; set; }
    }
}
