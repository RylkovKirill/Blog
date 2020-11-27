using Entities;
using System;
using System.Linq;

namespace Services.Interfaces
{
    public interface IMessageService
    {
        Message Get(Guid id);
        IQueryable<Message> GetAll();
        IQueryable<Message> GetAll(ApplicationUser user);
        IQueryable<Message> GetAll(Chat chat);
        void Add(Message message);
        void Update(Message message);
        void Remove(Guid id);
    }
}
