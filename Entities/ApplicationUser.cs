using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enum;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Пол")]
        public Sex Sex { get; set; }

        [Display(Name = "Фотография")]
        public string ProfilePhotoPath { get; set; }

        [Display(Name = "Долгота")]
        public double Longitude { get; set; }

        [Display(Name = "Широта")]
        public double Latitude { get; set; }

        [Display(Name = "Список постов")]
        public List<Post> Posts { get; set; }

        [Display(Name = "Список комментариев")]
        public List<Comment> Comments { get; set; }

        [Display(Name = "Список обзоров")]
        public List<Review> Reviews { get; set; }

        [Display(Name = "Список жалоб")]
        public List<Report> Reports { get; set; }

        [Display(Name = "Список исходящих запросов")]
        public List<Request> OutgoingRequests { get; set; }

        [Display(Name = "Список входящих запросов")]
        public List<Request> IncomingRequests { get; set; }

        [Display(Name = "Список сообщений")]
        public List<Message> Messages { get; set; }

        //[NotMapped]
        //[Display(Name = "Список друзей")]
        //public List<ApplicationUser> Friends { get; set; }

        //[Display(Name = "Список чатов")]
        //public List<Chat> Chats { get; set; }

        //[Display(Name = "Список исходящих сообщений")]
        //public List<Message> OutgoingMessages { get; set; }

        //[Display(Name = "Список входящих сообщений")]
        //public List<Message> IncomingMessages { get; set; }
    }
}
