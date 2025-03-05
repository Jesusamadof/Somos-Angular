using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblReporteActual
{
    public int IdReporteActual { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Lugar { get; set; }

    public string? DiligenciaRealizada { get; set; }

    public string? InstitucionConsultada { get; set; }

    public string? NombreAutoridadConsultada { get; set; }

    public string? EstadoProceso { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }
}
