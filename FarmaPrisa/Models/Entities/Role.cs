using System;
using System.Collections.Generic;

namespace FarmaPrisa.Models.Entities;

/// <summary>
/// Tabla para los roles
/// </summary>
public partial class Role
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; } = new List<UsuarioRole>();
}
