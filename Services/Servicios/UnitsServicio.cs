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
    public class UnitServicio : InterfazUnits
    {
        protected readonly ProyectDbContext _context;
        private readonly IConfigurationLib _config;

        public UnitServicio(ProyectDbContext context, IConfigurationLib config)
        {
            _context = context;
            _config = config;
        }

        public EResponseBase<Unit> GetUnit()
        {
            EResponseBase<Unit> response;
            try
            {
                IQueryable<Unit> query = _context.Units.Where(x => x.MeasureActive == 1);
                response = new UtilitariesResponse<Unit>(_config).setResponseBaseForList(query);
                _context.Database.CloseConnection();
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Unit>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<Unit> GetUnitById(int id)
        {
            EResponseBase<Unit> response;
            try
            {
                IQueryable<Unit> query = _context.Units.Where(x => x.MeasureActive == 1).Where(x => x.IdUnit == id);
                response = new UtilitariesResponse<Unit>(_config).setResponseBaseForList(query);
                _context.Database.CloseConnection();
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Unit>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<Unit> InsertOrUpdateUnit(Unit data)
        {
            EResponseBase<Unit> response;
            try
            {
                if (data.IdUnit > 0)
                {
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    response = new UtilitariesResponse<Unit>(_config).setResponseBaseForOK(data);
                }
                else
                {
                    data.MeasureActive = 1;
                    _context.Units.Add(data);
                    _context.SaveChanges();
                    response = new UtilitariesResponse<Unit>(_config).setResponseBaseForOK(data);
                }
                _context.Database.CloseConnection();
                return response;
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Unit>(_config).setResponseBaseForException(e);
            }
            return response;
        }

        public EResponseBase<Unit> DeleteUnit(Unit data)
        {
            EResponseBase<Unit> response;
            try
            {
                var obtenerdato = _context.Units.Find(data.IdUnit);
                obtenerdato.MeasureActive = 2;
                _context.Entry(obtenerdato).State = EntityState.Modified;
                _context.SaveChanges();
                response = new UtilitariesResponse<Unit>(_config).setResponseBaseForOK();
                _context.Database.CloseConnection();
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Unit>(_config).setResponseBaseForException(e);
            }
            return response;
        }
    }
}
