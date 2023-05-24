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
    public class BranchOfficeController : Controller
    {
        private readonly IConfigurationLib _config;
        private InterfazBranchOffice _BranchOfficeServicio;
        private readonly IMapper _mapper;
        public BranchOfficeController(InterfazBranchOffice BranchOfficeServicio, IMapper mapper, IConfigurationLib config)
        {
            _BranchOfficeServicio = BranchOfficeServicio;
            _mapper = mapper;
            _config = config;
        }

        [Route("GetBranchOffice")]
        [HttpGet]
        public EResponseBase<BranchOfficeResponseV1> GetBranchOffice()
        {
            try
            {
                var servicio = _BranchOfficeServicio.GetBranchOffice();
                var response = _mapper.Map<EResponseBase<BranchOfficeResponseV1>>(servicio);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<BranchOfficeResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("GetBranchOfficeById/{id}")]
        [HttpGet]
        public EResponseBase<BranchOfficeResponseV1> GetBranchOfficeById(int id)
        {
            try
            {
                var BranchOfficeByID = _BranchOfficeServicio.GetBranchOfficeById(id);
                var response = _mapper.Map<EResponseBase<BranchOfficeResponseV1>>(BranchOfficeByID);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<BranchOfficeResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("InsertOrUpdateBranchOffice")]
        [HttpPost]
        public EResponseBase<BranchOfficeResponseV1> InsertOrUpdateBranchOffice([FromBody] BranchOfficeRequestV1 BranchOfficesRequestV1)
        {
            try
            {
                var newBranchOffice = _mapper.Map<BranchOffice>(BranchOfficesRequestV1);
                var data = _BranchOfficeServicio.InsertOrUpdateBranchOffice(newBranchOffice);
                var response = _mapper.Map<EResponseBase<BranchOfficeResponseV1>>(data);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<BranchOfficeResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("DeleteBranchOffice")]
        [HttpDelete]
        public EResponseBase<BranchOfficeResponseV1> DeleteBranchOffice([FromBody] BranchOfficeRequestV2 BranchOfficesRequestV2)
        {
            try
            {
                var data = _mapper.Map<BranchOffice>(BranchOfficesRequestV2);
                var respuesta = _BranchOfficeServicio.DeleteBranchOffice(data);
                var response = _mapper.Map<EResponseBase<BranchOfficeResponseV1>>(respuesta);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<BranchOfficeResponseV1>(_config).setResponseBaseForException(ex);
            }
        }
    }
}
