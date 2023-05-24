using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface InterfazUsers
    {
        public EResponseBase<User> InsertOrUpdateUser(User data);
        public EResponseBase<User> DeleteUser(User data);
        public EResponseBase<User> GetUser();
        public EResponseBase<User> GetUserById(int id);
    }
}
