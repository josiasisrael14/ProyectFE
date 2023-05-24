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
    public class BoxController : Controller
    {
        private readonly IConfigurationLib _config;
        private InterfazBoxes _BoxServicio;
        private readonly IMapper _mapper;
        public BoxController(InterfazBoxes BoxServicio, IMapper mapper, IConfigurationLib config)
        {
            _BoxServicio = BoxServicio;
            _mapper = mapper;
            _config = config;
        }

        [Route("GetBox")]
        [HttpGet]
        public EResponseBase<BoxesResponseV1> GetBox()
        {
            try
            {
                var servicio = _BoxServicio.GetBox();
                var response = _mapper.Map<EResponseBase<BoxesResponseV1>>(servicio);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<BoxesResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("GetBoxById/{id}")]
        [HttpGet]
        public EResponseBase<BoxesResponseV1> GetBoxById(int id)
        {
            try
            {
                var BoxByID = _BoxServicio.GetBoxById(id);
                var response = _mapper.Map<EResponseBase<BoxesResponseV1>>(BoxByID);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<BoxesResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("InsertOrUpdateBox")]
        [HttpPost]
        public EResponseBase<BoxesResponseV1> InsertOrUpdateBox([FromBody] BoxesRequestV1 BoxsRequestV1)
        {
            try
            {
                var newBox = _mapper.Map<Box>(BoxsRequestV1);
                var data = _BoxServicio.InsertOrUpdateBox(newBox);
                var response = _mapper.Map<EResponseBase<BoxesResponseV1>>(data);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<BoxesResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("DeleteBox")]
        [HttpDelete]
        public EResponseBase<BoxesResponseV1> DeleteBox([FromBody] BoxesRequestV2 BoxsRequestV2)
        {
            try
            {
                var data = _mapper.Map<Box>(BoxsRequestV2);
                var respuesta = _BoxServicio.DeleteBox(data);
                var response = _mapper.Map<EResponseBase<BoxesResponseV1>>(respuesta);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<BoxesResponseV1>(_config).setResponseBaseForException(ex);
            }
        }
    }
}
