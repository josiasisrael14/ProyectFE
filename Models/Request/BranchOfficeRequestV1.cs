﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class BranchOfficeRequestV1
    {
        public int IdBranchOffice { get; set; }
        public int IdCompany { get; set; }
        public string? State { get; set; }
    }
}
