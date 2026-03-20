using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

namespace Flujo
{
    public class ProductoFlujo : IProductoFlujo
    {
        private readonly IProductoDA _productoDA;
        private readonly IPrecioUsdRegla _precioUsdRegla;

        public ProductoFlujo(IProductoDA productoDA, IPrecioUsdRegla precioUsdRegla)
        {
            _productoDA = productoDA;
            _precioUsdRegla = precioUsdRegla;
        }

        public async Task<Guid> Agregar(ProductoRequest producto)
        {
            return await _productoDA.Agregar(producto);
        }

        public async Task<Guid> Editar(Guid Id, ProductoRequest producto)
        {
            return await _productoDA.Editar(Id, producto);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _productoDA.Eliminar(Id);
        }

        public async Task<IEnumerable<ProductoResponse>> Obtener()
        {
            return await _productoDA.Obtener();
        }

        public async Task<ProductoDetalle> Obtener(Guid Id)
        {
            var producto = await _productoDA.Obtener(Id);

            var detalle = new ProductoDetalle
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.Stock,
                CodigoBarras = producto.CodigoBarras,
                SubCategoria = producto.SubCategoria,
                Categoria = producto.Categoria
            };

            detalle.PrecioUsd = await _precioUsdRegla.ConvertirCrcAUsd(detalle.Precio);

            return detalle;
        }


    }
}
