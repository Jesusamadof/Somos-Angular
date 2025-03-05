using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        public readonly SomosdcContext _context;
        public PersonasController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getPersonas()
        {
            try
            {
                var lista = _context.VPersonas.Where(x => x.EstadoEliminacion == 0).ToList();
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
        public async Task<ActionResult> filtroPersona(int id)
        {
            try
            {
                var lista = _context.VPersonas.FirstOrDefault(x => x.IdPersona == id);
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
        public async Task<ActionResult> agregarPersona(TblPersona datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {





                    datos.FechaCreacion = DateTime.Now;
                    datos.Estado = 1;
                    datos.EstadoEliminacion = 0;
                    


                    
                    foreach (TblLugarNacimiento item in datos.TblLugarNacimientos)
                    {

                        item.FechaCreacion = DateTime.Now;
                        item.Estado = 1;
                        item.EstadoEliminacion = 0;

                    };

                       


                    foreach (TblLugarDomicilio item in datos.TblLugarDomicilios)
                    {

                        item.FechaCreacion = DateTime.Now;
                        item.Estado = 1;
                        item.EstadoEliminacion = 0;

                    };
                     


                    _context.TblPersonas.Add(datos);
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
        public async Task<ActionResult> actualizarPersona(TblPersona datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                TblPersona verificarPersona = _context.TblPersonas.FirstOrDefault(x => x.IdPersona == id);
                if (verificarPersona != null)
                {
                    verificarPersona.NombreLegal = datos.NombreLegal;
                    verificarPersona.Dni=datos.Dni;
                    verificarPersona.FechaNacimiento = datos.FechaNacimiento;
                    verificarPersona.EstadoCivil = datos.EstadoCivil;
                    verificarPersona.Agravantes = datos.Agravantes;
                    verificarPersona.Nacionalidad = datos.Nacionalidad;
                    verificarPersona.Telefono = datos.Telefono;
                    verificarPersona.IdNivelEduc = datos.IdNivelEduc;
                    verificarPersona.FechaModificacion = DateTime.Now;
                    verificarPersona.IdUsuarioModifico = datos.IdUsuarioModifico;

                    foreach(TblLugarNacimiento item in datos.TblLugarNacimientos)
                    {
                        TblLugarNacimiento lugNac = _context.TblLugarNacimientos.FirstOrDefault(x => x.IdPersona == id);
                        if (lugNac != null)
                        {
                            lugNac.IdDepartamento = item.IdDepartamento;
                            lugNac.IdMunicipio = item.IdMunicipio;
                            lugNac.Aldea = item.Aldea;
                            lugNac.Ciudad= item.Ciudad;
                            lugNac.IdUsuarioModifico= item.IdUsuarioModifico;
                            lugNac.FechaModificacion = DateTime.Now;

                            _context.TblLugarNacimientos.Update(lugNac);
                        }



                    }

                    foreach (TblLugarDomicilio item in datos.TblLugarDomicilios)
                    {
                        TblLugarDomicilio lugDom = _context.TblLugarDomicilios.FirstOrDefault(x => x.IdPersona == id);
                        if (lugDom != null)
                        {
                            lugDom.IdDepartamento = item.IdDepartamento;
                            lugDom.IdMunicipio = item.IdMunicipio;
                            lugDom.Aldea = item.Aldea;
                            lugDom.Ciudad = item.Ciudad;
                            lugDom.IdUsuarioModifico = item.IdUsuarioModifico;
                            lugDom.FechaModificacion = DateTime.Now;

                            _context.TblLugarDomicilios.Update(lugDom);
                        }
                    }


                    _context.TblPersonas.Update(verificarPersona);
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
        public async Task<ActionResult> actualizarEstado(TblRol datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verificarPersona = _context.TblPersonas.FirstOrDefault(x => x.IdPersona == id);
                var verifLugNac = _context.TblLugarNacimientos.FirstOrDefault(x => x.IdPersona == id);
                var verifLugDom = _context.TblLugarDomicilios.FirstOrDefault(x => x.IdPersona == id);
                if (verificarPersona != null)
                {
                    verificarPersona.Estado = datos.Estado;
                    verifLugNac.Estado = datos.Estado;
                    verifLugDom.Estado=datos.Estado;


                    _context.TblPersonas.Update(verificarPersona);
                    _context.TblLugarNacimientos.Update(verifLugNac);
                    _context.TblLugarDomicilios.Update(verifLugDom);
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
                var verificarPersona = _context.TblPersonas.FirstOrDefault(x => x.IdPersona == id);
                var verifLugNac = _context.TblLugarNacimientos.FirstOrDefault(x => x.IdPersona == id);
                var verifLugDom = _context.TblLugarDomicilios.FirstOrDefault(x => x.IdPersona == id);
                if (verificarPersona != null)
                {
                    verificarPersona.EstadoEliminacion = datos.EstadoEliminacion;

                    _context.TblPersonas.Update(verificarPersona);
                    _context.TblLugarNacimientos.Update(verifLugNac);
                    _context.TblLugarDomicilios.Update(verifLugDom);
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
