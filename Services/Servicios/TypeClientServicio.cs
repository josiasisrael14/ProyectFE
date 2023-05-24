using Azure;
using Azure.Core;
using Common;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Services.Servicios
{
    public class TypeClientServicio : InterfazTypeClients
    {
        protected readonly ProyectDbContext _context;
        private readonly IConfigurationLib _config;

        public TypeClientServicio(ProyectDbContext context, IConfigurationLib config)
        {
            _context = context;
            _config = config;
        }

        public EResponseBase<TypeClient> GetTypeClient()
        {
            EResponseBase<TypeClient> response;
            try
            {
                IQueryable<TypeClient> query = _context.TypeClients;
                response = new UtilitariesResponse<TypeClient>(_config).setResponseBaseForList(query);
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<TypeClient>(_config).setResponseBaseForException(e);
            }
            return response;
        }
    }
}
