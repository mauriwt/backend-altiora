using Altiora_Test.Modelos;

namespace EjercicioPrueba.Modelos
{
    public class OrdenArticulo
    {
        public string OrdenId { get; set; }
        public Orden Orden { get; set; }

        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
    }
}
