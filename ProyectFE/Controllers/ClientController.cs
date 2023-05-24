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
    public class ClientController : Controller
    {
        private readonly IConfigurationLib _config;
        private InterfazClient _ClientServicio;
        private readonly IMapper _mapper;
        public ClientController(InterfazClient ClientServicio, IMapper mapper, IConfigurationLib config)
        {
            _ClientServicio = ClientServicio;
            _mapper = mapper;
            _config = config;
        }

        [Route("GetClient")]
        [HttpGet]
        public EResponseBase<ClientResponseV1> GetClient()
        {
            try
            {
                var servicio = _ClientServicio.GetClient();
                var response = _mapper.Map<EResponseBase<ClientResponseV1>>(servicio);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<ClientResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("GetClientById/{id}")]
        [HttpGet]
        public EResponseBase<ClientResponseV1> GetClientById(int id)
        {
            try
            {
                var ClientByID = _ClientServicio.GetClientById(id);
                var response = _mapper.Map<EResponseBase<ClientResponseV1>>(ClientByID);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<ClientResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("InsertOrUpdateClient")]
        [HttpPost]
        public EResponseBase<ClientResponseV1> InsertOrUpdateClient([FromBody] ClientRequestV1 ClientsRequestV1)
        {
            try
            {
                var newClient = _mapper.Map<Client>(ClientsRequestV1);
                var data = _ClientServicio.InsertOrUpdateClient(newClient);
                var response = _mapper.Map<EResponseBase<ClientResponseV1>>(data);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<ClientResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("DeleteClient")]
        [HttpDelete]
        public EResponseBase<ClientResponseV1> DeleteClient([FromBody] ClientRequestV2 ClientsRequestV2)
        {
            try
            {
                var data = _mapper.Map<Client>(ClientsRequestV2);
                var respuesta = _ClientServicio.DeleteClient(data);
                var response = _mapper.Map<EResponseBase<ClientResponseV1>>(respuesta);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<ClientResponseV1>(_config).setResponseBaseForException(ex);
            }
        }
    }
}
