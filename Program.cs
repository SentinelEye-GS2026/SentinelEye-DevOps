using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using SentinelEye.Data;

using SentinelEye.Repositories;
using SentinelEye.Repositories.Interfaces;

using SentinelEye.Services;
using SentinelEye.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SentinelEye API",
        Version = "v1",
        Description = "API REST para monitoramento global de riscos e ocorrências."
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseOracle(
        builder.Configuration.GetConnectionString("OracleConnection")
    );
});

builder.Services.AddScoped<IAlertaRepository, AlertaRepository>();

builder.Services.AddScoped<IRegiaoRepository, RegiaoRepository>();

builder.Services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();

builder.Services.AddScoped<IImagemSateliteRepository, ImagemSateliteRepository>();

builder.Services.AddScoped<IAgenteRepository, AgenteRepository>();

builder.Services.AddScoped<IAlertaService, AlertaService>();

builder.Services.AddScoped<IRegiaoService, RegiaoService>();

builder.Services.AddScoped<IOcorrenciaService, OcorrenciaService>();

builder.Services.AddScoped<IImagemSateliteService, ImagemSateliteService>();

builder.Services.AddScoped<IAgenteService, AgenteService>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(); //para usar o swagger acessar somente com a porta fornecida e o caminho /swagger

app.MapScalarApiReference(options =>
{
    options.WithOpenApiRoutePattern("/swagger/v1/swagger.json");
}); //para acessar o scalar deve colocar a porta fornecida e o caminho /scalar/v1

app.UseAuthorization();

app.MapControllers();

app.Run();