using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntasUsuarioController : ControllerBase
    {
        public readonly SomosdcContext _context;
        public PreguntasUsuarioController(SomosdcContext context)
        {
            _context = context;
        }


        [HttpGet("{usuario}")]
        public async Task<ActionResult> preguntasUsuario(string usuario)
        {
            {
                try
                {
                    var lista = _context.VPreguntasUsuarios.Where(x => x.Usuario == usuario || x.Correo == usuario).ToList();
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
        }

        [HttpPost("preguntasUsuario")]
        public async Task<ActionResult> guardarPrepuestas(TblUsuario datos)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                    foreach (TblPreguntaUsuario item in datos.TblPreguntaUsuarios)
                    {
                        item.FechaCreacion = DateTime.Now;

                        _context.TblPreguntaUsuarios.Add(item);

                    }

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

        [HttpPost("verificarRespuesta")]
        public async Task<ActionResult> VerificarPrepuesta(TblPreguntaUsuario datos)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                   var lista  = _context.VPreguntasUsuarios.Where(x=>x.Respuesta==datos.Respuesta && x.IdPregunta==datos.IdPregunta).ToList();
                    if (lista.Count > 0)
                    {

                        return Ok(new
                        {
                            ok = true,
                            lista=lista
                        });

                    }
                    else
                    {
                        return Ok(new
                        {
                            ok = false
                        });

                    }


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
