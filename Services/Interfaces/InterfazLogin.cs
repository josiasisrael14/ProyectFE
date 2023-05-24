using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface InterfazLogin
    {
        User GetUsersByIdentificador(User data);
        string generartoken(User data);
    }
}
