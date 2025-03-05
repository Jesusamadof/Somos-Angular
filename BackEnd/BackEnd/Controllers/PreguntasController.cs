using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntasController : ControllerBase
    {

        public readonly SomosdcContext _context;
        public PreguntasController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getPreguntas()
        {
            try
            {
                var lista = _context.TblPregunta.Where(x => x.EstadoEliminacion == 0).ToList();
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
        public async Task<ActionResult> filtroPregunta(int id)
        {
            try
            {
                var lista = _context.TblPregunta.FirstOrDefault(x => x.IdPregunta == id);
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
        public async Task<ActionResult> agregarPregunta(TblPreguntum pregunta)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (pregunta != null)
                {
                    var nuevaPregunta = new TblPreguntum
                    {
                        Pregunta = pregunta.Pregunta,
                        Descripcion = pregunta.Descripcion,
                        Estado = 1,
                        EstadoEliminacion = 0
                    };

                    _context.TblPregunta.Add(nuevaPregunta);
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
        public async Task<ActionResult> actualizarPregunta(TblPreguntum pregunta, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifPregunta = _context.TblPregunta.FirstOrDefault(x => x.IdPregunta == id);
                if (verifPregunta != null)
                {
                    verifPregunta.Pregunta = pregunta.Pregunta;
                    verifPregunta.Descripcion = pregunta.Descripcion;

                    _context.TblPregunta.Update(verifPregunta);
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
        public async Task<ActionResult> actualizarEstado(TblPreguntum datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifPregunta = _context.TblPregunta.FirstOrDefault(x => x.IdPregunta == id);
                if (verifPregunta != null)
                {
                    verifPregunta.Estado = datos.Estado;

                    _context.TblPregunta.Update(verifPregunta);
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
        public async Task<ActionResult> eliminar(TblPreguntum datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifPregunta = _context.TblPregunta.FirstOrDefault(x => x.IdPregunta == id);
                if (verifPregunta != null)
                {
                    verifPregunta.EstadoEliminacion = datos.EstadoEliminacion;

                    _context.TblPregunta.Update(verifPregunta);
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


        [HttpPost("preguntasUsuario")]
        public async Task<ActionResult> guardarPrepuestas(TblUsuario datos)
        {
             var transaction=_context.Database.BeginTransaction();
            try
            {
                if (datos!=null) {
                foreach (TblPreguntaUsuario item in datos.TblPreguntaUsuarios)
                {
                    item.FechaCreacion = DateTime.Now;

                    _context.TblPreguntaUsuarios.Add(item);
                    
                }

                _context.SaveChanges();
                transaction.Commit ();

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

        [HttpGet("verificarPreguntasUsu/{id}")]
        public async Task<ActionResult> getVerifPreguntasUsuario(int id)
        {
            try
            {
                var lista=_context.TblPreguntaUsuarios.Where(x=>x.IdUsuario==id).ToList();

                if (lista.Count > 0)
                {
                    return Ok(new
                    {
                        ok=true,
                        lista = lista
                    });
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje="No se encontraron registros"
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

