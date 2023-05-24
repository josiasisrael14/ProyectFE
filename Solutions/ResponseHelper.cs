using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    public class ResponseHelper
    {
        public static IActionResult CreateJsonResponse(object data, int statusCode = 200)
        {
            var response = new
            {
                Message = "La operacion fue realizada con exito",
                Code = statusCode,
                Data = data
            };

            return new JsonResult(response) { StatusCode = statusCode };
        }

        public static IActionResult DeleteMesaje(int statusCode = 200)
        {
            var response = new
            {
                Title = "La operacion fue realizada con exito",
                Message = "El registro fue eliminado exitosamente",
                Code = statusCode,
            };

            return new JsonResult(response) { StatusCode = statusCode };
        }

        public static IActionResult NuleData(int statusCode = 200)
        {
            var response = new
            {
                Title = "No se encontro ningun registro",
                Code = statusCode,
            };

            return new JsonResult(response) { StatusCode = statusCode };
        }

        public static IActionResult GlobalError(int statusCode = 600)
        {
            var response = new
            {
                Title = "Ocurrio un error",
                Message = "Comunicarse con el desarrollador del sistema",
                Code = statusCode,
            };
            return new JsonResult(response) { StatusCode = statusCode };
        }
    }
}
