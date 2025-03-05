using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Muni_DeptController : ControllerBase
    {
        public readonly SomosdcContext _context;
        public Muni_DeptController(SomosdcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> getDepartamentos()
        {
            try
            {
                var lista = _context.TblDepartamentos.ToList();
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
        public async Task<ActionResult> Municipios(int id)
        {
            try
            {
                var lista = _context.TblMunicipios.Where(x => x.IdDepartamento == id).ToList();
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
}
