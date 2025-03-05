using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblPersona
{
    public int IdPersona { get; set; }

    public string? Dni { get; set; }

    public string? NombreLegal { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? EstadoCivil { get; set; }

    public string? Agravantes { get; set; }

    public string? Nacionalidad { get; set; }

    public string? Telefono { get; set; }

    public int? IdNivelEduc { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public virtual TblNivelEducacion? IdNivelEducNavigation { get; set; }

    public virtual ICollection<TblLugarDomicilio> TblLugarDomicilios { get; set; } = new List<TblLugarDomicilio>();

    public virtual ICollection<TblLugarNacimiento> TblLugarNacimientos { get; set; } = new List<TblLugarNacimiento>();

    public virtual ICollection<TblVictima> TblVictimas { get; set; } = new List<TblVictima>();
}
