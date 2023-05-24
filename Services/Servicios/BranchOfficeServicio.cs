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
    public class BranchOfficeServicio : InterfazBranchOffice
    {
        protected readonly ProyectDbContext _context;
        private readonly IConfigurationLib _config;

        public BranchOfficeServicio(ProyectDbContext context, IConfigurationLib config)
        {
            _context = context;
            _config = config;
        }

        public EResponseBase<BranchOffice> GetBranchOffice()
        {
            EResponseBase<BranchOffice> response;
            try
            {
                IQueryable<BranchOffice> query = _context.BranchOffices.Where(x => x.State == "A");
                response = new UtilitariesResponse<BranchOffice>(_config).setResponseBaseForList(query);
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<BranchOffice>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<BranchOffice> GetBranchOfficeById(int id)
        {
            EResponseBase<BranchOffice> response;
            try
            {
                IQueryable<BranchOffice> query = _context.BranchOffices.Where(x => x.State == "A").Where(x => x.IdBranchOffice == id);
                response = new UtilitariesResponse<BranchOffice>(_config).setResponseBaseForList(query);
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<BranchOffice>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<BranchOffice> InsertOrUpdateBranchOffice(BranchOffice data)
        {
            EResponseBase<BranchOffice> response;
            try
            {
                if (data.IdBranchOffice > 0)
                {
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    response = new UtilitariesResponse<BranchOffice>(_config).setResponseBaseForOK(data);
                }
                else
                {
                    data.State = "A";
                    _context.BranchOffices.Add(data);
                    _context.SaveChanges();
                    response = new UtilitariesResponse<BranchOffice>(_config).setResponseBaseForOK(data);
                }
                return response;
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<BranchOffice>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<BranchOffice> DeleteBranchOffice(BranchOffice data)
        {
            EResponseBase<BranchOffice> response;
            try
            {
                var obtenerdato = _context.BranchOffices.Find(data.IdBranchOffice);
                obtenerdato.State = "I";
                _context.Entry(obtenerdato).State = EntityState.Modified;
                _context.SaveChanges();
                response = new UtilitariesResponse<BranchOffice>(_config).setResponseBaseForOK();
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<BranchOffice>(_config).setResponseBaseForException(e);
            }
            return response;
        }
    }
}
