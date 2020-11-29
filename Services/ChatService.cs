using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using Repositories;
using Services.Interfaces;

namespace Services
{
    public class ChatService : IChatService
    {
        private readonly IRepository<Chat> _repository;

        public ChatService(IRepository<Chat> repository)
        {
            _repository = repository;
        }

        public Chat Get(Guid id)
        {
            return _repository.Get(id);
        }

        public Chat Get(ApplicationUser user1, ApplicationUser user2)
        {
            return _repository.GetAll().Where((r => (r.FirstUser.Equals(user1) && r.SecondUser.Equals(user2)) || (r.FirstUser.Equals(user2)) && r.SecondUser.Equals(user1))).SingleOrDefault();
        }

        public IQueryable<Chat> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Chat> GetAll(ApplicationUser user)
        {
            return _repository.GetAll().Where(c => c.FirstUser.Equals(user) || c.SecondUser.Equals(user));
        }


        public void Add(Chat chat)
        {
            _repository.Add(chat);
        }

        public void Update(Chat chat)
        {
            _repository.Update(chat);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(Get(id));
        }
    }
}
