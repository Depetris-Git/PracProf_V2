using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Onlyou.Client.Autorizacion;
using WebITSC.Admin.Client;
using WebITSC.Admin.Client.Autorizacion;
using WebITSC.Admin.Client.Servicios;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Registra los componentes raíz de la aplicación Blazor
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();

// Configuración para las llamadas HTTP (por ejemplo, si vas a hacer llamadas al servidor)
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registro del servicio HttpServicios para interactuar con el backend (API)
builder.Services.AddScoped<IHttpServicios, HttpServicios>();


builder.Services.AddScoped<ProveedorAutenticacionJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, ProveedorAutenticacionJWT>(prov => prov.GetRequiredService<ProveedorAutenticacionJWT>());
builder.Services.AddScoped<ILoginService, ProveedorAutenticacionJWT>(prov => prov.GetRequiredService<ProveedorAutenticacionJWT>());



// Si tienes algún otro servicio específico del cliente, puedes agregarlo aquí
// builder.Services.AddScoped<OtroServicio>();

await builder.Build().RunAsync();



