using Altiora_Test.Modelos;
using EjercicioPrueba.Modelos;

namespace Altiora_Test.Context
{
    public static class DatoInicial
    {
        public static void Initialize(AltioraDb context)
        {
            context.Database.EnsureCreated(); // Asegurar que la base de datos está creada

            // Verificar si ya hay datos en la base de datos
            if (context.Clientes.Any())
            {
                return; // Ya se han insertado datos
            }

            var cliente1 = new Cliente
            {
                Nombres = "Wilson Mauricio",
                Apellidos = "Tituaña Maldonado",
            };
            context.Clientes.Add(cliente1);

            var orden1 = new Orden { Id = "OC_000001", Cliente = cliente1 };
            context.Ordenes.Add(orden1);

            var articulo1 = new Articulo { Nombre = "Articulo A", PrecioUnitario = 15.99 };
            var articulo2 = new Articulo { Nombre = "Articulo B", PrecioUnitario = 25.49 };
            context.Articulos.AddRange(articulo1, articulo2);

            var ordenArticulo1 = new OrdenArticulo { Orden = orden1, Articulo = articulo1 };
            var ordenArticulo2 = new OrdenArticulo { Orden = orden1, Articulo = articulo2 };
            context.OrdenArticulos.AddRange(ordenArticulo1, ordenArticulo2);

            // Cliente 2
            var cliente2 = new Cliente {
                Nombres = "Diego",
                Apellidos = "Alpala",
            };
            context.Clientes.Add(cliente2);

            var orden2 = new Orden { Id = "OC_000002", Cliente = cliente2 };
            context.Ordenes.Add(orden2);

            var articulo3 = new Articulo { Nombre = "Articulo C", PrecioUnitario = 19.99 };
            var articulo4 = new Articulo { Nombre = "Articulo D", PrecioUnitario = 30.90 };
            context.Articulos.AddRange(articulo3, articulo4);

            var ordenArticulo3 = new OrdenArticulo { Orden = orden2, Articulo = articulo3 };
            var ordenArticulo4 = new OrdenArticulo { Orden = orden2, Articulo = articulo4 };
            context.OrdenArticulos.AddRange(ordenArticulo3, ordenArticulo4);

            context.SaveChanges();
        }
    }
}
