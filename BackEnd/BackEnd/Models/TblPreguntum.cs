using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblPreguntum
{
    public int IdPregunta { get; set; }

    public string? Pregunta { get; set; }

    public string? Descripcion { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public virtual ICollection<TblPreguntaUsuario> TblPreguntaUsuarios { get; set; } = new List<TblPreguntaUsuario>();
}
