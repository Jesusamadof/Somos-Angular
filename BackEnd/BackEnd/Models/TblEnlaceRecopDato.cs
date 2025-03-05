using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblEnlaceRecopDato
{
    public int IdEnlaceRecopDato { get; set; }

    public string? Nombre { get; set; }

    public string? TipoArchivo { get; set; }

    public byte[]? Archivo { get; set; }

    public int? IdGeneradorHecho { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public virtual TblGeneradorHecho? IdGeneradorHechoNavigation { get; set; }
}
