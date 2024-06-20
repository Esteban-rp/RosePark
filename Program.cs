using RosePark.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Microsoft.Extensions.Configuration;

// Cargar el archivo .env antes de cualquier configuración
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Añadir configuraciones
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Construir la configuración
var configuration = builder.Configuration;

// Obtener las variables de entorno
var server = configuration["Server"];
var port = configuration["Port"];
var database = configuration["Database"];
var user = configuration["User"];
var password = configuration["Password"];

// Construir la cadena de conexión manualmente
var connectionString = $"server={server};port={port};database={database};uid={user};password={password}";

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(
        connectionString,
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
