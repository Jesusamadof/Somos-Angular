using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblPreguntaUsuario
{
    public int IdPreguntaUsuario { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdPregunta { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public string? Respuesta { get; set; }

    public virtual TblPreguntum? IdPreguntaNavigation { get; set; }

    public virtual TblUsuario? IdUsuarioNavigation { get; set; }
}
