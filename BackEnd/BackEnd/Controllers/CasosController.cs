using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasosController : ControllerBase
    {

        public readonly SomosdcContext _context;
        public CasosController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getCasos()
        {
            try
            {
                var lista = _context.VCasos.Where(x => x.EstadoEliminacion == 0).ToList();
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
        public async Task<ActionResult> filtroCaso(int id)
        {
            try
            {
                var lista = _context.TblCasos.FirstOrDefault(x => x.IdCaso == id);
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
        public async Task<ActionResult> agregarCaso(TblCaso datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                    var nuevoRegistro = new TblCaso
                    {
                        Fecha = datos.Fecha,
                        Hora = datos.Hora,
                        Lugar = datos.Lugar,
                        NombreGenero = datos.NombreGenero,
                        Alias = datos.Alias,
                        Dni = datos.Dni,
                        OtroNombre = datos.OtroNombre,
                        IdOrientacion = datos.IdOrientacion,
                        FechaCreacion = DateTime.Now,
                        IdUsuarioCreo = datos.IdUsuarioCreo,
                        Estado = 1,
                        EstadoEliminacion = 0
                    };

                    _context.TblCasos.Add(nuevoRegistro);
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
        public async Task<ActionResult> actualizarCaso(TblCaso datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifCaso = _context.TblCasos.FirstOrDefault(x => x.IdCaso == id);
                if (verifCaso != null)
                {
                   verifCaso.Fecha= datos.Fecha;
                    verifCaso.Hora= datos.Hora;
                    verifCaso.Lugar= datos.Lugar;
                    verifCaso.NombreGenero= datos.NombreGenero;
                    verifCaso.Alias= datos.Alias;
                    verifCaso.Dni= datos.Dni;
                    verifCaso.OtroNombre= datos.OtroNombre;
                    verifCaso.IdOrientacion= datos.IdOrientacion;
                    verifCaso.FechaModificacion = DateTime.Now;
                    verifCaso.IdUsuarioModifico = datos.IdUsuarioModifico;

                    _context.TblCasos.Update(verifCaso);
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
        public async Task<ActionResult> actualizarEstado(TblCaso datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifCaso = _context.TblCasos.FirstOrDefault(x => x.IdCaso == id);
                if (verifCaso != null)
                {
                    verifCaso.Estado = datos.Estado;
                    verifCaso.FechaModificacion = DateTime.Now;

                    _context.TblCasos.Update(verifCaso);
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
        public async Task<ActionResult> eliminar(TblCaso datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifCaso = _context.TblCasos.FirstOrDefault(x => x.IdCaso == id);
                if (verifCaso != null)
                {
                    verifCaso.EstadoEliminacion = datos.EstadoEliminacion;
                    verifCaso.FechaModificacion = DateTime.Now;


                    _context.TblCasos.Update(verifCaso);
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
