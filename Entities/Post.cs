using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Post : Base
    {
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Display(Name = "Содержание")]
        public string Content { get; set; }

        [Display(Name = "Дата Публикации")]
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Титульное Изображение")]
        public string TitleImagePath { get; set; }

        [Display(Name = "Дата Изменения")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Пользователь")]
        public ApplicationUser User { get; set; }

        [Display(Name = "Id Категории")]
        public Guid? CategoryId { get; set; }

        [Display(Name = "Категория")]
        public Category Category { get; set; }

        [Display(Name = "Коментарии")]
        public List<Comment> Comments { get; set; }

        [Display(Name = "Теги")]
        public List<PostTag> Tags { get; set; }
    }
}
