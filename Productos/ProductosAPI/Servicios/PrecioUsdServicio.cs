using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.PrecioUsd;
using System.Text.Json;

namespace Servicios
{
    public class PrecioUsdServicio : IPrecioUsdServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public PrecioUsdServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<decimal> ObtenerTipoCambioAsync()
        {
            var urlBase = _configuracion.ObtenerValor("ApiEndpointsPrecioUsd:UrlBase");
            var token = _configuracion.ObtenerValor("ApiEndpointsPrecioUsd:BearerToken");
            var fecha = DateTime.Today.ToString("yyyy/MM/dd");
            var url = $"{urlBase}?fechaInicio={fecha}&fechaFin={fecha}&idioma=es";
            var client = _httpClient.CreateClient("ServicioPrecioUsd");
            client.DefaultRequestHeaders.Remove("Authorization");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var resp = await client.GetAsync(url);
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<RootTipoDeCambio>(json, opciones);
            var tipoCambio = data?.datos?
                .FirstOrDefault()?.indicadores?
                .FirstOrDefault()?.series?
                .FirstOrDefault()?.valorDatoPorPeriodo ?? 0;
            return (decimal)tipoCambio;
        }
    }
}
