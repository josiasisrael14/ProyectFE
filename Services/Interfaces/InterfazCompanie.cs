using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface InterfazCompanie
    {
        public EResponseBase<Company> InsertOrUpdateCompany(Company data);
        public EResponseBase<Company> DeleteCompany(Company data);
        public EResponseBase<Company> GetCompany();
        public EResponseBase<Company> GetCompanyById(int id);
    }
}