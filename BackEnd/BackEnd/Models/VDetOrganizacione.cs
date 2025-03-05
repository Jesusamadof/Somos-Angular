using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class VDetOrganizacione
{
    public int IdDetOrganVictima { get; set; }

    public int? IdOrganizacion { get; set; }

    public int? IdVictima { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public string? NombreOrganizacion { get; set; }
}
