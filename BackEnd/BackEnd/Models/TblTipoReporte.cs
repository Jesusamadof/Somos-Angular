using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblTipoReporte
{
    public int IdTipoReporte { get; set; }

    public string? Circular { get; set; }

    public string? Columnas { get; set; }

    public string? Lineal { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }
}
