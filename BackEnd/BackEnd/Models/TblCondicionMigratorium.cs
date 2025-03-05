using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblCondicionMigratorium
{
    public int IdCondicionMigratoria { get; set; }

    public string? NombreCondicion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<TblVictima> TblVictimas { get; set; } = new List<TblVictima>();
}
