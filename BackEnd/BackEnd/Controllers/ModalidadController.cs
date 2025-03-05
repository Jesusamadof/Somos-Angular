using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadController : ControllerBase
    {

        public readonly SomosdcContext _context;

        public ModalidadController
            (SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult> getModalidad()
        {
            try
            {
                var lista = _context.TblModalidads.Where(x => x.EstadoEliminacion == 0).ToList();
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
                var lista = _context.TblModalidads.FirstOrDefault(x => x.IdModalidad == id);
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
        public async Task<ActionResult> postModalidad(TblModalidad datos)
        {
            using var transaccion = _context.Database.BeginTransaction();
            try
            {
                var nuevaModalidad = new TblModalidad
                {
                    Modalidad = datos.Modalidad,
                    IdUsuarioCreo = datos.IdUsuarioCreo,
                    FechaCreacion = DateTime.Now,
                    Estado = 1,
                    EstadoEliminacion = 0
                };
                _context.TblModalidads.Add(nuevaModalidad);
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
        public async Task<ActionResult> actualizarModalidad(TblModalidad Modalidad_, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarModalidad = _context.TblModalidads.FirstOrDefault(x => x.IdModalidad == id);
                if (verificarModalidad != null)
                {
                    verificarModalidad.Modalidad = Modalidad_.Modalidad;
                    verificarModalidad.IdUsuarioModifico = Modalidad_.IdUsuarioModifico;
                    verificarModalidad.FechaModificacion = DateTime.Now;

                    _context.TblModalidads.Update(verificarModalidad);
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
        public async Task<ActionResult> actualizarEstado(TblTipoVictima Modalidad_, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarModalidad = _context.TblModalidads.FirstOrDefault(x => x.IdModalidad == id);
                if (verificarModalidad != null)
                {
                    verificarModalidad.Estado = Modalidad_.Estado;

                    _context.TblModalidads.Update(verificarModalidad);
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
        public async Task<ActionResult> Eliminar(TblTipoVictima Modalidad_, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarModalidad = _context.TblModalidads.FirstOrDefault(x => x.IdModalidad == id);
                if (verificarModalidad != null)
                {
                    verificarModalidad.EstadoEliminacion = Modalidad_.EstadoEliminacion;

                    _context.TblModalidads.Update(verificarModalidad);
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
