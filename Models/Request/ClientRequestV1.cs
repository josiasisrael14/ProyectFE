using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class ClientRequestV1
    {
        public int IdClient { get; set; }
        public int IdBranchOffice { get; set; }
        public int IdTypeClient { get; set; }
        public string? NameClient { get; set; }
        public string? State { get; set; }
    }
}
