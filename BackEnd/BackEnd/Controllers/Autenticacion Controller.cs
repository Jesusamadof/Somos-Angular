using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Autenticacion_Controller : ControllerBase
    {
        public readonly SomosdcContext _context;
        public readonly IConfiguration _config;
        public Autenticacion_Controller(SomosdcContext Context, IConfiguration config)
        {
            _context = Context;
            _config = config;
        }

        [HttpPost]
        public async Task<ActionResult> login(Login credenciales)
        {

            try
            {
                var autenticacion = autenticar(credenciales);
                if (autenticacion != null)
                {
                    string token = generarToken(autenticacion);
                    if (token != null)
                    {
                        var preguntas = _context.TblPreguntaUsuarios.Where(x => x.IdUsuario == autenticacion.IdUsuario).ToList();

                        _context.TblBitacoras.Add(new TblBitacora
                        {
                            IdUsuario = autenticacion.IdUsuario,
                            Valor = "Inicio de sesión de: " + credenciales.usuario,
                            Evento = "Inicio de Sesión",
                            Fecha = DateTime.Now

                        });
                        _context.SaveChanges();
                        return Ok(new
                        {
                            ok = true,
                            lista=autenticacion,
                            token = token,
                            preguntas = preguntas,
                            cambioContrasena = autenticacion.CambioContrasena,
                            contrasenaSegura = autenticacion.ContrasenaSegura,
                            mensaje = "Sesion iniciada exitosamente !!"
                        }) ;


                    }
                    else
                    {
                        return Ok(new
                        {
                            ok = false,
                            mensaje = "Hubo problema al generar el token !!"
                        });

                    }


                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje = "Usuario o Contraseňa Incorrecta"

                    });
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Se encontro el sigueinte mensaje en el servidor: {ex}");
            }
        }

        private VUsuarioLogin autenticar(Login credenciales)
        {
            var verificar = _context.VUsuarioLogins.FirstOrDefault(x => x.Usuario == credenciales.usuario);
            if (verificar != null)
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(credenciales.contrasena, verificar.Contrasena);
                if (isPasswordValid)
                {
                    return verificar;
                }
                else
                {
                   return null;
                }
               
            }
            else
            {
                return null;
            }

        }

        private string generarToken(VUsuarioLogin usuario)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // Crear Clains(Reclamaciones)

            var claims = new[]
            {
                new Claim("idUsuario",usuario.IdUsuario.ToString()),
                new Claim("usuario", usuario.Usuario),
                new Claim("idRol",usuario.IdRol.ToString())
                };
            // Crear Token

            var token = new JwtSecurityToken(
                             _config["jwt:Issuer"],
                             _config["jwt:Audience"],
                             claims,
                             expires: DateTime.Now.AddMinutes(10),
                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }


}
