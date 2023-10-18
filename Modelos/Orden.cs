using EjercicioPrueba.Modelos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Altiora_Test.Modelos
{
    [Table("Orden")]
    public class Orden
    {
        [Key]
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<OrdenArticulo> OrdenArticulos { get; set; } = new List<OrdenArticulo>();
    }
}
