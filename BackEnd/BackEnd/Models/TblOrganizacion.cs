using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblOrganizacion
{
    public int IdOrganizacion { get; set; }

    public string? NombreOrganizacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<TblDetOrganVictima> TblDetOrganVictimas { get; set; } = new List<TblDetOrganVictima>();
}
