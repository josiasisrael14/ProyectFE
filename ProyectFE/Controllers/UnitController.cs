using AutoMapper;
using Common;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;
using Services.Interfaces;

namespace ProyectoFE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitController : Controller
    {
        private readonly IConfigurationLib _config;
        private InterfazUnits _UnitServicio;
        private readonly IMapper _mapper;
        public UnitController(InterfazUnits UnitServicio, IMapper mapper, IConfigurationLib config)
        {
            _UnitServicio = UnitServicio;
            _mapper = mapper;
            _config = config;
        }

        [Route("GetUnit")]
        [HttpGet]
        public EResponseBase<UnitsResponseV1> GetUnit()
        {
            try
            {
                var servicio = _UnitServicio.GetUnit();
                var response = _mapper.Map<EResponseBase<UnitsResponseV1>>(servicio);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<UnitsResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("GetUnitById/{id}")]
        [HttpGet]
        public EResponseBase<UnitsResponseV1> GetUnitById(int id)
        {
            try
            {
                var UnitByID = _UnitServicio.GetUnitById(id);
                var response = _mapper.Map<EResponseBase<UnitsResponseV1>>(UnitByID);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<UnitsResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("InsertOrUpdateUnit")]
        [HttpPost]
        public EResponseBase<UnitsResponseV1> InsertOrUpdateUnit([FromBody] UnitsRequestV1 UnitsRequestV1)
        {
            try
            {
                var newUnit = _mapper.Map<Unit>(UnitsRequestV1);
                var data = _UnitServicio.InsertOrUpdateUnit(newUnit);
                var response = _mapper.Map<EResponseBase<UnitsResponseV1>>(data);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<UnitsResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("DeleteUnit")]
        [HttpDelete]
        public EResponseBase<UnitsResponseV1> DeleteUnit([FromBody] UnitsRequestV2 UnitsRequestV2)
        {
            try
            {
                var data = _mapper.Map<Unit>(UnitsRequestV2);
                var respuesta = _UnitServicio.DeleteUnit(data);
                var response = _mapper.Map<EResponseBase<UnitsResponseV1>>(respuesta);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<UnitsResponseV1>(_config).setResponseBaseForException(ex);
            }
        }
    }
}
