using ServicioDocumentos.Clientes;
using ServicioDocumentos.Repositorios;
using ServicioDocumentos.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped<IRepositorioDocumentos, RepositorioDocumentos>();

builder.Services.AddScoped<IServicioGestionDocumentos, ServicioGestionDocumentos>();

builder.Services.AddHttpClient<IClienteUsuarios, ClienteUsuarios>(client =>
{
    client.BaseAddress = new Uri("http://localhost:6001/");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();