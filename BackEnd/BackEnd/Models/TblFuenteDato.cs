using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblFuenteDato
{
    public int IdFuenteDato { get; set; }

    public string? DescripcionFuente { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public virtual ICollection<TblGeneradorHecho> TblGeneradorHechoes { get; set; } = new List<TblGeneradorHecho>();
}
