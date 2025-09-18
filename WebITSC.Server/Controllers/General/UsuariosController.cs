using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebITSC.Admin.Server.Repositorio;
using WebITSC.DB.Data.Entity;
using WebITSC.Shared.General.DTO.UsuariosDTO;

namespace WebITSC.Server.Controllers.General
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public UsuariosController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager,
                                 IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UserTokenDTO>> CrearUsuario([FromBody] UserInfoDTO modelo)
        {
            var usuario = new IdentityUser { UserName = modelo.Email, Email = modelo.Email };
            //var resultado = await userManager.CreateAsync(usuario, modelo.Password);

            //if (resultado.Succeeded)
            //{
            //    return await ConstruirToken(modelo);
            //}
            //else
            //{
            //    // Enviar todos los errores de contraseña
            //    var errores = resultado.Errors.Select(e => e.Description).ToList();
            //    return BadRequest(errores);
            //}
            var resultado = await userManager.CreateAsync(usuario, modelo.Password);

            if (resultado.Succeeded)
            {
                // Asignar rol al usuario recién creado
                await userManager.AddToRoleAsync(usuario, "admin");

                return await ConstruirToken(modelo);
            }
            else
            {
                // Enviar todos los errores de contraseña
                var errores = resultado.Errors.Select(e => e.Description).ToList();
                return BadRequest(errores);

            }

            }

        //private async Task<UserTokenDTO> ConstruirToken(UserInfoDTO userInfoDTO)
        //{
        //    var claims = new List<Claim>()
        //    {
        //        new Claim(ClaimTypes.Email, userInfoDTO.Email)
        //        // Codigo para agregar claims custom: new new Claim("customClaim", "valorDelClaim")
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]!));
        //    var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var expiracion = DateTime.UtcNow.AddMonths(1);

        //    var token = new JwtSecurityToken(

        //        issuer: null,
        //        audience: null,
        //        claims: claims,
        //        expires: expiracion,
        //        signingCredentials: credenciales

        //        );

        //    return new UserTokenDTO()
        //    {
        //        Token = new JwtSecurityTokenHandler().WriteToken(token),
        //        Expiracion = expiracion
        //    };

        //}

        private async Task<UserTokenDTO> ConstruirToken(UserInfoDTO userInfoDTO)
        {
            var usuario = await userManager.FindByEmailAsync(userInfoDTO.Email);
            var claims = new List<Claim>()
    {
        new Claim(ClaimTypes.Email, userInfoDTO.Email)
    };

            var roles = await userManager.GetRolesAsync(usuario);
            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]!));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddMonths(1);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiracion,
                signingCredentials: credenciales
            );

            return new UserTokenDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracion = expiracion
            };
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserTokenDTO>> LogIn([FromBody] UserInfoDTO userInfoDTO)
        {
            var resultado = await signInManager.PasswordSignInAsync(userInfoDTO.Email, userInfoDTO.Password, isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return await ConstruirToken(userInfoDTO);
            }
            else
            {
                return BadRequest("LogIn Incorrecto");
            }

        }

    }

}


