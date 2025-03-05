using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondicionMigratoriaController : ControllerBase
    {


        public readonly SomosdcContext _context;
        public CondicionMigratoriaController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getCondiciones()
        {
            try
            {
                var lista = _context.TblCondicionMigratoria.Where(x => x.EstadoEliminacion == 0).ToList();
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
        public async Task<ActionResult> filtroCondicion(int id)
        {
            try
            {
                var lista = _context.TblCondicionMigratoria.FirstOrDefault(x => x.IdCondicionMigratoria == id);
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
        public async Task<ActionResult> agregarCondicion(TblCondicionMigratorium datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                    var nuevoRegistro = new TblCondicionMigratorium
                    {
                        NombreCondicion = datos.NombreCondicion,
                        FechaCreacion=DateTime.Now,
                        IdUsuarioCreo=datos.IdUsuarioCreo,
                        Estado = 1,
                        EstadoEliminacion = 0
                    };

                    _context.TblCondicionMigratoria.Add(nuevoRegistro);
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
        public async Task<ActionResult> actualizarCondicion(TblCondicionMigratorium datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifCondicion = _context.TblCondicionMigratoria.FirstOrDefault(x => x.IdCondicionMigratoria == id);
                if (verifCondicion != null)
                {
                    verifCondicion.NombreCondicion = datos.NombreCondicion;
                    verifCondicion.FechaModificacion = DateTime.Now;
                    verifCondicion.IdUsuarioModifico = datos.IdUsuarioModifico;

                    _context.TblCondicionMigratoria.Update(verifCondicion);
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
        public async Task<ActionResult> actualizarEstado(TblCondicionMigratorium datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifCondicion = _context.TblCondicionMigratoria.FirstOrDefault(x => x.IdCondicionMigratoria == id);
                if (verifCondicion != null)
                {
                    verifCondicion.Estado = datos.Estado;
                    verifCondicion.FechaModificacion = DateTime.Now;

                    _context.TblCondicionMigratoria.Update(verifCondicion);
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
        public async Task<ActionResult> eliminar(TblCondicionMigratorium datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifCondicion = _context.TblCondicionMigratoria.FirstOrDefault(x => x.IdCondicionMigratoria == id);
                if (verifCondicion != null)
                {
                    verifCondicion.EstadoEliminacion = datos.EstadoEliminacion;
                    verifCondicion.FechaModificacion = DateTime.Now;


                    _context.TblCondicionMigratoria.Update(verifCondicion);
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
