using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class VVictima
{
    public int IdVictima { get; set; }

    public int IdPersona { get; set; }

    public string? NombreLegalPersona { get; set; }

    public string? Dni { get; set; }

    public string? NombreLegalVictima { get; set; }

    public string? CambioNomLegalVictima { get; set; }

    public string? NombreIdentGenero { get; set; }

    public string? OtroNombres { get; set; }

    public string? NombreExpresion { get; set; }

    public string? TipoGeneroVictima { get; set; }

    public string? Orientacion { get; set; }

    public string? Ocupacion { get; set; }

    public int? DiscapacidadVictima { get; set; }

    public string? NombreCondicion { get; set; }

    public string? NombreEtnia { get; set; }

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

    public string? NombLlenadorDato { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }
}
