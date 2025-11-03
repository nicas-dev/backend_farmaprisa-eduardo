using System;
using System.Collections.Generic;

namespace FarmaPrisa.Models.Entities;

/// <summary>
/// Tabla para la gestión de los productos favoritos de los usuarios
/// </summary>
public partial class FavoritosUsuario
{
    public int? UsuarioId { get; set; }

    public int? ProductoId { get; set; }

    public DateTime? FechaAgregado { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
