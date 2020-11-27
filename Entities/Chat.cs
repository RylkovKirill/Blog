using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Chat : Base
    {
        [Display(Name = "Id первого пользователя")]
        public string FirstUserId { get; set; }

        [Display(Name = "Первый пользователь")]
        public ApplicationUser FirstUser { get; set; }

        [Display(Name = "Id второго пользователя")]
        public string SecondUserId { get; set; }

        [Display(Name = "Пользователь получатель")]
        public ApplicationUser SecondUser { get; set; }

        public List<Message> Messages { get; set; }
    }
}
