using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Helpers;
using TestApi.Models;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PersonasController : ControllerBase
    {
        private readonly IConfiguration _config;

        public PersonasController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public IEnumerable<object> GetAll() {
            var personas = new List<object>() {
                new {
                    nombre = "Francisco",
                    estatura = 1.86,
                    nacionalidad = "Mex"
                },
                new {
                    nombre = "Patricia",
                    estatura = 1.70,
                    nacionalidad = "Mex"
                },
                new {
                    nombre = "Tomás",
                    estatura = 1.60,
                    nacionalidad = "Mex"
                },
                new {
                    nombre = "Tomás",
                    estatura = 1.43,
                    nacionalidad = "Mex"
                },
                new {
                    nombre = "Gabriel",
                    estatura = 1.25,
                    nacionalidad = "Mex"
                },
            };

            return personas;
        }

        [HttpPost]
        public ActionResult<object> Login(Persona persona)
        {
            string secret = this._config.GetValue<string>("Secret");

            var jwtHelper = new JWTHelper(secret);
            var token = jwtHelper.CreateToken(persona.Usuario);

            return Ok(new
            {
                ok = true,
                msg = "Logeado con éxito",
                token
            });
        }
    }
}
