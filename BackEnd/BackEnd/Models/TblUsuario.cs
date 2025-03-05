using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackEnd.Models;

public partial class TblUsuario
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

    public int? IdRol { get; set; }

    public virtual TblRol? IdRolNavigation { get; set; }
   

    public virtual ICollection<TblBitacora> TblBitacoras { get; set; } = new List<TblBitacora>();
   

    public virtual ICollection<TblPreguntaUsuario> TblPreguntaUsuarios { get; set; } = new List<TblPreguntaUsuario>();

}
