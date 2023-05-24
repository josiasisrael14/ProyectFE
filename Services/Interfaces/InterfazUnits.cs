using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface InterfazUnits
    {
        public EResponseBase<Unit> InsertOrUpdateUnit(Unit data);
        public EResponseBase<Unit> DeleteUnit(Unit data);
        public EResponseBase<Unit> GetUnit();
        public EResponseBase<Unit> GetUnitById(int id);
    }
}
