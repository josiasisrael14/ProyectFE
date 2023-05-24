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
    public class UserServicio : InterfazUsers
    {
        protected readonly ProyectDbContext _context;
        private readonly IConfigurationLib _config;

        public UserServicio(ProyectDbContext context, IConfigurationLib config)
        {
            _context = context;
            _config = config;
        }

        public EResponseBase<User> GetUser()
        {
            EResponseBase<User> response;
            try
            {
                IQueryable<User> query = _context.Users.Where(x => x.State == "A");
                response = new UtilitariesResponse<User>(_config).setResponseBaseForList(query);
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<User>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<User> GetUserById(int id)
        {
            EResponseBase<User> response;
            try
            {
                IQueryable<User> query = _context.Users.Where(x => x.State == "A").Where(x => x.IdUser == id);
                response = new UtilitariesResponse<User>(_config).setResponseBaseForList(query);
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<User>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<User> InsertOrUpdateUser(User data)
        {
            EResponseBase<User> response;
            try
            {
                if (data.IdUser > 0)
                {
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    response = new UtilitariesResponse<User>(_config).setResponseBaseForOK(data);
                }
                else
                {
                    data.State = "A";
                    _context.Users.Add(data);
                    _context.SaveChanges();
                    response = new UtilitariesResponse<User>(_config).setResponseBaseForOK(data);
                }
                return response;
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<User>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<User> DeleteUser(User data)
        {
            EResponseBase<User> response;
            try
            {
                var obtenerdato = _context.Users.Find(data.IdUser);
                obtenerdato.State = "I";
                _context.Entry(obtenerdato).State = EntityState.Modified;
                _context.SaveChanges();
                response = new UtilitariesResponse<User>(_config).setResponseBaseForOK();
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<User>(_config).setResponseBaseForException(e);
            }
            return response;
        }
    }
}
