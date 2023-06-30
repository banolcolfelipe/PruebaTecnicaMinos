using Hospital.Data;
using Hospital.Data.Repositories;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySQLConfiguration);

builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("MySqlConnection")));


builder.Services.AddScoped<ITipo_Doc, TipoDocRepository>();
builder.Services.AddScoped<IPaciente, PacienteRepository>();

// ----------------------------------//

//builder.Services.AddCors(options => 
//{
//    options.AddPolicy("NuevaPolitica", app => 
//    {
//        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    });

//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

//--------------------------------//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
