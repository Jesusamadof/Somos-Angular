using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class VPersona
{
    public int IdPersona { get; set; }

    public string? Dni { get; set; }

    public string? NombreLegal { get; set; }

    public long? Edad { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? EstadoCivil { get; set; }

    public string? Agravantes { get; set; }

    public string? Nacionalidad { get; set; }

    public string? Telefono { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public int? IdNivelEduc { get; set; }

    public string? NombreNivel { get; set; }

    public int IdLugarNacimiento { get; set; }

    public string? NombreDepartamentoNac { get; set; }

    public int? IdDepartamentoNac { get; set; }

    public int? IdMunicipioNac { get; set; }

    public string? NombreMunicipioNac { get; set; }

    public string? CiudadNac { get; set; }

    public string? AldeaNac { get; set; }

    public int IdLugarDomicilio { get; set; }

    public string? NombreDepartamentoDom { get; set; }

    public int? IdDepartamentoDom { get; set; }

    public int? IdMunicipioDom { get; set; }

    public string? NombreMunicipioDom { get; set; }

    public string? CiudadDom { get; set; }

    public string? AldeaDom { get; set; }
}
