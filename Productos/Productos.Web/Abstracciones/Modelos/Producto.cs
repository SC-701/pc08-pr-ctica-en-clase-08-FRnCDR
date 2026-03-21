using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
        public class ProductoBase
        {
            [Required(ErrorMessage = "La propiedad nombre es requerida")]
            [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "El nombre solo debe contener letras")]
            public string Nombre { get; set; }
            [Required(ErrorMessage = "La descripcion placa es requerida")]
            [StringLength(200, ErrorMessage = "La descripcion del producto debe ser mayor a 4 caracteres y menor de 200 caracteres", MinimumLength = 4)]
            public string Descripcion { get; set; }
            [Required(ErrorMessage = "La propiedad precio es requerida")]
            [RegularExpression(@"^\d+.*$", ErrorMessage = "Debe iniciar con un número")]
            public decimal Precio { get; set; }
            [Required(ErrorMessage = "La propiedad stock es requerida")]
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "El stock debe ser un número entero")]
            public int Stock { get; set; }
            [Required(ErrorMessage = "La propiedad codigo de barras es requerida")]
            [StringLength(200, ErrorMessage = " El codigo de barras debe ser mayor a 4 caracteres y menor de 200 caracteres", MinimumLength = 4)]
            public string CodigoBarras { get; set; }
    }

        public class ProductoRequest : ProductoBase
        {
            public Guid IdSubCategoria { get; set; }
        }

        public class ProductoResponse : ProductoBase
        {
            public Guid Id { get; set; }
            public string? SubCategoria { get; set; }
            public string? Categoria { get; set; }
        }

        public class ProductoDetalle : ProductoResponse
        { 
            public decimal PrecioUsd { get; set; }
        }
}
