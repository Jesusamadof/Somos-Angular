using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblExpresionGenero
{
    public int IdExpresionGenero { get; set; }

    public string? NombreExpresion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<TblVictima> TblVictimas { get; set; } = new List<TblVictima>();
}
