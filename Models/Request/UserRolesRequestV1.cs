using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class UserRolesRequestV1
    {
        public int IdUserRole { get; set; }
        public int IdRole { get; set; }
        public int IdUser { get; set; }

    }
}
