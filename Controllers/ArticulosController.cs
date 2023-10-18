using Altiora_Test.Interface;
using Altiora_Test.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Altiora_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticuloRepository _articuloRepository;

        public ArticulosController(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var articulos = _articuloRepository.ObtenerTodos();
            return Ok(articulos);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var articulo = _articuloRepository.ObtenerPorId(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(articulo);
        }

        [HttpPost]
        public IActionResult CrearArticulo([FromBody] Articulo articulo)
        {
            _articuloRepository.CrearArticulo(articulo);
            return Ok(articulo);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarArticulo(int id, [FromBody] Articulo articulo)
        {
            var articuloExistente = _articuloRepository.ObtenerPorId(id);

            if (articuloExistente == null)
            {
                return NotFound();
            }

            // Actualiza otras propiedades según sea necesario

            _articuloRepository.ActualizarArticulo(articuloExistente);

            return Ok(articuloExistente);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarArticulo(int id)
        {
            var articuloExistente = _articuloRepository.ObtenerPorId(id);

            if (articuloExistente == null)
            {
                return NotFound();
            }

            _articuloRepository.EliminarArticulo(id);

            return Ok();
        }
    }
}
