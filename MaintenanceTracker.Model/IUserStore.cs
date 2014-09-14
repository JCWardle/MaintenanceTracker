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
        void AddUser(User user);
        void ChangePassword(int id, string password);
        void ChangeEmail(int id, string email);
    }
}
