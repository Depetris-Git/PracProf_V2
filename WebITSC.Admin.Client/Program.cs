using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebITSC.Admin.Client;
using WebITSC.Admin.Client.Servicios;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Registra los componentes raíz de la aplicación Blazor
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registro de servicios
// Configuración para las llamadas HTTP (por ejemplo, si vas a hacer llamadas al servidor)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registro del servicio HttpServicios para interactuar con el backend (API)
builder.Services.AddScoped<IHttpServicios, HttpServicios>();

// Aquí registramos el servicio de roles que se utilizará en el cliente para manejar los roles del usuario
builder.Services.AddSingleton<ServicioRol>();

// Si tienes algún otro servicio específico del cliente, puedes agregarlo aquí
// builder.Services.AddScoped<OtroServicio>();

await builder.Build().RunAsync();



