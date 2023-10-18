using Altiora_Test.Context;
using Altiora_Test.Interface;
using Altiora_Test.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Altiora_Test.Repositorio
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AltioraDb _context;

        public ClienteRepository(AltioraDb context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> ObtenerTodos()
        {
            return _context.Clientes.Include(c => c.Ordenes).ToList();
        }

        public Cliente ObtenerPorId(int id)
        {
            return _context.Clientes.Find(id);
        }

        public void CrearCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void ActualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void EliminarCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
