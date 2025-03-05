using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        public readonly SomosdcContext _context;
        public UsuariosController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getUsuarios()
        {
            try
            {
                var lista = _context.VUsuarioRols.Where(x => x.EstadoEliminacion == 0).ToList();
                if (lista.Count > 0)
                {
                    return Ok(new
                    {
                        ok = true,
                        lista = lista
                    });
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje = "No se encontraron datos"
                    });
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se encontro el siguiente error {ex}");

            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> filtroUsuario(int id)
        {
            try
            {
                var lista = _context.TblUsuarios.FirstOrDefault(x => x.IdUsuario == id);
                if (lista != null)
                {
                    return Ok(new
                    {
                        ok = true,
                        lista = lista
                    });
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje = "No se encontraron datos"
                    });
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se encontro el siguiente error {ex}");

            }
        }

        [HttpPost]
        public async Task<ActionResult> agregarUsuario(TblUsuario datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                    string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                    var contrasena = BCrypt.Net.BCrypt.HashPassword("1234", salt);
                    var nuevausuario = new TblUsuario
                    {
                        IdRol = datos.IdRol,
                        Usuario = datos.Usuario,
                        Nombre = datos.Nombre,
                        Correo = datos.Correo,
                        ContrasenaSegura = 0,
                        Contrasena = contrasena,
                        CambioContrasena = 1,
                        Estado = 1,
                        EstadoEliminacion = 0
                    };

                    _context.TblUsuarios.Add(nuevausuario);
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return Ok(new
                    {
                        ok = true,
                        mensaje = "Registro Agregado exitosamente!!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje = "Falta Datos!!"
                    });

                }



            }
            catch (Exception ex)
            {
                transaction.RollbackAsync();

                return StatusCode(500, $"Se encontro el siguiente error {ex}");
            }
        }

        [HttpPost("agregarPreguntas")]
        public async Task<ActionResult> agregarPreguntasUsuario(TblUsuario datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {

                    foreach (var item in datos.TblPreguntaUsuarios)
                    {
                        item.FechaCreacion = DateTime.Now;

                        _context.TblPreguntaUsuarios.Add(item);

                    }

                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return Ok(new
                    {
                        ok = true,
                        mensaje = "Registro Agregado exitosamente!!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje = "Falta Datos!!"
                    });

                }



            }
            catch (Exception ex)
            {
                transaction.RollbackAsync();

                return StatusCode(500, $"Se encontro el siguiente error {ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> actualizarUsuarios(TblUsuario datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifUsuario = _context.TblUsuarios.FirstOrDefault(x => x.IdUsuario == id);

                if (verifUsuario != null)
                {

                    verifUsuario.Usuario = datos.Usuario;
                    verifUsuario.Correo = datos.Correo;
                    verifUsuario.Nombre = datos.Nombre;
                    verifUsuario.IdRol = datos.IdRol;
                    _context.TblUsuarios.Update(verifUsuario);
                    _context.SaveChanges();
                    transaction.Commit();
                    return Ok(new
                    {
                        ok = true,
                        mensaje = "Registro Actualizado exitosamente!!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje = "No se encontraron datos !!"
                    });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Se encontro el siguiente error {ex}");
            }

        }

        [HttpPut("actualizarEstado/{id}")]
        public async Task<ActionResult> actualizarEstado(TblUsuario datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifUsuario = _context.TblUsuarios.FirstOrDefault(x => x.IdUsuario == id);
                if (verifUsuario != null)
                {
                    verifUsuario.Estado = datos.Estado;

                    _context.TblUsuarios.Update(verifUsuario);
                    _context.SaveChanges();
                    transaction.Commit();
                    return Ok(new
                    {
                        ok = true,
                        mensaje = "Registro Actualizado exitosamente!!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje = "No se encontraron datos !!"
                    });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Se encontro el siguiente error {ex}");
            }

        }

        [HttpPut("actualizarEstadoEliminacion/{id}")]
        public async Task<ActionResult> eliminar(TblUsuario datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifUsuario = _context.TblUsuarios.FirstOrDefault(x => x.IdUsuario == id);
                if (verifUsuario != null)
                {
                    verifUsuario.EstadoEliminacion = datos.EstadoEliminacion;

                    _context.TblUsuarios.Update(verifUsuario);
                    _context.SaveChanges();
                    transaction.Commit();
                    return Ok(new
                    {
                        ok = true,
                        mensaje = "Registro Actualizado exitosamente!!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje = "No se encontraron datos !!"
                    });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Se encontro el siguiente error {ex}");
            }

        }

        [HttpPut("cambiarContrasena/{id}")]
        public async Task<ActionResult> cambiarContrasena(TblUsuario cambContrasena, int id)
        {
            using var trasaction = _context.Database.BeginTransaction();
            try
            {
                if (cambContrasena == null)
                {
                    return Ok(
                        new
                        {
                            ok = false,
                            mensaje = "Faltan datos para efectuar la actualización"
                        }
                        );
                }
                else
                {

                    string salt = BCrypt.Net.BCrypt.GenerateSalt(12);

                    TblUsuario verificarUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);
                    if (verificarUsuario != null)
                    {

                        verificarUsuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(cambContrasena.Contrasena, salt); ;
                        verificarUsuario.ContrasenaSegura = 1;
                        verificarUsuario.CambioContrasena = 0;
                        _context.TblUsuarios.Update(verificarUsuario);
                        await _context.SaveChangesAsync();
                        await trasaction.CommitAsync();
                        return Ok(
                        new
                        {
                            ok = true,
                            mensaje = "Datos Actualizados Correctamente"
                        }
                        );
                    }
                    else
                    {
                        return Ok(
                        new
                        {
                            ok = false,
                            mensaje = "No se encontro el registro"
                        }
                        );

                    }

                }

            }
            catch (Exception ex)
            {
                await trasaction.RollbackAsync();
                return StatusCode(500, new
                {
                    StatusCode = 500,
                    mensaje = $"Se encontro el siguiente error en el servidor : {ex}"
                });
            }

        }

    }
}
