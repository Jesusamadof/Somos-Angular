using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblOrientacionSexual
{
    public int IdOrientacion { get; set; }

    public string? Orientacion { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public virtual ICollection<TblCaso> TblCasos { get; set; } = new List<TblCaso>();

    public virtual ICollection<TblVictima> TblVictimas { get; set; } = new List<TblVictima>();
}
