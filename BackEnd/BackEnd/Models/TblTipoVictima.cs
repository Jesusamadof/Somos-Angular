using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblTipoVictima
{
    public int IdTipoVictima { get; set; }

    public string? TipoVictima { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public virtual ICollection<TblHecho> TblHechoes { get; set; } = new List<TblHecho>();
}
