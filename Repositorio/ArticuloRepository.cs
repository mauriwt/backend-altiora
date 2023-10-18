using Altiora_Test.Context;
using Altiora_Test.Interface;
using Altiora_Test.Modelos;

namespace Altiora_Test.Repositorio
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly AltioraDb _context;

        public ArticuloRepository(AltioraDb context)
        {
            _context = context;
        }

        public IEnumerable<Articulo> ObtenerTodos()
        {
            return _context.Articulos.ToList();
        }

        public Articulo ObtenerPorId(int id)
        {
            return _context.Articulos.Find(id);
        }

        public void CrearArticulo(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            _context.SaveChanges();
        }

        public void ActualizarArticulo(Articulo articulo)
        {
            _context.Articulos.Update(articulo);
            _context.SaveChanges();
        }

        public void EliminarArticulo(int id)
        {
            var articulo = _context.Articulos.Find(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
                _context.SaveChanges();
            }
        }
    }
}
