
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VictimaController : ControllerBase
    {
        public readonly SomosdcContext _context;
        public VictimaController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getVictimasFiltro(int id)
        {
            try
            {
                var lista = _context.TblVictimas.FirstOrDefault(x => x.IdVictima == id );
                if (lista!= null)
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


        [HttpGet]
        public async Task<ActionResult> getVictimas()
        {
            try
            {
                var lista = _context.VVictimas.Where(x => x.EstadoEliminacion == 0).ToList();
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


        [HttpPost]
        public async Task<ActionResult> agregarVictima(TblVictima datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                    datos.FechaCreacion = DateTime.Now;
                    datos.Estado = 1;
                    datos.EstadoEliminacion=0;

                    foreach (TblDetDepenVictima item in datos.TblDetDepenVictimas)
                    {
                        item.FechaCreacion=DateTime.Now;
                        item.Estado = 1;
                        item.EstadoEliminacion=0;
                        
                    }

                    foreach (TblDetOrganVictima item in datos.TblDetOrganVictimas)
                    {
                        item.FechaCreacion = DateTime.Now;
                        item.Estado = 1;
                        item.EstadoEliminacion = 0;

                    }
                    _context.TblVictimas.Add(datos);
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
        public async Task<ActionResult> actualizarVictima(TblVictima datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                TblVictima verifVicitma = _context.TblVictimas.FirstOrDefault(x => x.IdVictima == id);
                if (verifVicitma != null)
                {
                    verifVicitma.IdPersona = datos.IdPersona;
                    verifVicitma.NombreLegal = datos.NombreLegal;
                    verifVicitma.CambioNomLegalVictima = datos.CambioNomLegalVictima;
                    verifVicitma.NombreIdentGenero = datos.NombreIdentGenero;
                    verifVicitma.OtroNombres = datos.OtroNombres;
                    verifVicitma.IdGeneroVictima = datos.IdGeneroVictima;
                    verifVicitma.IdExpresionGenero = datos.IdExpresionGenero;
                    verifVicitma.IdOrientacion = datos.IdOrientacion;
                    verifVicitma.Ocupacion = datos.Ocupacion;
                    verifVicitma.DiscapacidadVictima = datos.DiscapacidadVictima;
                    verifVicitma.IdCondicionMigratoria = datos.IdCondicionMigratoria;
                    verifVicitma.IdEtnia = datos.IdEtnia;
                    verifVicitma.Hijos = datos.Hijos;
                    verifVicitma.CantHijos = datos.CantHijos;
                    verifVicitma.CantHijosMen = datos.CantHijosMen;
                    verifVicitma.CantHijosMay = datos.CantHijosMay;
                    verifVicitma.CantPersDependiente = datos.CantPersDependiente;
                    verifVicitma.PertenecienteOrganizacion = datos.PertenecienteOrganizacion;
                    verifVicitma.DenuciaPrevia = datos.DenuciaPrevia;
                    verifVicitma.NumeroCaso = datos.NumeroCaso;
                    verifVicitma.TipoDenucia = datos.TipoDenucia;
                    verifVicitma.NomInstiDenucia = datos.NomInstiDenucia;
                    verifVicitma.MedidasProteccion = datos.MedidasProteccion;
                    verifVicitma.TipoMedProteccion = datos.TipoMedProteccion;
                    verifVicitma.IdGeneradorHecho = datos.IdGeneradorHecho;
                    verifVicitma.IdUsuarioModifico = datos.IdUsuarioModifico;
                    verifVicitma.FechaModificacion = DateTime.Now;

                    foreach (TblDetDepenVictima item in datos.TblDetDepenVictimas)
                    {
                        if (item.IdDetDepVictima == 0)
                        {
                            item.IdVictima = id;
                            item.FechaCreacion= DateTime.Now;
                            item.Estado = 1;
                            item.EstadoEliminacion = 0;
                            _context.TblDetDepenVictimas.Add(item);
                        }
                    }

                    foreach (TblDetOrganVictima item in datos.TblDetOrganVictimas)
                    {
                        if (item.IdDetOrganVictima == 0)
                        {
                            item.IdVictima= id;
                            item.FechaCreacion = DateTime.Now;
                            item.Estado = 1;
                            item.EstadoEliminacion = 0;
                            _context.TblDetOrganVictimas.Add(item);
                        }
                    }



                    _context.TblVictimas.Update(verifVicitma);
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
        public async Task<ActionResult> actualizarEstado(TblVictima datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifVictima = _context.TblVictimas.FirstOrDefault(x => x.IdVictima == id);
               
                if (verifVictima != null)
                {
                    verifVictima.Estado = datos.Estado;

                    var verifDetDepencia = _context.TblDetDepenVictimas.Where(x => x.IdVictima == id).ToList();
                    var verifDetOrgan = _context.TblDetOrganVictimas.Where(x => x.IdVictima == id).ToList();
                    foreach (var item in verifDetDepencia)
                    {
                        item.Estado = datos.Estado;
                        item.FechaModificacion = DateTime.Now;
                        _context.TblDetDepenVictimas.Update(item);
                        
                    }

                    foreach (var item in verifDetOrgan)
                    {
                        item.Estado = datos.Estado;
                        item.FechaModificacion = DateTime.Now;
                        _context.TblDetOrganVictimas.Update(item);

                    }
                  


                    _context.TblVictimas.Update(verifVictima);
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
        public async Task<ActionResult> eliminar(TblPersona datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifVictima = _context.TblVictimas.FirstOrDefault(x => x.IdVictima == id);

                if (verifVictima != null)
                {

                    var verifDetDepencia = _context.TblDetDepenVictimas.Where(x => x.IdVictima == id).ToList();
                    var verifDetOrgan = _context.TblDetOrganVictimas.Where(x => x.IdVictima == id).ToList();

                    verifVictima.EstadoEliminacion = datos.EstadoEliminacion;
                    foreach (var item in verifDetDepencia)
                    {
                        item.EstadoEliminacion = datos.EstadoEliminacion;
                        item.FechaModificacion = DateTime.Now;
                        _context.TblDetDepenVictimas.Update(item);

                    }

                    foreach (var item in verifDetOrgan)
                    {
                        item.EstadoEliminacion = datos.EstadoEliminacion;
                        item.FechaModificacion = DateTime.Now;
                        _context.TblDetOrganVictimas.Update(item);

                    }



                    _context.TblVictimas.Update(verifVictima);
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

        [HttpGet("cargarDependientes/{id}")]
        public async Task<ActionResult> getDependientes(int id)
        {
            try
            {
                var lista = _context.VDetDependientes.Where(x => x.IdVictima == id).ToList();
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

        [HttpGet("cargarOrganizaciones/{id}")]
        public async Task<ActionResult> getOrganizaciones(int id)
        {
            try
            {
                var lista = _context.VDetOrganizaciones.Where(x => x.IdVictima == id).ToList();
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

        [HttpDelete("eliminarDependiente/{id}")]
        public async Task<ActionResult> eliminarDetDependencia(int id)
        {
            try
            {
                var verif=_context.TblDetDepenVictimas.FirstOrDefault(x=>x.IdDetDepVictima == id);

                if (verif != null)
                {
                    _context.TblDetDepenVictimas.Remove(verif);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        ok = true,
                        mensaje = "Registro eliminado correctamente!!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje = "No se encontro el registro a eliminar!!"
                    });

                }

            }
            catch (Exception ex )
            {

                return StatusCode(500, $"Se encontro el siguiente error {ex}");
            }
        }


        [HttpDelete("eliminarOrganizacion/{id}")]
        public async Task<ActionResult> eliminarOrganizacion(int id)
        {
            try
            {
                var verif = _context.TblDetOrganVictimas.FirstOrDefault(x => x.IdDetOrganVictima == id);

                if (verif != null)
                {
                    _context.TblDetOrganVictimas.Remove(verif);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        ok = true,
                        mensaje = "Registro eliminado correctamente!!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje = "No se encontro el registro a eliminar!!"
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
