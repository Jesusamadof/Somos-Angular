using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblDepartamento
{
    public int IdDepartamento { get; set; }

    public string? NombreDepartamento { get; set; }

    public string? CodigoDepartamento { get; set; }

    public virtual ICollection<TblLugarDomicilio> TblLugarDomicilios { get; set; } = new List<TblLugarDomicilio>();

    public virtual ICollection<TblLugarNacimiento> TblLugarNacimientos { get; set; } = new List<TblLugarNacimiento>();

    public virtual ICollection<TblMunicipio> TblMunicipios { get; set; } = new List<TblMunicipio>();
}
