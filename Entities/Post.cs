using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Post : Base
    {
        [Required(ErrorMessage = "Название не может быть пустым")]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Содержание не может быть пустым")]
        [Display(Name = "Содержание")]
        public string Content { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Титульное изображение")]
        public string TitleImagePath { get; set; }

        [Display(Name = "Дата изменения")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Пользователь")]
        public ApplicationUser User { get; set; }

        [Display(Name = "Id категории")]
        public Guid? CategoryId { get; set; }

        [Display(Name = "Категория")]
        public PostCategory Category { get; set; }

        [Display(Name = "Коментарии")]
        public List<Comment> Comments { get; set; }

        [Display(Name = "Теги")]
        public List<PostTag> Tags { get; set; }

        [Display(Name = "Список жалоб")]
        public List<Report> Reports { get; set; }
    }
}
