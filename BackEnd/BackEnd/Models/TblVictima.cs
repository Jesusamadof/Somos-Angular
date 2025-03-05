using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblVictima
{
    public int IdVictima { get; set; }

    public int? IdPersona { get; set; }

    public string? NombreLegal { get; set; }

    public string? CambioNomLegalVictima { get; set; }

    public string? NombreIdentGenero { get; set; }

    public string? OtroNombres { get; set; }

    public int? IdGeneroVictima { get; set; }

    public int? IdExpresionGenero { get; set; }

    public int? IdOrientacion { get; set; }

    public string? Ocupacion { get; set; }

    public int? DiscapacidadVictima { get; set; }

    public int? IdCondicionMigratoria { get; set; }

    public int? IdEtnia { get; set; }

    public int? Hijos { get; set; }

    public int? CantHijos { get; set; }

    public int? CantHijosMen { get; set; }

    public int? CantHijosMay { get; set; }

    public int? CantPersDependiente { get; set; }

    public int? PertenecienteOrganizacion { get; set; }

    public int? DenuciaPrevia { get; set; }

    public int? NumeroCaso { get; set; }

    public string? TipoDenucia { get; set; }

    public string? NomInstiDenucia { get; set; }

    public string? MedidasProteccion { get; set; }

    public string? TipoMedProteccion { get; set; }

    public int? IdGeneradorHecho { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual TblCondicionMigratorium? IdCondicionMigratoriaNavigation { get; set; }

    public virtual TblEtnium? IdEtniaNavigation { get; set; }

    public virtual TblExpresionGenero? IdExpresionGeneroNavigation { get; set; }

    public virtual TblGeneradorHecho? IdGeneradorHechoNavigation { get; set; }

    public virtual TblGeneroVictima? IdGeneroVictimaNavigation { get; set; }

    public virtual TblOrientacionSexual? IdOrientacionNavigation { get; set; }

    public virtual TblPersona? IdPersonaNavigation { get; set; }

    public virtual ICollection<TblDetDepenVictima> TblDetDepenVictimas { get; set; } = new List<TblDetDepenVictima>();

    public virtual ICollection<TblDetOrganVictima> TblDetOrganVictimas { get; set; } = new List<TblDetOrganVictima>();
}
