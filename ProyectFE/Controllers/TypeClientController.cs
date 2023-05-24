using AutoMapper;
using Common;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;
using Services.Interfaces;
using Solutions;

namespace ProyectoFE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeClientController : Controller
    {
        private readonly IConfigurationLib _config;
        private InterfazTypeClients _TypeClientServicio;
        private readonly IMapper _mapper;
        public TypeClientController(InterfazTypeClients TypeClientServicio, IMapper mapper, IConfigurationLib config)
        {
            _TypeClientServicio = TypeClientServicio;
            _mapper = mapper;
            _config = config;
        }

        [Route("GetTypeClient")]
        [HttpGet]
        public EResponseBase<TypeClientsResponseV1> GetTypeClient()
        {
            try
            {
                var servicio = _TypeClientServicio.GetTypeClient();
                var response = _mapper.Map<EResponseBase<TypeClientsResponseV1>>(servicio);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<TypeClientsResponseV1>(_config).setResponseBaseForException(ex);
            }
        }
    }
}
