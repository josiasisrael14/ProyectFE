using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public  interface InterfazUserRoles
    {
        public EResponseBase<UserRole> InsertOrUpdateUserRole(UserRole data);
        public EResponseBase<UserRole> DeleteUserRole(UserRole data);
        public EResponseBase<UserRole> GetUserRole();
        public EResponseBase<UserRole> GetUserRoleById(int id);

    }
}
