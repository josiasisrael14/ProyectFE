using AutoMapper;
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
    public class LoginController : Controller
    {
        private InterfazLogin _LoginServicio;
        private readonly IMapper _mapper;
        public LoginController(InterfazLogin LoginServicio, IMapper mapper)
        {
            _LoginServicio = LoginServicio;
            _mapper = mapper;
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult<User> GetUsersByIdentificador(UsersRequestV3 UsersRequestV3)
        {
            try
            {
                var validacion = _mapper.Map<User>(UsersRequestV3);
                var servicio = _LoginServicio.GetUsersByIdentificador(validacion);
                if (servicio != null)
                {
                    var token = _LoginServicio.generartoken(servicio);
                    return (ActionResult)ResponseHelper.CreateJsonResponse(token);

                }
                return (ActionResult)ResponseHelper.NuleData();
            }
            catch (Exception)
            {
                return (ActionResult)ResponseHelper.GlobalError();
            }
        }
    }
}
