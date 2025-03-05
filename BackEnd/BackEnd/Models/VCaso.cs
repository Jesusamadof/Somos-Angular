using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class VCaso
{
    public int IdCaso { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Hora { get; set; }

    public string? Lugar { get; set; }

    public string? NombreGenero { get; set; }

    public string? Alias { get; set; }

    public string? Dni { get; set; }

    public string? Orientacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public string? OtroNombre { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }
}
