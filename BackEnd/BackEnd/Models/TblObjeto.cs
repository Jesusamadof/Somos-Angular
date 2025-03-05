using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblObjeto
{
    public int IdObjeto { get; set; }

    public int? IdObjetoPadre { get; set; }

    public string? NombreObjeto { get; set; }

    public string? Ruta { get; set; }

    public string? Icono { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public virtual ICollection<TblPermiso> TblPermisos { get; set; } = new List<TblPermiso>();
}
