using Microsoft.EntityFrameworkCore;
using MottuControlApi.Data;
using MottuControlApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔌 Conexão com Oracle via EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// 💉 Injeção de dependência dos serviços
builder.Services.AddScoped<PatioService>();
builder.Services.AddScoped<MotoService>();
builder.Services.AddScoped<SensorService>();
builder.Services.AddScoped<ImagemService>();
builder.Services.AddScoped<StatusService>();

// 🌐 Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// 📘 Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🚀 Controllers
builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// 🔎 Ativar Swagger em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🌐 Middleware CORS global
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 🧪 Seed inicial de dados
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Inicializar(services);
}

app.Run();
