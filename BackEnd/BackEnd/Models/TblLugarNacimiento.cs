using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblLugarNacimiento
{
    public int IdLugarNacimiento { get; set; }

    public int? IdDepartamento { get; set; }

    public int? IdMunicipio { get; set; }

    public string? Ciudad { get; set; }

    public string? Aldea { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public int? IdPersona { get; set; }

    public virtual TblDepartamento? IdDepartamentoNavigation { get; set; }

    public virtual TblMunicipio? IdMunicipioNavigation { get; set; }

    public virtual TblPersona? IdPersonaNavigation { get; set; }
}
