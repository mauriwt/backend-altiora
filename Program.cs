using Altiora_Test.Context;
using Altiora_Test.Interface;
using Altiora_Test.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AltioraDb>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AltioraConexion")));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IOrdenRepository, OrdenRepository>();
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AltioraDb>();
        context.Database.Migrate();

        DatoInicial.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrio un error al inicializar datos.");
    }
}

app.UseCors(x => //x.SetIsOriginAllowed(x => x.StartsWith("http:\\localhost:4200"))
    x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
