using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoRelacionController : ControllerBase
    {
      
            public readonly SomosdcContext _context;


            public TipoRelacionController
                   (SomosdcContext context)
            {
                _context = context;
            }

            [HttpGet]

            public async Task<ActionResult> getTipoRelacion()
            {
                try
                {
                    var lista = _context.TblTipoRelacions.Where(x => x.EstadoEliminacion == 0).ToList();
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
                    var lista = _context.TblTipoRelacions.FirstOrDefault(x => x.IdTipoRelacion == id);
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
            public async Task<ActionResult> postTipoRelacion(TblTipoRelacion datos)
            {
                using var transaccion = _context.Database.BeginTransaction();
                try
                {
                    var nuevaTipoRelacion = new TblTipoRelacion
                    {
                        TipoRelacion = datos.TipoRelacion,
                        IdUsuarioCreo = datos.IdUsuarioCreo,
                        FechaCreacion = DateTime.Now,
                        Estado = 1,
                        EstadoEliminacion = 0
                    };
                    _context.TblTipoRelacions.Add(nuevaTipoRelacion);
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
            public async Task<ActionResult> actualizarTipoRelacion(TblTipoRelacion tipo_Relacion, int id)
            {
                using var transaction = _context.Database.BeginTransaction();

                try
                {
                    var verificarTipoRelacion = _context.TblTipoRelacions.FirstOrDefault(x => x.IdTipoRelacion == id);
                    if (verificarTipoRelacion != null)
                    {
                        verificarTipoRelacion.TipoRelacion = tipo_Relacion.TipoRelacion;
                        verificarTipoRelacion.IdUsuarioModifico = tipo_Relacion.IdUsuarioModifico;
                        verificarTipoRelacion.FechaModificacion = DateTime.Now;

                        _context.TblTipoRelacions.Update(verificarTipoRelacion);
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
            public async Task<ActionResult> actualizarEstado(TblTipoRelacion tipo_Relacion, int id)
            {
                using var transaction = _context.Database.BeginTransaction();

                try
                {
                    var verificarTipoRelacion = _context.TblTipoRelacions.FirstOrDefault(x => x.IdTipoRelacion == id);
                    if (verificarTipoRelacion != null)
                    {
                        verificarTipoRelacion.Estado = tipo_Relacion.Estado;

                        _context.TblTipoRelacions.Update(verificarTipoRelacion);
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
            public async Task<ActionResult> Eliminar(TblTipoRelacion tipo_Relacion, int id)
            {
                using var transaction = _context.Database.BeginTransaction();

                try
                {
                    var verificarTipoRelacion = _context.TblTipoRelacions.FirstOrDefault(x => x.IdTipoRelacion == id);
                    if (verificarTipoRelacion != null)
                    {
                        verificarTipoRelacion.EstadoEliminacion = tipo_Relacion.EstadoEliminacion;

                        _context.TblTipoRelacions.Update(verificarTipoRelacion);
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

