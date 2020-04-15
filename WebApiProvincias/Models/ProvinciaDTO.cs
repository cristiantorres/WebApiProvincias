using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProvincias.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ProvinciaDTO
    {

        public ProvinciaDTO(string nombre1, string latitud, string longitud)
        {
            this.nombre = nombre1;
            this.lat = latitud;
            this.lon = longitud;
        }

        public string nombre { get; set; }
        public string lat   { get; set; }
        public string lon { get; set; }
    }
}
