using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtniaController : ControllerBase
    {


        public readonly SomosdcContext _context;
        public EtniaController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getEtnia()
        {
            try
            {
                var lista = _context.TblEtnia.Where(x => x.EstadoEliminacion == 0).ToList();
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
        public async Task<ActionResult> filtroEtnia(int id)
        {
            try
            {
                var lista = _context.TblEtnia.FirstOrDefault(x => x.IdEtnia == id);
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
        public async Task<ActionResult> agregarEtnia(TblEtnium datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                    var nuevoRegistro = new TblEtnium
                    {
                        NombreEtnia = datos.NombreEtnia,
                        FechaCreacion = DateTime.Now,
                        IdUsuarioCreo = datos.IdUsuarioCreo,
                        Estado = 1,
                        EstadoEliminacion = 0
                    };

                    _context.TblEtnia.Add(nuevoRegistro);
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
        public async Task<ActionResult> actualizarEtnia(TblEtnium datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifEtnia = _context.TblEtnia.FirstOrDefault(x => x.IdEtnia == id);
                if (verifEtnia != null)
                {
                    verifEtnia.NombreEtnia = datos.NombreEtnia;
                    verifEtnia.FechaModificacion = DateTime.Now;
                    verifEtnia.IdUsuarioModifico = datos.IdUsuarioModifico;

                    _context.TblEtnia.Update(verifEtnia);
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
        public async Task<ActionResult> actualizarEstado(TblEtnium datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifEtnia = _context.TblEtnia.FirstOrDefault(x => x.IdEtnia == id);
                if (verifEtnia != null)
                {
                    verifEtnia.Estado = datos.Estado;
                    verifEtnia.FechaModificacion = DateTime.Now;

                    _context.TblEtnia.Update(verifEtnia);
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
        public async Task<ActionResult> eliminar(TblEtnium datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifEtnia = _context.TblEtnia.FirstOrDefault(x => x.IdEtnia == id);
                if (verifEtnia != null)
                {
                    verifEtnia.EstadoEliminacion = datos.EstadoEliminacion;
                    verifEtnia.FechaModificacion = DateTime.Now;


                    _context.TblEtnia.Update(verifEtnia);
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
