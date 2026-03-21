using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Servicios
{
    public class APIEndPoint
    {

        public string? UrlBase { get; set; }

        public string BearerToken { get; set; }

    }

    public class Metodo
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }
    }
}
