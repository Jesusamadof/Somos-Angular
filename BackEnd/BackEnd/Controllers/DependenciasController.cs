using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependenciasController : ControllerBase
    {


        public readonly SomosdcContext _context;
        public DependenciasController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getDependecias()
        {
            try
            {
                var lista = _context.TblDependientes.Where(x => x.EstadoEliminacion == 0).ToList();
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
        public async Task<ActionResult> filtroDependencias(int id)
        {
            try
            {
                var lista = _context.TblDependientes.FirstOrDefault(x => x.IdDependiente == id);
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
        public async Task<ActionResult> agregarDependencia(TblDependiente datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                    var nuevoRegistro = new TblDependiente
                    {
                        TipoDependiente = datos.TipoDependiente,
                        FechaCreacion = DateTime.Now,
                        IdUsuarioCreo = datos.IdUsuarioCreo,
                        Estado = 1,
                        EstadoEliminacion = 0
                    };

                    _context.TblDependientes.Add(nuevoRegistro);
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
        public async Task<ActionResult> actualizarDependiente(TblDependiente datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifDependencia = _context.TblDependientes.FirstOrDefault(x => x.IdDependiente == id);
                if (verifDependencia != null)
                {
                    verifDependencia.TipoDependiente = datos.TipoDependiente;
                    verifDependencia.FechaModificacion = DateTime.Now;
                    verifDependencia.IdUsuarioModifico = datos.IdUsuarioModifico;

                    _context.TblDependientes.Update(verifDependencia);
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
        public async Task<ActionResult> actualizarEstado(TblDependiente datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifDependencia = _context.TblDependientes.FirstOrDefault(x => x.IdDependiente == id);
                if (verifDependencia != null)
                {
                    verifDependencia.Estado = datos.Estado;
                    verifDependencia.FechaModificacion = DateTime.Now;

                    _context.TblDependientes.Update(verifDependencia);
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
        public async Task<ActionResult> eliminar(TblDependiente datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifDependencia = _context.TblDependientes.FirstOrDefault(x => x.IdDependiente == id);
                if (verifDependencia != null)
                {
                    verifDependencia.EstadoEliminacion = datos.EstadoEliminacion;
                    verifDependencia.FechaModificacion = DateTime.Now;


                    _context.TblDependientes.Update(verifDependencia);
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
