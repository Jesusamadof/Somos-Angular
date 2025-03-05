using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblMunicipio
{
    public int IdMunicipio { get; set; }

    public string? NombreMunicipio { get; set; }

    public string? CodigoMunicipio { get; set; }

    public int? IdDepartamento { get; set; }

    public virtual TblDepartamento? IdDepartamentoNavigation { get; set; }

    public virtual ICollection<TblLugarDomicilio> TblLugarDomicilios { get; set; } = new List<TblLugarDomicilio>();

    public virtual ICollection<TblLugarNacimiento> TblLugarNacimientos { get; set; } = new List<TblLugarNacimiento>();
}
