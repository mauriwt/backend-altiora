using Altiora_Test.Modelos;

namespace Altiora_Test.Interface
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ObtenerTodos();
        Cliente ObtenerPorId(int id);
        void CrearCliente(Cliente cliente);
        void ActualizarCliente(Cliente cliente);
        void EliminarCliente(int id);
    }
}
