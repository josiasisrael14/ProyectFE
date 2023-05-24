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
    public class UserController : Controller
    {
        private readonly IConfigurationLib _config;
        private InterfazUsers _UserServicio;
        private readonly IMapper _mapper;
        public UserController(InterfazUsers UserServicio, IMapper mapper, IConfigurationLib config)
        {
            _UserServicio = UserServicio;
            _mapper = mapper;
            _config = config;
        }

        [Route("GetUser")]
        [HttpGet]
        public EResponseBase<UsersResponseV1> GetUser()
        {
            try
            {
                var servicio = _UserServicio.GetUser();
                var response = _mapper.Map<EResponseBase<UsersResponseV1>>(servicio);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<UsersResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("GetUserById/{id}")]
        [HttpGet]
        public EResponseBase<UsersResponseV1> GetUserById(int id)
        {
            try
            {
                var UserByID = _UserServicio.GetUserById(id);
                var response = _mapper.Map<EResponseBase<UsersResponseV1>>(UserByID);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<UsersResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("InsertOrUpdateUser")]
        [HttpPost]
        public EResponseBase<UsersResponseV1> InsertOrUpdateUser([FromBody] UsersRequestV1 UsersRequestV1)
        {
            try
            {
                var newuser = _mapper.Map<User>(UsersRequestV1);
                var data = _UserServicio.InsertOrUpdateUser(newuser);
                var response = _mapper.Map<EResponseBase<UsersResponseV1>>(data);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<UsersResponseV1>(_config).setResponseBaseForException(ex);
            }
        }

        [Route("DeleteUser")]
        [HttpDelete]
        public EResponseBase<UsersResponseV1> DeleteUser([FromBody] UsersRequestV2 UsersRequestV2)
        {
            try
            {
                var data = _mapper.Map<User>(UsersRequestV2);
                var respuesta = _UserServicio.DeleteUser(data);
                var response = _mapper.Map<EResponseBase<UsersResponseV1>>(respuesta);
                return response;
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<UsersResponseV1>(_config).setResponseBaseForException(ex);
            }
        }
    }
}
