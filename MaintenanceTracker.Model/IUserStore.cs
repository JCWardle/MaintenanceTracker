using MaintenanceTracker.Domain.Model;
using System;

namespace MaintenanceTracker.Domain
{
    public interface IUserStore : IDisposable
    {
        void AddUser(User user, string password);
        void ChangePassword(string username, string password);
        void ChangeEmail(string username, string email);
        bool Authenticate(string username, string password);
    }
}
