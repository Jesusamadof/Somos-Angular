using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblGeneradorHecho
{
    public int IdGeneradorHecho { get; set; }

    public int? IdFuenteDato { get; set; }

    public string? NombLlenadorDato { get; set; }

    public DateOnly? FechaLlenadoDato { get; set; }

    public string? IntitucionRecoDato { get; set; }

    public string? CargoDentroOrganizacion { get; set; }

    public string? NombSupervisor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public virtual TblFuenteDato? IdFuenteDatoNavigation { get; set; }

    public virtual ICollection<TblEnlaceRecopDato> TblEnlaceRecopDatos { get; set; } = new List<TblEnlaceRecopDato>();

    public virtual ICollection<TblHecho> TblHechoes { get; set; } = new List<TblHecho>();

    public virtual ICollection<TblVictima> TblVictimas { get; set; } = new List<TblVictima>();
}
