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
    public class CompanyServicio : InterfazCompanie
    {
        protected readonly ProyectDbContext _context;
        private readonly IConfigurationLib _config;

        public CompanyServicio(ProyectDbContext context, IConfigurationLib config)
        {
            _context = context;
            _config = config;
        }

        public EResponseBase<Company> GetCompany()
        {
            EResponseBase<Company> response;
            try
            {
                IQueryable<Company> query = _context.Companies.Where(x => x.State == "A");
                response = new UtilitariesResponse<Company>(_config).setResponseBaseForList(query);
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Company>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<Company> GetCompanyById(int id)
        {
            EResponseBase<Company> response;
            try
            {
                IQueryable<Company> query = _context.Companies.Where(x => x.State == "A").Where(x => x.IdCompany == id);
                response = new UtilitariesResponse<Company>(_config).setResponseBaseForList(query);
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Company>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<Company> InsertOrUpdateCompany(Company data)
        {
            EResponseBase<Company> response;
            try
            {
                if (data.IdCompany > 0)
                {
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    response = new UtilitariesResponse<Company>(_config).setResponseBaseForOK(data);
                }
                else
                {
                    data.State = "A";
                    _context.Companies.Add(data);
                    _context.SaveChanges();
                    response = new UtilitariesResponse<Company>(_config).setResponseBaseForOK(data);
                }
                return response;
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Company>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<Company> DeleteCompany(Company data)
        {
            EResponseBase<Company> response;
            try
            {
                var obtenerdato = _context.Companies.Find(data.IdCompany);
                obtenerdato.State = "I";
                _context.Entry(obtenerdato).State = EntityState.Modified;
                _context.SaveChanges();
                response = new UtilitariesResponse<Company>(_config).setResponseBaseForOK();
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Company>(_config).setResponseBaseForException(e);
            }
            return response;
        }
    }
}
