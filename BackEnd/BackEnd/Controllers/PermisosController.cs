using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        public readonly SomosdcContext _context;
        public PermisosController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getPermisos()
        {
            try
            {
                var lista = _context.VPermisos.Where(x => x.EstadoEliminacion == 0).ToList();
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
        public async Task<ActionResult> filtroUsuario(int id)
        {
            try
            {
                var lista = _context.TblUsuarios.FirstOrDefault(x => x.IdUsuario == id);
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

        [HttpGet("permisosPadres/{idRol}")]
        public async Task<ActionResult> permisoObjetoPadre(int idRol)
        {
            try
            {
                var lista = _context.VPermisos.Where(x => x.IdRol == idRol  ).ToList();
                if (lista.Count>0)
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

        [HttpGet("permisosHijos/{idRol}")]
        public async Task<ActionResult> permisoObjetoHijos(int idRol)
        {
            try
            {
                var lista = _context.VPermisos.Where(x => x.IdRol == idRol && x.IdObjetoPadre != 1).ToList();
                if (lista.Count>0)
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
        public async Task<ActionResult> agregarPermiso(TblRol datos)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (datos != null)
                {
                    foreach (TblPermiso item in datos.TblPermisos) 
                    {

                        var nuevoPermiso = new TblPermiso
                        {
                            IdRol = item.IdRol,
                            IdObjeto = item.IdObjeto,
                            Ver = 1,
                            Agregar = 1,
                            Editar = 1,
                            Eliminar = 1,
                            Reporte = 1,
                            Estado = 1,
                            EstadoEliminacion = 0
                        };
                        _context.TblPermisos.Add(nuevoPermiso);


                    }

                   

                    
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

        [HttpPut("permisoVer/{id}")]
        public async Task<ActionResult> permisoVer(TblPermiso datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifPermiso = _context.TblPermisos.FirstOrDefault(x => x.IdPermiso == id);

                if (verifPermiso != null)
                {

                    verifPermiso.Ver = datos.Ver;
                    _context.TblPermisos.Update(verifPermiso);
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

        [HttpPut("permisoAgrega/{id}")]
        public async Task<ActionResult> permisoAgregar(TblPermiso datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifPermiso = _context.TblPermisos.FirstOrDefault(x => x.IdPermiso == id);

                if (verifPermiso != null)
                {

                    verifPermiso.Agregar = datos.Agregar;
                    _context.TblPermisos.Update(verifPermiso);
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

        [HttpPut("permisoEdita/{id}")]
        public async Task<ActionResult> permisoEditar(TblPermiso datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifPermiso = _context.TblPermisos.FirstOrDefault(x => x.IdPermiso == id);

                if (verifPermiso != null)
                {

                    verifPermiso.Editar = datos.Editar;
                    _context.TblPermisos.Update(verifPermiso);
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

        [HttpPut("permisoEliminar/{id}")]
        public async Task<ActionResult> permisoEliminar(TblPermiso datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifPermiso = _context.TblPermisos.FirstOrDefault(x => x.IdPermiso == id);

                if (verifPermiso != null)
                {

                    verifPermiso.Eliminar = datos.Eliminar;
                    _context.TblPermisos.Update(verifPermiso);
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
        public async Task<ActionResult> actualizarEstado(TblUsuario datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifUsuario = _context.TblUsuarios.FirstOrDefault(x => x.IdUsuario == id);
                if (verifUsuario != null)
                {
                    verifUsuario.Estado = datos.Estado;

                    _context.TblUsuarios.Update(verifUsuario);
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
        public async Task<ActionResult> eliminar(TblUsuario datos, int id)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var verifUsuario = _context.TblUsuarios.FirstOrDefault(x => x.IdUsuario == id);
                if (verifUsuario != null)
                {
                    verifUsuario.EstadoEliminacion = datos.EstadoEliminacion;

                    _context.TblUsuarios.Update(verifUsuario);
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
