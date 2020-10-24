using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class ReportCategory : Base
    {
        [Required(ErrorMessage = "Название не может быть пустым")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Список жалоб")]
        public List<Report> Reports { get; set; }
    }
}
