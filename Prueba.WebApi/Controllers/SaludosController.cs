using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Prueba.WebApi.Controllers
{
    public class SaludosController : ApiController
    {
        [HttpGet]
        public string ObtenerSaludo(string nombre)
        {
            return $"Hola, {nombre}!";
        }
    }
}
