using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaPrisa.Models.Entities;

/// <summary>
/// Tabla para el inventario por sucursal
/// </summary>
public partial class InventarioSucursal
{
    public int Id { get; set; }

    public int? ProductoId { get; set; }

    public int SucursalId { get; set; }

    public int Stock { get; set; }

    [Column("stock_minimo")]
    public int StockMinimo { get; set; } = 0;

    public virtual Producto Producto { get; set; } = null!;

    public virtual Sucursale Sucursal { get; set; } = null!;
}
