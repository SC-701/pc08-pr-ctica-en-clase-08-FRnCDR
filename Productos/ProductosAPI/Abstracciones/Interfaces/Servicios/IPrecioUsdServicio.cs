using Abstracciones.Modelos.Servicios.PrecioUsd;

namespace Abstracciones.Interfaces.Servicios
{
    public interface IPrecioUsdServicio
    {
        Task<decimal> ObtenerTipoCambioAsync();
    }

}
