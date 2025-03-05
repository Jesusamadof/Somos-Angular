using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class VPreguntasUsuario
{
    public int IdPreguntaUsuario { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdPregunta { get; set; }

    public string? Respuesta { get; set; }

    public string? Usuario { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public int? Estado { get; set; }

    public int? IdRol { get; set; }

    public int? EstadoEliminacion { get; set; }

    public string? Pregunta { get; set; }
}
