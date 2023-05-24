using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class UsersRequestV1
    {
        public int IdUser { get; set; }
        public int IdBranchOffice { get; set; }
        public string? Username { get; set; }
        public string? Userpass { get; set; }
        public string? State { get; set; }
    }
}
