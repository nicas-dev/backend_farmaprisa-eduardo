using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaPrisa.Models.Entities;

/// <summary>
/// La tabla principal del catálogo de productos.
/// </summary>
public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    //public string Descripcion { get; set; } = null!; // Se paso a Producto_Detalle

    public string TipoProducto { get; set; } = null!;

    public decimal Precio { get; set; }

    public decimal? PrecioAnterior { get; set; }

    //public string? ImagenUrl { get; set; }

    [StringLength(150)]
    public string? Sku { get; set; }

    [StringLength(50)] // <-- Le damos un tamaño, ej. 50 caracteres
    public string? UnidadMedida { get; set; }

    public bool? RequiereReceta { get; set; }

    public int? PuntosParaCanje { get; set; }

    [Column("categoria_id")]
    public int? CategoriaId { get; set; }

    [Column("proveedor_id")]
    public int? ProveedorId { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public bool EstaActivo { get; set; }

    // Nueva propiedad para los detalles adicionales
    public ICollection<ProductoDetalle> Detalles { get; set; }

    public virtual ICollection<CarritoItem> CarritoItems { get; set; } = new List<CarritoItem>();

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

    public virtual ICollection<FavoritosUsuario> FavoritosUsuarios { get; set; } = new List<FavoritosUsuario>();

    public virtual ICollection<InventarioSucursal> InventarioSucursals { get; set; } = new List<InventarioSucursal>();

    public virtual ICollection<OpinionesProducto> OpinionesProductos { get; set; } = new List<OpinionesProducto>();

    public virtual ICollection<ProductoSintoma> ProductoSintomas { get; set; } = new List<ProductoSintoma>();

    public virtual ICollection<PromocionProducto> PromocionProductos { get; set; } = new List<PromocionProducto>();
    public virtual ICollection<ProductoImagen> ImagenesGaleria { get; set; } = new List<ProductoImagen>();

    public virtual Proveedore? Proveedor { get; set; }
}
