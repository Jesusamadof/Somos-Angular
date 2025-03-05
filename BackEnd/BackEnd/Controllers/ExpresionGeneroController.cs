using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpresionGeneroController : ControllerBase
    {


        public readonly SomosdcContext _context;
        public ExpresionGeneroController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getExpresionGenero()
        {
            try
            {
                var lista = _context.TblExpresionGeneros.Where(x => x.EstadoEliminacion == 0).ToList();
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
        public async Task<ActionResult> filtroExpresionGeneros(int id)
        {
            try
            {
                var lista = _context.TblExpresionGeneros.FirstOrDefault(x => x.IdExpresionGenero == id);
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
        public async Task<ActionResult> agregarExpresionGenero(TblExpresionGenero datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                    var nuevoRegistro = new TblExpresionGenero
                    {
                        NombreExpresion = datos.NombreExpresion,
                        FechaCreacion = DateTime.Now,
                        IdUsuarioCreo = datos.IdUsuarioCreo,
                        Estado = 1,
                        EstadoEliminacion = 0
                    };

                    _context.TblExpresionGeneros.Add(nuevoRegistro);
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
        public async Task<ActionResult> actualizarExpresionGenero(TblExpresionGenero datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifExpresionGenero = _context.TblExpresionGeneros.FirstOrDefault(x => x.IdExpresionGenero == id);
                if (verifExpresionGenero != null)
                {
                    verifExpresionGenero.NombreExpresion = datos.NombreExpresion;
                    verifExpresionGenero.FechaModificacion = DateTime.Now;
                    verifExpresionGenero.IdUsuarioModifico = datos.IdUsuarioModifico;

                    _context.TblExpresionGeneros.Update(verifExpresionGenero);
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
        public async Task<ActionResult> actualizarEstado(TblExpresionGenero datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifExpresionGenero = _context.TblExpresionGeneros.FirstOrDefault(x => x.IdExpresionGenero == id);
                if (verifExpresionGenero != null)
                {
                    verifExpresionGenero.Estado = datos.Estado;
                    verifExpresionGenero.FechaModificacion = DateTime.Now;

                    _context.TblExpresionGeneros.Update(verifExpresionGenero);
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
        public async Task<ActionResult> eliminar(TblExpresionGenero datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifExpresionGen = _context.TblExpresionGeneros.FirstOrDefault(x => x.IdExpresionGenero == id);
                if (verifExpresionGen != null)
                {
                    verifExpresionGen.EstadoEliminacion = datos.EstadoEliminacion;
                    verifExpresionGen.FechaModificacion = DateTime.Now;


                    _context.TblExpresionGeneros.Update(verifExpresionGen);
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
