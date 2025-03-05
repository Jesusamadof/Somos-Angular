using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrientacionSexualController : ControllerBase
    {

        public readonly SomosdcContext _context;

        public OrientacionSexualController
            (SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult> getOrientacionSexual()
        {
            try
            {
                var lista = _context.TblOrientacionSexuals.ToList();
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
                var lista = _context.TblOrientacionSexuals.FirstOrDefault(x => x.IdOrientacion == id);
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
        public async Task<ActionResult> postOrientacion(TblOrientacionSexual datos)
        {
            using var transaccion = _context.Database.BeginTransaction();
            try
            {
                var nuevaOrientacion = new TblOrientacionSexual
                {
                    Orientacion = datos.Orientacion,
                    Estado = 1,
                    EstadoEliminacion = 0
                };
                _context.TblOrientacionSexuals.Add(nuevaOrientacion);
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
        public async Task<ActionResult> actualizarOrientacion(TblOrientacionSexual orientacionSexual, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarOrientacion = _context.TblOrientacionSexuals.FirstOrDefault(x => x.IdOrientacion == id);
                if (verificarOrientacion != null)
                {
                    verificarOrientacion.Orientacion = orientacionSexual.Orientacion;

                    _context.TblOrientacionSexuals.Update(verificarOrientacion);
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
        public async Task<ActionResult> actualizarEstado(TblOrientacionSexual orientacionSexual, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarOrientacion = _context.TblOrientacionSexuals.FirstOrDefault(x => x.IdOrientacion == id);
                if (verificarOrientacion != null)
                {
                    verificarOrientacion.Estado = orientacionSexual.Estado;

                    _context.TblOrientacionSexuals.Update(verificarOrientacion);
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
        public async Task<ActionResult> Eliminar(TblOrientacionSexual orientacionSexual, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarOrientacion = _context.TblOrientacionSexuals.FirstOrDefault(x => x.IdOrientacion == id);
                if (verificarOrientacion != null)
                {
                    verificarOrientacion.EstadoEliminacion = orientacionSexual.EstadoEliminacion;

                    _context.TblOrientacionSexuals.Update(verificarOrientacion);
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
