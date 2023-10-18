using Altiora_Test.Context;
using Altiora_Test.Interface;
using Altiora_Test.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Altiora_Test.Repositorio
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly AltioraDb _context;

        public OrdenRepository(AltioraDb context)
        {
            _context = context;
        }

        public IEnumerable<Orden> ObtenerTodos()
        {
            return _context.Ordenes.Include(o => o.Cliente)
                            .Include(o => o.OrdenArticulos)
                                .ThenInclude(oa => oa.Articulo)
                            .ToList();
        }

        public Orden ObtenerPorId(string id)
        {
            return _context.Ordenes.Where(e => e.Id == id).Include(o => o.Cliente)
                        .Include(o => o.OrdenArticulos)
                            .ThenInclude(oa => oa.Articulo)
                        .FirstOrDefault();
        }

        public void CrearOrden(Orden orden)
        {
            _context.Ordenes.Add(orden);
            _context.SaveChanges();
        }

        public void ActualizarOrden(Orden orden)
        {
            _context.Ordenes.Update(orden);
            _context.SaveChanges();
        }

        public void EliminarOrden(string id)
        {
            var orden = _context.Ordenes.Find(id);
            if (orden != null)
            {
                _context.Ordenes.Remove(orden);
                _context.SaveChanges();
            }
        }
    }
}
