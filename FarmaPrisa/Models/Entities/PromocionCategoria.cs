using System;
using System.Collections.Generic;

namespace FarmaPrisa.Models.Entities;

/// <summary>
/// Tabla para aplicar una promoción a categorías enteras
/// </summary>
public partial class PromocionCategoria
{
    public int Id { get; set; }

    public int PromocionId { get; set; }

    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual Promocione Promocion { get; set; } = null!;
}
