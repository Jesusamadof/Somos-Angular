using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblRol
{
    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    public string? Descripcion { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public virtual ICollection<TblPermiso> TblPermisos { get; set; } = new List<TblPermiso>();

    public virtual ICollection<TblUsuario> TblUsuarios { get; set; } = new List<TblUsuario>();
}
