using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblPermiso
{
    public int IdPermiso { get; set; }

    public int? IdObjeto { get; set; }

    public int? IdRol { get; set; }

    public int? Ver { get; set; }

    public int? Agregar { get; set; }

    public int? Editar { get; set; }

    public int? Eliminar { get; set; }

    public int? Reporte { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public virtual TblObjeto? IdObjetoNavigation { get; set; }

    public virtual TblRol? IdRolNavigation { get; set; }
}
