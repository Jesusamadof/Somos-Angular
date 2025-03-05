using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        public readonly SomosdcContext _context;
        public RolesController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getRoles()
        {
            try
            {
                var lista = _context.TblRols.Where(x=>x.EstadoEliminacion==0).ToList();
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
        public async Task<ActionResult> filtroRol( int id)
        {
            try
            {
                var lista = _context.TblRols.FirstOrDefault(x=>x.IdRol==id);
                if (lista !=null)
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
        public async Task<ActionResult> agregarRol( TblRol rol)
        {
            using var transaction=_context.Database.BeginTransaction();
            try
            {
                if(rol != null)
                {
                    var nuevoRol = new TblRol
                    {
                        NombreRol=rol.NombreRol,
                        Descripcion=rol.Descripcion,
                        Estado=1,
                        EstadoEliminacion=0
                    };

                     _context.TblRols.Add(nuevoRol);
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return Ok(new
                    {
                        ok=true,
                        mensaje="Registro Agregado exitosamente!!"
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
        public async Task<ActionResult> actualizarRol(TblRol rol, int id)
        {
            using var transaction=_context.Database.BeginTransaction();

            try
            {
                var verificarRol = _context.TblRols.FirstOrDefault(x => x.IdRol == id);
                if(verificarRol != null)
                {
                    verificarRol.NombreRol=rol.NombreRol;
                    verificarRol.Descripcion=rol.Descripcion;

                    _context.TblRols.Update(verificarRol);
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
        public async Task<ActionResult> actualizarEstado(TblRol rol, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarRol = _context.TblRols.FirstOrDefault(x => x.IdRol == id);
                if (verificarRol != null)
                {
                    verificarRol.Estado = rol.Estado;

                    _context.TblRols.Update(verificarRol);
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
        public async Task<ActionResult> eliminar(TblRol rol, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarRol = _context.TblRols.FirstOrDefault(x => x.IdRol == id);
                if (verificarRol != null)
                {
                    verificarRol.EstadoEliminacion = rol.EstadoEliminacion;

                    _context.TblRols.Update(verificarRol);
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
