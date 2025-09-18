using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Repositorio.General;
using Repositorio.General.Repos_Genericos.Residencia;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebITSC.Admin.Client.Servicios;
using WebITSC.Admin.Server.Repositorio;
using WebITSC.DB.Data;
using WebITSC.DB.Data.Entity;
using WebITSC.Server.Controllers.General;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOutputCache(options =>
{
    options.DefaultExpirationTimeSpan = TimeSpan.FromMinutes(60);
});


// Add services to the container.
// servicio controller 
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Si necesitas mantener los nombres de propiedades
    });

//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//    });

//swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Mi API", Version = "v1" });
});


// servicio controller
builder.Services.AddControllers();


//servicio Client
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

//SERVICIOS IDENTITY 
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

//contraseña
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"])),
            ClockSkew = TimeSpan.Zero // Esto reduce el sesgo del reloj a cero para fines de prueba
        };
    });

//SERVICIO DE MAPPER
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//SERVICIO DE ROLES FRONT
builder.Services.AddSingleton<ServicioRol>();



//builder.Services.AddScoped<IJSRuntime, JSRuntime>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//servicio que conecta la bd
builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IAlumnoRepositorio, AlumnoRepositorio>();
builder.Services.AddScoped<IRepositorio<CertificadoAlumno>, Repositorio<CertificadoAlumno>>();
builder.Services.AddScoped<IRepositorio<Clase>, Repositorio<Clase>>();
builder.Services.AddScoped<IRepositorio<ClaseAsistencia>, Repositorio<ClaseAsistencia>>();

builder.Services.AddScoped<IRepositorio<Correlatividad>, Repositorio<Correlatividad>>();

builder.Services.AddScoped<ICursadoMateriaRepositorio, CursadoMateriaRepositorio>();
builder.Services.AddScoped<IEvaluacionRepositorio, EvaluacionRepositorio>();
builder.Services.AddScoped<IInscripcionCarreraRepositorio, InscripcionCarreraRepositorio>();

builder.Services.AddScoped<IRepositorio<Materia>, Repositorio<Materia>>();
builder.Services.AddScoped<IMateriaEnPlanEstudioRepositorio, MateriaEnPlanEstudioRepositorio>();
builder.Services.AddScoped<INotaRepositorio, NotaRepositorio>();
builder.Services.AddScoped<IRepositorio<Persona>, Repositorio<Persona>>();
builder.Services.AddScoped<IPlanEstudioRepositorio, PlanEstudioRepositorio>();
builder.Services.AddScoped<IRepositorio<Profesor>, Repositorio<Profesor>>();
builder.Services.AddScoped<ITurnoRepositorio, TurnoRepositorio>();
builder.Services.AddScoped<ICertificadoAlumnoRepositorio, CertificadoAlumnoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
builder.Services.AddScoped<ICarreraRepositorio, CarreraRepositorio>();
builder.Services.AddScoped<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>();

builder.Services.AddScoped<IPaisRepositorio, PaisRepositorio>();
builder.Services.AddScoped<IProvinciaRepositorio, ProvinciaRepositorio>();
builder.Services.AddScoped<IDepartamentoRepositorio, DepartamentoRepositorio>();
builder.Services.AddScoped<ILocalidadRepositorio, LocalidadRepositorio>();

// Registrar HttpServicios
builder.Services.AddScoped<IHttpServicios, HttpServicios>();


var app = builder.Build();

// Crear roles automáticamente al iniciar la app
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    if (!await roleManager.RoleExistsAsync("admin"))
        await roleManager.CreateAsync(new IdentityRole("admin"));

    if (!await roleManager.RoleExistsAsync("operador"))
        await roleManager.CreateAsync(new IdentityRole("operador"));
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
 
app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.UseExceptionHandler("/error"); // Cambia esto para devolver JSON si es necesario

app.UseAuthentication();

app.UseAuthorization();

app.UseOutputCache();  //cache

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();

