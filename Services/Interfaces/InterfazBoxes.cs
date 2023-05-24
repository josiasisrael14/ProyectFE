using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface InterfazBoxes
    {
        public EResponseBase<Box> InsertOrUpdateBox(Box data);
        public EResponseBase<Box> DeleteBox(Box data);
        public EResponseBase<Box> GetBox();
        public EResponseBase<Box> GetBoxById(int id);
    }
}
