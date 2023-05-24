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
    public class BoxServicio : InterfazBoxes
    {
        protected readonly ProyectDbContext _context;
        private readonly IConfigurationLib _config;

        public BoxServicio(ProyectDbContext context, IConfigurationLib config)
        {
            _context = context;
            _config = config;
        }

        public EResponseBase<Box> GetBox()
        {
            EResponseBase<Box> response;
            try
            {
                IQueryable<Box> query = _context.Boxes.Where(x => x.State == "A");
                response = new UtilitariesResponse<Box>(_config).setResponseBaseForList(query);
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Box>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<Box> GetBoxById(int id)
        {
            EResponseBase<Box> response;
            try
            {
                IQueryable<Box> query = _context.Boxes.Where(x => x.State == "A").Where(x => x.IdBox == id);
                response = new UtilitariesResponse<Box>(_config).setResponseBaseForList(query);
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Box>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<Box> InsertOrUpdateBox(Box data)
        {
            EResponseBase<Box> response;
            try
            {
                if (data.IdBox > 0)
                {
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    response = new UtilitariesResponse<Box>(_config).setResponseBaseForOK(data);
                }
                else
                {
                    data.State = "A";
                    _context.Boxes.Add(data);
                    _context.SaveChanges();
                    response = new UtilitariesResponse<Box>(_config).setResponseBaseForOK(data);
                }
                return response;
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Box>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<Box> DeleteBox(Box data)
        {
            EResponseBase<Box> response;
            try
            {
                var obtenerdato = _context.Boxes.Find(data.IdBox);
                obtenerdato.State = "I";
                _context.Entry(obtenerdato).State = EntityState.Modified;
                _context.SaveChanges();
                response = new UtilitariesResponse<Box>(_config).setResponseBaseForOK();
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Box>(_config).setResponseBaseForException(e);
            }
            return response;
        }
    }
}
