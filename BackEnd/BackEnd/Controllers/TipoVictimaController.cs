using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVictimaController : ControllerBase
    {

        public readonly SomosdcContext _context;

        public TipoVictimaController
            (SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult> getTipoVictima()
        {
            try
            {
                var lista = _context.TblTipoVictimas.Where(x => x.EstadoEliminacion == 0).ToList();
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
                        mensaje = "no se encontraron registros"

                    });
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"se encontro el siguiente error: {ex}");
            }
        }


        [HttpGet("{id}")]

        public async Task<ActionResult> getfiltro(int id)
        {
            try
            {
                var lista = _context.TblTipoVictimas.FirstOrDefault(x => x.IdTipoVictima == id);
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
                        mensaje = "no se encontraron registros"

                    });
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"se encontro el siguiente error: {ex}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> postTipoVictima(TblTipoVictima datos)
        {
            using var transaccion = _context.Database.BeginTransaction();
            try
            {
                var nuevaTipoVictima = new TblTipoVictima
                {
                    TipoVictima = datos.TipoVictima,
                    IdUsuarioCreo = datos.IdUsuarioCreo,
                    //FechaCreacion = DateTime.Now,
                    Estado = 1,
                    EstadoEliminacion = 0
                };
                _context.TblTipoVictimas.Add(nuevaTipoVictima);
                _context.SaveChanges();
                transaccion.Commit();
                return Ok(new
                {
                    ok = true,
                    mensaje = "Registro agregado con exito"
                });

            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                return StatusCode(500, $"se encontro el siguiente error: {ex}");

            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> actualizarTipoVictima(TblTipoVictima tipo_victima, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarTipoVictima = _context.TblTipoVictimas.FirstOrDefault(x => x.IdTipoVictima == id);
                if (verificarTipoVictima != null)
                {
                    verificarTipoVictima.TipoVictima = tipo_victima.TipoVictima;
                    verificarTipoVictima.IdUsuarioModifico = tipo_victima.IdUsuarioModifico;
                    verificarTipoVictima.FechaModificacion = DateTime.Now;

                    _context.TblTipoVictimas.Update(verificarTipoVictima);
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
        public async Task<ActionResult> actualizarEstado(TblTipoVictima tipo_victima, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarTipoVictima = _context.TblTipoVictimas.FirstOrDefault(x => x.IdTipoVictima == id);
                if (verificarTipoVictima != null)
                {
                    verificarTipoVictima.Estado = tipo_victima.Estado;

                    _context.TblTipoVictimas.Update(verificarTipoVictima);
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
        public async Task<ActionResult> Eliminar(TblTipoVictima tipo_victima, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarTipoVictima = _context.TblTipoVictimas.FirstOrDefault(x => x.IdTipoVictima == id);
                if (verificarTipoVictima != null)
                {
                    verificarTipoVictima.EstadoEliminacion = tipo_victima.EstadoEliminacion;

                    _context.TblTipoVictimas.Update(verificarTipoVictima);
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
    }
}
