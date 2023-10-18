using Altiora_Test.Modelos;

namespace Altiora_Test.Interface
{
    public interface IArticuloRepository
    {
        IEnumerable<Articulo> ObtenerTodos();
        Articulo ObtenerPorId(int id);
        void CrearArticulo(Articulo articulo);
        void ActualizarArticulo(Articulo articulo);
        void EliminarArticulo(int id);
    }
}
