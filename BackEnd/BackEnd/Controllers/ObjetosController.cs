using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetosController : ControllerBase
    {
        public readonly SomosdcContext _context;
        public ObjetosController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getObjetos()
        {
            try
            {
                var lista = _context.TblObjetos.Where(x => x.EstadoEliminacion == 0).ToList();
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
        public async Task<ActionResult> filtroObjeto(int id)
        {
            try
            {
                var lista = _context.TblObjetos.FirstOrDefault(x => x.IdObjeto == id);
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
        public async Task<ActionResult> agregarObjeto(TblObjeto objeto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (objeto != null)
                {
                    var nuevoObjeto = new TblObjeto
                    {
                        IdObjetoPadre = objeto.IdObjetoPadre,
                        NombreObjeto=objeto.NombreObjeto,
                        Ruta=objeto.Ruta,
                        Icono=objeto.Icono,
                        Estado = 1,
                        EstadoEliminacion = 0
                    };

                    _context.TblObjetos.Add(nuevoObjeto);
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
        public async Task<ActionResult> actualizarObjeto(TblObjeto objeto, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarObjeto = _context.TblObjetos.FirstOrDefault(x => x.IdObjeto == id);
                if (verificarObjeto != null)
                {
                    verificarObjeto.IdObjetoPadre=objeto.IdObjetoPadre;
                    verificarObjeto.NombreObjeto=objeto.NombreObjeto;
                    verificarObjeto.Ruta=objeto.Ruta;
                    verificarObjeto.Icono=objeto.Icono;

                    _context.TblObjetos.Update(verificarObjeto);
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
        public async Task<ActionResult> actualizarEstado(TblObjeto rol, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarObjeto = _context.TblObjetos.FirstOrDefault(x => x.IdObjeto == id);
                if (verificarObjeto != null)
                {
                    verificarObjeto.Estado = rol.Estado;

                    _context.TblObjetos.Update(verificarObjeto);
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
        public async Task<ActionResult> eliminar(TblObjeto rol, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarObjeto = _context.TblObjetos.FirstOrDefault(x => x.IdObjeto == id);
                if (verificarObjeto != null)
                {
                    verificarObjeto.EstadoEliminacion = rol.EstadoEliminacion;

                    _context.TblObjetos.Update(verificarObjeto);
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
