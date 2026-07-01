using ServicioUsuarios.Repositorios;
using ServicioUsuarios.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Agrego el nativo de .net para no agregar un endpoint de health check manualmente
builder.Services.AddHealthChecks();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped<IRepositorioEstudiantes, RepositorioEstudiantes>();
builder.Services.AddScoped<IServicioEstudiantes, ServicioEstudiantes>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapHealthChecks("/health/usuarios/live");
app.MapHealthChecks("/health/usuarios/ready");

app.Run();