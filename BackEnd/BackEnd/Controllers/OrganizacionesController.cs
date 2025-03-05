using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizacionesController : ControllerBase
    {


        public readonly SomosdcContext _context;
        public OrganizacionesController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getOrganizaciones()
        {
            try
            {
                var lista = _context.TblOrganizacions.Where(x => x.EstadoEliminacion == 0).ToList();
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
        public async Task<ActionResult> filtroOrganizacion(int id)
        {
            try
            {
                var lista = _context.TblOrganizacions.FirstOrDefault(x => x.IdOrganizacion == id);
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
        public async Task<ActionResult> agregarOrganizaciones(TblOrganizacion datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                    var nuevoRegistro = new TblOrganizacion
                    {
                        NombreOrganizacion = datos.NombreOrganizacion,
                        FechaCreacion = DateTime.Now,
                        IdUsuarioCreo = datos.IdUsuarioCreo,
                        Estado = 1,
                        EstadoEliminacion = 0
                    };

                    _context.TblOrganizacions.Add(nuevoRegistro);
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
        public async Task<ActionResult> actualizarOrganiciones(TblOrganizacion datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifOrganizacion = _context.TblOrganizacions.FirstOrDefault(x => x.IdOrganizacion == id);
                if (verifOrganizacion != null)
                {
                    verifOrganizacion.NombreOrganizacion = datos.NombreOrganizacion;
                    verifOrganizacion.FechaModificacion = DateTime.Now;
                    verifOrganizacion.IdUsuarioModifico = datos.IdUsuarioModifico;

                    _context.TblOrganizacions.Update(verifOrganizacion);
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
        public async Task<ActionResult> actualizarEstado(TblOrganizacion datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifOrganizacion = _context.TblOrganizacions.FirstOrDefault(x => x.IdOrganizacion == id);
                if (verifOrganizacion != null)
                {
                    verifOrganizacion.Estado = datos.Estado;
                    verifOrganizacion.FechaModificacion = DateTime.Now;

                    _context.TblOrganizacions.Update(verifOrganizacion);
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
        public async Task<ActionResult> eliminar(TblOrganizacion datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifOrganizacion = _context.TblOrganizacions.FirstOrDefault(x => x.IdOrganizacion == id);
                if (verifOrganizacion != null)
                {
                    verifOrganizacion.EstadoEliminacion = datos.EstadoEliminacion;
                    verifOrganizacion.FechaModificacion = DateTime.Now;


                    _context.TblOrganizacions.Update(verifOrganizacion);
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
