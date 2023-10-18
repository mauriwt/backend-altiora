using Altiora_Test.Context;
using Altiora_Test.Interface;
using Altiora_Test.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Altiora_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var clientes = _clienteRepository.ObtenerTodos();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var cliente = _clienteRepository.ObtenerPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult CrearCliente([FromBody] Cliente cliente)
        {
            _clienteRepository.CrearCliente(cliente);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarCliente(int id, [FromBody] Cliente cliente)
        {
            var clienteExistente = _clienteRepository.ObtenerPorId(id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            clienteExistente.Nombres = cliente.Nombres;
            clienteExistente.Apellidos = cliente.Nombres;

            // Actualiza otras propiedades según sea necesario

            _clienteRepository.ActualizarCliente(clienteExistente);

            return Ok(clienteExistente);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCliente(int id)
        {
            var clienteExistente = _clienteRepository.ObtenerPorId(id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            _clienteRepository.EliminarCliente(id);

            return Ok();
        }
    }
}
