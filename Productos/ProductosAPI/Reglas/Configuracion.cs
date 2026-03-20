using Abstracciones.Interfaces.Reglas;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Reglas
{
    public class Configuracion : IConfiguracion
    {
        private readonly IConfiguration _configuration;

        public Configuracion(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ObtenerMetodo(string seccion, string nombreMetodo)
        {
            var urlBase = _configuration[$"{seccion}:UrlBase"];
            var metodos = _configuration.GetSection($"{seccion}:Metodos").GetChildren();
            var metodo = metodos.FirstOrDefault(m => m["Nombre"] == nombreMetodo);
            var valor = metodo["Valor"];
            return $"{urlBase}/{valor}";
        }

        public string ObtenerValor(string llave)
        {
            return _configuration[llave] ?? string.Empty;
        }
    }
}
