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
    public class CompanyController : Controller
    {
        private readonly IConfigurationLib _config;
        private InterfazCompanie _CompanyServicio;
        private readonly IMapper _mapper;
        public CompanyController(InterfazCompanie CompanyServicio, IMapper mapper, IConfigurationLib config)
        {
            _CompanyServicio = CompanyServicio;
            _mapper = mapper;
            _config = config;
        }

        [Route("GetCompany")]
        [HttpGet]
        public EResponseBase<CompanieResponseV1> GetCompany()
        {
            try
            {
                var servicio = _CompanyServicio.GetCompany();
                var response = _mapper.Map<EResponseBase<CompanieResponseV1>>(servicio);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<CompanieResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("GetCompanyById/{id}")]
        [HttpGet]
        public EResponseBase<CompanieResponseV1> GetCompanyById(int id)
        {
            try
            {
                var CompanyByID = _CompanyServicio.GetCompanyById(id);
                var response = _mapper.Map<EResponseBase<CompanieResponseV1>>(CompanyByID);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<CompanieResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("InsertOrUpdateCompany")]
        [HttpPost]
        public EResponseBase<CompanieResponseV1> InsertOrUpdateCompany([FromBody] CompanieRequestV1 CompanysRequestV1)
        {
            try
            {
                var newCompany = _mapper.Map<Company>(CompanysRequestV1);
                var data = _CompanyServicio.InsertOrUpdateCompany(newCompany);
                var response = _mapper.Map<EResponseBase<CompanieResponseV1>>(data);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<CompanieResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("DeleteCompany")]
        [HttpDelete]
        public EResponseBase<CompanieResponseV1> DeleteCompany([FromBody] CompanieRequestV2 CompanysRequestV2)
        {
            try
            {
                var data = _mapper.Map<Company>(CompanysRequestV2);
                var respuesta = _CompanyServicio.DeleteCompany(data);
                var response = _mapper.Map<EResponseBase<CompanieResponseV1>>(respuesta);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<CompanieResponseV1>(_config).setResponseBaseForException(ex);
            }
        }
    }
}
