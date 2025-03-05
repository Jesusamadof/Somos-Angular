using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroVictimaController : ControllerBase
    {


        public readonly SomosdcContext _context;
        public GeneroVictimaController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getGenerosVictimas()
        {
            try
            {
                var lista = _context.TblGeneroVictimas.Where(x => x.EstadoEliminacion == 0).ToList();
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
        public async Task<ActionResult> filtroGenVictimas(int id)
        {
            try
            {
                var lista = _context.TblGeneroVictimas.FirstOrDefault(x => x.IdGeneroVictima == id);
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
        public async Task<ActionResult> agregarGenVictima(TblGeneroVictima datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                    var nuevoRegistro = new TblGeneroVictima
                    {
                        TipoGeneroVictima = datos.TipoGeneroVictima,
                        FechaCreacion = DateTime.Now,
                        IdUsuarioCreo = datos.IdUsuarioCreo,
                        Estado = 1,
                        EstadoEliminacion = 0
                    };

                    _context.TblGeneroVictimas.Add(nuevoRegistro);
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
        public async Task<ActionResult> actualizarGenVictima(TblGeneroVictima datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifGenVictima = _context.TblGeneroVictimas.FirstOrDefault(x => x.IdGeneroVictima == id);
                if (verifGenVictima != null)
                {
                    verifGenVictima.TipoGeneroVictima = datos.TipoGeneroVictima;
                    verifGenVictima.FechaModificacion = DateTime.Now;
                    verifGenVictima.IdUsuarioModifico = datos.IdUsuarioModifico;

                    _context.TblGeneroVictimas.Update(verifGenVictima);
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
        public async Task<ActionResult> actualizarEstado(TblGeneroVictima datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifGenVictima = _context.TblGeneroVictimas.FirstOrDefault(x => x.IdGeneroVictima == id);
                if (verifGenVictima != null)
                {
                    verifGenVictima.Estado = datos.Estado;
                    verifGenVictima.FechaModificacion = DateTime.Now;

                    _context.TblGeneroVictimas.Update(verifGenVictima);
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
        public async Task<ActionResult> eliminar(TblGeneroVictima datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifGenHecho = _context.TblGeneroVictimas.FirstOrDefault(x => x.IdGeneroVictima == id);
                if (verifGenHecho != null)
                {
                    verifGenHecho.EstadoEliminacion = datos.EstadoEliminacion;
                    verifGenHecho.FechaModificacion = DateTime.Now;


                    _context.TblGeneroVictimas.Update(verifGenHecho);
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
