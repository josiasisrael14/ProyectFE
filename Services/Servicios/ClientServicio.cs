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
    public class ClientServicio : InterfazClient
    {
        protected readonly ProyectDbContext _context;
        private readonly IConfigurationLib _config;

        public ClientServicio(ProyectDbContext context, IConfigurationLib config)
        {
            _context = context;
            _config = config;
        }

        public EResponseBase<Client> GetClient()
        {
            EResponseBase<Client> response;
            try
            {
                IQueryable<Client> query = _context.Clients.Where(x => x.State == "A");
                response = new UtilitariesResponse<Client>(_config).setResponseBaseForList(query);
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Client>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<Client> GetClientById(int id)
        {
            EResponseBase<Client> response;
            try
            {
                IQueryable<Client> query = _context.Clients.Where(x => x.State == "A").Where(x => x.IdClient == id);
                response = new UtilitariesResponse<Client>(_config).setResponseBaseForList(query);
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Client>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<Client> InsertOrUpdateClient(Client data)
        {
            EResponseBase<Client> response;
            try
            {
                if (data.IdClient > 0)
                {
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    response = new UtilitariesResponse<Client>(_config).setResponseBaseForOK(data);
                }
                else
                {
                    data.State = "A";
                    _context.Clients.Add(data);
                    _context.SaveChanges();
                    response = new UtilitariesResponse<Client>(_config).setResponseBaseForOK(data);
                }
                return response;
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Client>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<Client> DeleteClient(Client data)
        {
            EResponseBase<Client> response;
            try
            {
                var obtenerdato = _context.Clients.Find(data.IdClient);
                obtenerdato.State = "I";
                _context.Entry(obtenerdato).State = EntityState.Modified;
                _context.SaveChanges();
                response = new UtilitariesResponse<Client>(_config).setResponseBaseForOK();
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Client>(_config).setResponseBaseForException(e);
            }
            return response;
        }
    }
}
