using Altiora_Test.Interface;
using Altiora_Test.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Altiora_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenRepository _ordenRepository;

        public OrdenesController(IOrdenRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var ordenes = _ordenRepository.ObtenerTodos();
            return Ok(ordenes);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(string id)
        {
            var orden = _ordenRepository.ObtenerPorId(id);

            if (orden == null)
            {
                return NotFound();
            }

            // Include para cargar relaciones
            

            return Ok(orden);
        }

        [HttpPost]
        public IActionResult CrearOrden([FromBody] Orden orden)
        {
            _ordenRepository.CrearOrden(orden);
            return Ok(orden);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarOrden(string id, [FromBody] Orden orden)
        {
            var ordenExistente = _ordenRepository.ObtenerPorId(id);

            if (ordenExistente == null)
            {
                return NotFound();
            }

            // Actualiza otras propiedades según sea necesario

            _ordenRepository.ActualizarOrden(ordenExistente);

            return Ok(ordenExistente);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarOrden(string id)
        {
            var ordenExistente = _ordenRepository.ObtenerPorId(id);

            if (ordenExistente == null)
            {
                return NotFound();
            }

            _ordenRepository.EliminarOrden(id);

            return Ok();
        }
    }
}