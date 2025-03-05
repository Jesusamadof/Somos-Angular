using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class VUsuarioRol
{
    public int IdUsuario { get; set; }

    public string? Usuario { get; set; }

    public string? Contrasena { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public int? ContrasenaSegura { get; set; }

    public int? CambioContrasena { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    public int? EstadoRol { get; set; }

    public int? EstadoEliminacionRol { get; set; }
}
