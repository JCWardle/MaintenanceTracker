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
        public void AddUser(User user);
        public void ChangePassword(int id, string password);
        public void ChangeEmail(int id, string email);
    }
}
