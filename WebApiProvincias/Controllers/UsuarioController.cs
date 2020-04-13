using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
 
using WebApiProvincias.Models;
using WebApiProvincias.Repositories;

namespace WebApiProvincias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;
        private readonly IUserRepository _repository;
        public UsuarioController(ILogger<UsuarioController> logger, IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
 

        [HttpPost("login")]
        public IActionResult Login(LoginInfo info)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var usuarioLogin = _repository.GetUserByLogin(info.username, info.password);
                if (usuarioLogin == null)
                {
                    _logger.LogWarning($"Usuario: { info.username } no encontrado");
                    return Ok(new { message = "usuario no registrado", user = new { } });
                }
                var _userVM = new
                                {
                                    username = usuarioLogin.username,
                                    nombre = usuarioLogin.nombre,
                                    apellido = usuarioLogin.apellido,
                                    mail = usuarioLogin.mail
                                }; 
                _logger.LogInformation($"Usuario logueado..... usuario: { info.username }");
                return Ok(new { message = "usuario logueado correctamente",
                                user = _userVM });
            }
            catch(Exception exception)
            {
                _logger.LogError($"Falla en:- Login :{exception.Message}");
                throw new Exception($"Problema al intentar el logueo del usuario {info.username}");
            }
        }

    }
}
