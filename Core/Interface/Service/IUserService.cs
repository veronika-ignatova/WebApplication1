using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Service
{
    public interface IUserService
    {
        IUser GetUserById(Guid id);
        bool CreateUser(IUser user);
        bool IsUsedEmail(string email);
        IEnumerable<IUser> GetAllUsers();
    }
}
