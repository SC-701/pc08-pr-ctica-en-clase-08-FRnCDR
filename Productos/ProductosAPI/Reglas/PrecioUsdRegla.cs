using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;

namespace Reglas
{
    public class PrecioUsdRegla : IPrecioUsdRegla
    {
        private readonly IPrecioUsdServicio _precioUsdServicio;

        public PrecioUsdRegla(IPrecioUsdServicio precioUsdServicio)
        {
            _precioUsdServicio = precioUsdServicio;
        }

        public async Task<decimal> ConvertirCrcAUsd(decimal precioCrc)
        {
            var tipoCambio = await _precioUsdServicio.ObtenerTipoCambioAsync();
            return precioCrc / tipoCambio;
        }

    }
}

