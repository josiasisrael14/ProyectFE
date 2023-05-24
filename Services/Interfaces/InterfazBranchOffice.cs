using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface InterfazBranchOffice
    {
        public EResponseBase<BranchOffice> InsertOrUpdateBranchOffice(BranchOffice data);
        public EResponseBase<BranchOffice> DeleteBranchOffice(BranchOffice data);
        public EResponseBase<BranchOffice> GetBranchOffice();
        public EResponseBase<BranchOffice> GetBranchOfficeById(int id);

    }
}