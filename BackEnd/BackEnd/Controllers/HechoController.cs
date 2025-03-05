using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HechoController : ControllerBase
    {

        public readonly SomosdcContext _context;

        public HechoController
            (SomosdcContext context)
        {
            _context = context;
        }

        /*  ==========================Proceso #1 ================================== */
        [HttpGet]
        public async Task<ActionResult> getHecho()
        {
            try
            {
                var lista = await _context.TblHechoes.ToListAsync();
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

        /*  ==========================Proceso #2 ================================== */
        [HttpGet("{id}")]
        public async Task<ActionResult> getfiltro(int id)
        {
            try
            {
                var lista = await _context.TblHechoes.FirstOrDefaultAsync(x => x.IdHecho == id);
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

        /*  ==========================Proceso #3 ================================== */
        [HttpPost]
        public async Task<ActionResult> postHecho(TblHecho datos)
        {
            using var transaccion = _context.Database.BeginTransaction();
            try
            {
                var nuevaHecho = new TblHecho
                {
                    IdCaso = datos.IdCaso,
                    IdGeneradorHecho = datos.IdGeneradorHecho,
                    FechaHecho = datos.FechaHecho,
                    HoraHecho = datos.HoraHecho,
                    LugarHecho = datos.LugarHecho,
                    IdGeneroVictima = datos.IdGeneroVictima,
                    IdTipoVictima = datos.IdTipoVictima,
                    IdTipoRelacion = datos.IdTipoRelacion,
                    IdModalidad = datos.IdModalidad,
                    IdDetallesSobreRelacion = datos.IdDetallesSobreRelacion,
                    AgresionSexual = datos.AgresionSexual,
                    DenunciaPrevia = datos.DenunciaPrevia,
                    ProcesoJudicial = datos.ProcesoJudicial,
                    IdUsuarioCreo = datos.IdUsuarioCreo,
                    Estado = 1,
                    EstadoEliminacion = 0
                };

                _context.TblHechoes.Add(nuevaHecho);
                await _context.SaveChangesAsync();
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


        /*  ==========================Proceso #4 ================================== */

        [HttpPut("{id}")]
        public async Task<ActionResult> actualizarHecho(TblHecho hecho, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarHecho = await _context.TblHechoes.FirstOrDefaultAsync(x => x.IdHecho == id);
                if (verificarHecho != null)
                {
                    verificarHecho.IdCaso = hecho.IdCaso;
                    verificarHecho.IdGeneradorHecho = hecho.IdGeneradorHecho;
                    verificarHecho.FechaHecho = hecho.FechaHecho;
                    verificarHecho.HoraHecho = hecho.HoraHecho;
                    verificarHecho.LugarHecho = hecho.LugarHecho;
                    verificarHecho.IdGeneroVictima = hecho.IdGeneroVictima;
                    verificarHecho.IdTipoVictima = hecho.IdTipoVictima;
                    verificarHecho.IdTipoRelacion = hecho.IdTipoRelacion;
                    verificarHecho.IdModalidad = hecho.IdModalidad;
                    verificarHecho.IdDetallesSobreRelacion = hecho.IdDetallesSobreRelacion;
                    verificarHecho.AgresionSexual = hecho.AgresionSexual;
                    verificarHecho.DenunciaPrevia = hecho.DenunciaPrevia;
                    verificarHecho.ProcesoJudicial = hecho.ProcesoJudicial;
                    verificarHecho.IdUsuarioCreo = hecho.IdUsuarioCreo;

                    _context.TblHechoes.Update(verificarHecho);
                    await _context.SaveChangesAsync();
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

        /*  ==========================Proceso #5 ================================== */
        [HttpPut("actualizarEstado/{id}")]
        public async Task<ActionResult> actualizarEstado(TblHecho hecho, int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var verificarHecho = await _context.TblHechoes.FirstOrDefaultAsync(x => x.IdHecho == id);
                if (verificarHecho != null)
                {
                    verificarHecho.Estado = hecho.Estado;

                    _context.TblHechoes.Update(verificarHecho);
                    await _context.SaveChangesAsync();
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


        /*  ==========================Proceso #6 ================================== */
        [HttpPut("actualizarEstadoEliminacion/{id}")]
        public async Task<ActionResult> Eliminar(TblHecho hecho, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarHecho = await _context.TblHechoes.FirstOrDefaultAsync(x => x.IdHecho == id);
                if (verificarHecho != null)
                {
                    verificarHecho.EstadoEliminacion = hecho.EstadoEliminacion;

                    _context.TblHechoes.Update(verificarHecho);
                    await _context.SaveChangesAsync();
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
