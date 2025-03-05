using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblDependiente
{
    public int IdDependiente { get; set; }

    public string? TipoDependiente { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<TblDetDepenVictima> TblDetDepenVictimas { get; set; } = new List<TblDetDepenVictima>();
}
