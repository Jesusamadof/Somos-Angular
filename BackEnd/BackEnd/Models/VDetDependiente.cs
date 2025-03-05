using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class VDetDependiente
{
    public int IdDetDepVictima { get; set; }

    public int? IdDependiente { get; set; }

    public string? TipoDependiente { get; set; }

    public int? IdVictima { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }
}
