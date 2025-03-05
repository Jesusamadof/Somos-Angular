using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblDetOrganVictima
{
    public int IdDetOrganVictima { get; set; }

    public int? IdOrganizacion { get; set; }

    public int? IdVictima { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual TblOrganizacion? IdOrganizacionNavigation { get; set; }

    public virtual TblVictima? IdVictimaNavigation { get; set; }
}
