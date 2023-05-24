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
    public class UserRoleServicio : InterfazUserRoles
    {
        protected readonly ProyectDbContext _context;
        private readonly IConfigurationLib _config;

        public UserRoleServicio(ProyectDbContext context, IConfigurationLib config)
        {
            _context = context;
            _config = config;
        }

        public EResponseBase<UserRole> GetUserRole()
        {
            EResponseBase<UserRole> response;
            try
            {
                IQueryable<UserRole> query = _context.UserRoles.Where(x => x.State == "A");
                response = new UtilitariesResponse<UserRole>(_config).setResponseBaseForList(query);
                _context.Database.CloseConnection();
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<UserRole>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<UserRole> GetUserRoleById(int id)
        {
            EResponseBase<UserRole> response;
            try
            {
                IQueryable<UserRole> query = _context.UserRoles.Where(x => x.State == "A").Where(x => x.IdUserRole == id);
                response = new UtilitariesResponse<UserRole>(_config).setResponseBaseForList(query);
                _context.Database.CloseConnection();
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<UserRole>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<UserRole> InsertOrUpdateUserRole(UserRole data)
        {
            EResponseBase<UserRole> response;
            try
            {
                if (data.IdUserRole > 0)
                {
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    response = new UtilitariesResponse<UserRole>(_config).setResponseBaseForOK(data);
                }
                else
                {
                    data.State = "A";
                    _context.UserRoles.Add(data);
                    _context.SaveChanges();
                    response = new UtilitariesResponse<UserRole>(_config).setResponseBaseForOK(data);
                }
                return response;
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<UserRole>(_config).setResponseBaseForException(e);
            }

            _context.Database.CloseConnection();
            return response;
        }

        public EResponseBase<UserRole> DeleteUserRole(UserRole data)
        {
            EResponseBase<UserRole> response;
            try
            {
                var obtenerdato = _context.UserRoles.Find(data.IdUserRole);
                obtenerdato.State = "I";
                _context.Entry(obtenerdato).State = EntityState.Modified;
                _context.SaveChanges();
                response = new UtilitariesResponse<UserRole>(_config).setResponseBaseForOK();
                _context.Database.CloseConnection();
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<UserRole>(_config).setResponseBaseForException(e);
            }
            return response;
        }
    }
}
