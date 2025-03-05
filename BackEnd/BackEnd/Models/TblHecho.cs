using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblHecho
{
    public int IdHecho { get; set; }

    public int? IdCaso { get; set; }

    public int? IdGeneradorHecho { get; set; }

    public DateOnly? FechaHecho { get; set; }

    public TimeOnly? HoraHecho { get; set; }

    public string? LugarHecho { get; set; }

    public int? IdGeneroVictima { get; set; }

    public int? IdTipoVictima { get; set; }

    public int? IdTipoRelacion { get; set; }

    public int? IdModalidad { get; set; }

    public int? IdDetallesSobreRelacion { get; set; }

    public int? AgresionSexual { get; set; }

    public int? DenunciaPrevia { get; set; }

    public int? ProcesoJudicial { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioCreo { get; set; }

    public int? IdUsuarioModifico { get; set; }

    public int? Estado { get; set; }

    public int? EstadoEliminacion { get; set; }

    public virtual TblCaso? IdCasoNavigation { get; set; }

    public virtual TblDetallesSobreRelacion? IdDetallesSobreRelacionNavigation { get; set; }

    public virtual TblGeneradorHecho? IdGeneradorHechoNavigation { get; set; }

    public virtual TblGeneroVictima? IdGeneroVictimaNavigation { get; set; }

    public virtual TblModalidad? IdModalidadNavigation { get; set; }

    public virtual TblTipoRelacion? IdTipoRelacionNavigation { get; set; }

    public virtual TblTipoVictima? IdTipoVictimaNavigation { get; set; }
}
