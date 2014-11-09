using MaintenanceTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Domain
{
    public interface IUserStore
    {
        void AddUser(User user, string password);
        void ChangePassword(string username, string password);
        void ChangeEmail(string username, string email);
        bool Authenticate(string username, string password);
    }
}
