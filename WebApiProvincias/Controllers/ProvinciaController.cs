using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WebApiProvincias.Model;
using WebApiProvincias.Models;

namespace WebApiProvincias.Controllers
{
    [Produces("application/json")]
    [Route("api/provincia")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly ILogger<ProvinciaController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public ProvinciaController(ILogger<ProvinciaController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        // GET: api/provincias/nombre
        [HttpGet("{nombre}")]
        public IActionResult GetProvincia(string nombre)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    var _url = $"https://apis.datos.gob.ar/georef/api/provincias?nombre={nombre}";
                    Uri _uri = new Uri(_url);
                    var responseTask = client.GetStringAsync(_uri);
                    _logger.LogInformation($"Se realizo la busqueda de la provincia: { nombre }");

                    JObject _jsonResponse = JObject.Parse(responseTask.Result);
                    var _provinciasEncontradas = (JArray)_jsonResponse["provincias"];
                    if (_provinciasEncontradas.Count == 0)
                    {
                        var _coordenadas = new { latitud = 0, longitud = 0 };
                        return NotFound(new { provincia = nombre, coordenadas = _coordenadas });
                    }

                    var latitud = _jsonResponse["provincias"][0]["centroide"]["lat"];
                    var longitud = (string)_jsonResponse["provincias"][0]["centroide"]["lon"];
                    ProvinciaDTO _DTOresponse = new ProvinciaDTO(nombre, latitud.ToString(), longitud);
                    return Ok(_DTOresponse);
                }
            }
            catch(Exception exception)
            {
                _logger.LogInformation($"Fallo en la busqueda de la provincia: { nombre } -- Problema: {exception.Message}");
                throw new Exception($"Problema al intentar realizar la busqueda de Provincia: {nombre}");
            }
        }
    }

}