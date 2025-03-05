using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneradorHechoController : ControllerBase
    {


        public readonly SomosdcContext _context;
        public GeneradorHechoController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getGeneradorHecho()
        {
            try
            {
                var lista = _context.TblGeneradorHechoes.Where(x => x.EstadoEliminacion == 0).ToList();
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
        public async Task<ActionResult> filtroGeneradorHecho(int id)
        {
            try
            {
                var lista = _context.TblGeneradorHechoes.FirstOrDefault(x => x.IdGeneradorHecho == id);
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
        public async Task<ActionResult> agregarGeneradorHecho(TblGeneradorHecho datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                    var nuevoRegistro = new TblGeneradorHecho
                    {
                        IdFuenteDato = datos.IdFuenteDato,
                        NombLlenadorDato = datos.NombLlenadorDato,
                        FechaLlenadoDato = datos.FechaLlenadoDato,
                        IntitucionRecoDato = datos.IntitucionRecoDato,
                        CargoDentroOrganizacion = datos.CargoDentroOrganizacion,
                        NombSupervisor=datos.NombSupervisor,
                        FechaCreacion = DateTime.Now,
                        IdUsuarioCreo = datos.IdUsuarioCreo,
                        Estado = 1,
                        EstadoEliminacion = 0
                    };

                    _context.TblGeneradorHechoes.Add(nuevoRegistro);
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
        public async Task<ActionResult> actualizarGeneradorHecho(TblGeneradorHecho datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifCondicion = _context.TblGeneradorHechoes.FirstOrDefault(x => x.IdGeneradorHecho == id);
                if (verifCondicion != null)
                {
                    verifCondicion.IdFuenteDato = datos.IdFuenteDato;
                    verifCondicion.NombLlenadorDato = datos.NombLlenadorDato;
                    verifCondicion.FechaLlenadoDato = datos.FechaLlenadoDato;
                    verifCondicion.IntitucionRecoDato = datos.IntitucionRecoDato;
                    verifCondicion.CargoDentroOrganizacion = datos.CargoDentroOrganizacion;
                    verifCondicion.NombSupervisor = datos.NombSupervisor;
                    verifCondicion.FechaModificacion = DateTime.Now;
                    verifCondicion.IdUsuarioModifico = datos.IdUsuarioModifico;

                    _context.TblGeneradorHechoes.Update(verifCondicion);
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
        public async Task<ActionResult> actualizarEstado(TblGeneradorHecho datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifGenHecho = _context.TblGeneradorHechoes.FirstOrDefault(x => x.IdGeneradorHecho == id);
                if (verifGenHecho != null)
                {
                    verifGenHecho.Estado = datos.Estado;
                    verifGenHecho.FechaModificacion = DateTime.Now;

                    _context.TblGeneradorHechoes.Update(verifGenHecho);
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
        public async Task<ActionResult> eliminar(TblGeneradorHecho datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifGenHecho = _context.TblGeneradorHechoes.FirstOrDefault(x => x.IdGeneradorHecho == id);
                if (verifGenHecho != null)
                {
                    verifGenHecho.EstadoEliminacion = datos.EstadoEliminacion;
                    verifGenHecho.FechaModificacion = DateTime.Now;


                    _context.TblGeneradorHechoes.Update(verifGenHecho);
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
