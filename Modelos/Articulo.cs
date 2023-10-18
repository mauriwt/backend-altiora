using EjercicioPrueba.Modelos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Altiora_Test.Modelos
{
    [Table("Articulo")]
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }
        public List<OrdenArticulo> OrdenArticulos { get; set; } = new List<OrdenArticulo>();
    }
}
