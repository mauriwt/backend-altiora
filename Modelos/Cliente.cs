namespace Altiora_Test.Modelos
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }
        public List<Orden> Ordenes { get; set; }

    }
}
