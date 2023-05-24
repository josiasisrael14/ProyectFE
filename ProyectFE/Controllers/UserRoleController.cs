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
    public class UserRoleController : Controller
    {
        private readonly IConfigurationLib _config;
        private InterfazUserRoles _UserRoleServicio;
        private readonly IMapper _mapper;
        public UserRoleController(InterfazUserRoles UserRoleServicio, IMapper mapper, IConfigurationLib config)
        {
            _UserRoleServicio = UserRoleServicio;
            _mapper = mapper;
            _config = config;
        }

        [Route("GetUserRole")]
        [HttpGet]
        public EResponseBase<UserRolesResponseV1> GetUserRole()
        {
            try
            {
                var servicio = _UserRoleServicio.GetUserRole();
                var response = _mapper.Map<EResponseBase<UserRolesResponseV1>>(servicio);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<UserRolesResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("GetUserRoleById/{id}")]
        [HttpGet]
        public EResponseBase<UserRolesResponseV1> GetUserRoleById(int id)
        {
            try
            {
                var UserRoleByID = _UserRoleServicio.GetUserRoleById(id);
                var response = _mapper.Map<EResponseBase<UserRolesResponseV1>>(UserRoleByID);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<UserRolesResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("InsertOrUpdateUserRole")]
        [HttpPost]
        public EResponseBase<UserRolesResponseV1> InsertOrUpdateUserRole([FromBody] UserRolesRequestV1 UserRolesRequestV1)
        {
            try
            {
                var newUserRole = _mapper.Map<UserRole>(UserRolesRequestV1);
                var data = _UserRoleServicio.InsertOrUpdateUserRole(newUserRole);
                var response = _mapper.Map<EResponseBase<UserRolesResponseV1>>(data);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<UserRolesResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("DeleteUserRole")]
        [HttpDelete]
        public EResponseBase<UserRolesResponseV1> DeleteUserRole([FromBody] UserRolesRequestV2 UserRolesRequestV2)
        {
            try
            {
                var data = _mapper.Map<UserRole>(UserRolesRequestV2);
                var respuesta = _UserRoleServicio.DeleteUserRole(data);
                var response = _mapper.Map<EResponseBase<UserRolesResponseV1>>(respuesta);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<UserRolesResponseV1>(_config).setResponseBaseForException(ex);
            }
        }
    }
}
