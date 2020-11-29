using Entities;
using Entities.Enum;
using Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<Request> _repository;

        public RequestService(IRepository<Request> repository)
        {
            _repository = repository;
        }

        public Request Get(Guid id)
        {
            return _repository.Get(id);
        }

        public Request Get(ApplicationUser user1, ApplicationUser user2)
        {
            return _repository.GetAll().Where((r => (r.UserSender == user1 && r.UserReceiver == user2) || (r.UserSender == user2 && r.UserReceiver == user1))).SingleOrDefault();
        }

        public IQueryable<Request> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Request> GetAllByUser(ApplicationUser user)
        {
            return _repository.GetAll().Where(r => (r.UserSender.Equals(user) && r.RequestStatus == RequestStatus.WAITING) || (r.UserReceiver.Equals(user) && r.RequestStatus == RequestStatus.WAITING));
        }

        public IQueryable<Request> GetAllOutgoingByUser(ApplicationUser user)
        {
            return _repository.GetAll().Where(r => r.UserSender.Equals(user) && r.RequestStatus == RequestStatus.WAITING);

        }

        public IQueryable<Request> GetAllIncomingByUser(ApplicationUser user)
        {
            return _repository.GetAll().Where(r => r.UserReceiver.Equals(user) && r.RequestStatus == RequestStatus.WAITING);

        }

        public void Add(Request request)
        {
            _repository.Add(request);
        }

        public void Update(Request request)
        {
            _repository.Update(request);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(Get(id));
        }

        public IQueryable<ApplicationUser> GetUserFriends(ApplicationUser user)
        {
            return _repository.GetAll().Where(r => r.UserSender.Equals(user) && r.RequestStatus == RequestStatus.CONFIRMED)
                .Select(r => r.UserReceiver)
                .Union(_repository.GetAll().Where(r => r.UserReceiver.Equals(user) && r.RequestStatus == RequestStatus.CONFIRMED)
                .Select(r => r.UserSender));
        }

        public bool UserInFriendsList(IQueryable<ApplicationUser> friends, ApplicationUser user)
        {
            return friends.Contains(user);
        }
    }
}
