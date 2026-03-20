using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : Controller , ISubCategoriaController
    {
        private ISubCategoriaFlujo _subCategoriaFlujo;
        private ILogger<SubCategoriaController> _logger;

        public SubCategoriaController(ISubCategoriaFlujo subCategoriaFLujo, ILogger<SubCategoriaController> logger)
        {
            _subCategoriaFlujo = subCategoriaFLujo;
            _logger = logger;
        }
        [HttpGet("{IdCategoria}")]
        public async Task<IActionResult> Obtener(Guid IdCategoria)
        {
            var resultado = await _subCategoriaFlujo.Obtener(IdCategoria);
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }
    }
}
