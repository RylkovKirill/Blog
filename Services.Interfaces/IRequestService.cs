using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
    public interface IRequestService
    {
        Request Get(Guid id);
        Request Get(ApplicationUser user1, ApplicationUser user2);
        IQueryable<Request> GetAll();
        IQueryable<Request> GetAllByUser(ApplicationUser user);
        IQueryable<Request> GetAllOutgoingByUser(ApplicationUser user);
        IQueryable<Request> GetAllIncomingByUser(ApplicationUser user);
        void Add(Request request);
        void Update(Request request);
        void Remove(Guid id);
        IQueryable<ApplicationUser> GetUserFriends(ApplicationUser user);
        bool UserInFriendsList(IQueryable<ApplicationUser> friends, ApplicationUser user);
    }
}
