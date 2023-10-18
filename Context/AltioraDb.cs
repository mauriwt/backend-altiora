namespace Altiora_Test.Context
{
    using Microsoft.EntityFrameworkCore;
    using Altiora_Test.Modelos;
    using EjercicioPrueba.Modelos;

    public class AltioraDb : DbContext
    {
        public AltioraDb(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }

        public DbSet<OrdenArticulo> OrdenArticulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdenArticulo>()
                .HasKey(oa => new { oa.OrdenId, oa.ArticuloId });

            modelBuilder.Entity<OrdenArticulo>()
                .HasOne(oa => oa.Orden)
                .WithMany(o => o.OrdenArticulos)
                .HasForeignKey(oa => oa.OrdenId);

            modelBuilder.Entity<OrdenArticulo>()
                .HasOne(oa => oa.Articulo)
                .WithMany(a => a.OrdenArticulos)
                .HasForeignKey(oa => oa.ArticuloId);

            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Cliente)
                .WithMany(c => c.Ordenes)
                .HasForeignKey(o => o.ClienteId)
                .OnDelete(DeleteBehavior.Cascade); // Esto eliminará las órdenes del cliente si el cliente se elimina
        }
    }
}
