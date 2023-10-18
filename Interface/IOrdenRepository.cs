using Altiora_Test.Modelos;

namespace Altiora_Test.Interface
{
    public interface IOrdenRepository
    {
        IEnumerable<Orden> ObtenerTodos();
        Orden ObtenerPorId(string id);
        void CrearOrden(Orden orden);
        void ActualizarOrden(Orden orden);
        void EliminarOrden(string id);
    }
}
