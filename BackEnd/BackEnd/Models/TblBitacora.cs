using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class TblBitacora
{
    public int IdBitacora { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Evento { get; set; }

    public string? Valor { get; set; }

    public int? IdUsuario { get; set; }

    public virtual TblUsuario? IdUsuarioNavigation { get; set; }
}
