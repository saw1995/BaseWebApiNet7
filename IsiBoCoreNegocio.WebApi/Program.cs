using IsiBoCoreNegocio.Logger;
using IsiBoCoreNegocio.Model;
using IsiBoCoreNegocio.Repository;
using IsiBoCoreNegocio.Repository.UsuarioRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());

//Agregamos la interfaz a implementar
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//Instanciamos la cadena de conexion configuraciòn
var MySqlConnection = new Conexion(builder.Configuration.GetSection("MySqlConnectionConfig").Get<MySqlConfigurationModel>());

//Instanciamos ruta logs
var LoggerConfig = new LogPrint(builder.Configuration["RutaLogs"]);

//Agregamos a nuestra instancia de proyecto
builder.Services.AddSingleton(MySqlConnection);
builder.Services.AddSingleton(LoggerConfig);

//Aqui habilitamos el CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Habilita el uso de CORS
app.UseCors(); 

//Swagger UI EndPoint
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
