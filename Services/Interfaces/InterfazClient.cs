using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface InterfazClient
    {
        public EResponseBase<Client> InsertOrUpdateClient(Client data);
        public EResponseBase<Client> DeleteClient(Client data);
        public EResponseBase<Client> GetClient();
        public EResponseBase<Client> GetClientById(int id);
    }
}