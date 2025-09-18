using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WebITSC.Admin.Client.Autorizacion
{
    public class ProveedorAutenticacion : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(5000);

            var Anonimo = new ClaimsIdentity();
            var usuario = new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim (ClaimTypes.Name , "Administrador!!"),
                    new Claim("Dni", "46591510"),
                    new Claim(ClaimTypes.Role, "admin")
                },

                authenticationType: "apiAuthentication");


            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(usuario)));
        }
        //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    //await Task.Delay(5000);
        //    var anonimo = new ClaimsIdentity();
        //    var usuarioPepe = new ClaimsIdentity(
        //        new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, "Pepe Sanchez"),
        //            new Claim(ClaimTypes.Role, "admin"),
        //            new Claim(ClaimTypes.Role, "operador"),
        //            new Claim("DNI", "12.587.895"),
        //        },
        //        authenticationType: "ok"
        //        );
        //    var usuarioJuan = new ClaimsIdentity(
        //        new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, "Juan Perez"),
        //            new Claim(ClaimTypes.Role, "operador"),
        //            new Claim("DNI", "12.587.895"),
        //        },
        //        authenticationType: "ok"
        //        );
        //    return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(usuarioJuan)));
        //}
    }
}
