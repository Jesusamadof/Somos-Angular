using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class VPermiso
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

    public int? IdObjetoPadre { get; set; }

    public string? NombreObjeto { get; set; }

    public string? IconoHijo { get; set; }

    public string? NombreObjetoPadre { get; set; }

    public string? IconoPadre { get; set; }

    public string? Ruta { get; set; }

    public string? Icono { get; set; }

    public string? NombreRol { get; set; }

    public int? EstadoPermiso { get; set; }

    public int? EstadoEliminacionPermiso { get; set; }

    public int? EstadoObjeto { get; set; }

    public int? EstadoEliminacionObjeto { get; set; }

    public int? EstadoRol { get; set; }

    public int? EstadoEliminacionRol { get; set; }
}
