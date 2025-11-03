using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaPrisa.Models.Entities
{
    /// <summary>
    /// Clase para manejar las especificaciones y detalles adicionales del producto (Ingredientes, Advertencias, etc.)
    /// </summary>
    [Table("producto_detalle")]
    public class ProductoDetalle
    {
        [Key]
        public int id { get; set; }

        [Column("producto_id")]
        public int? producto_id { get; set; }

        public Producto Producto { get; set; }

        // Ejemplo de tipos: "Especificaciones", "Ingredientes", "Advertencias"
        [Column("tipo_detalle_id")]
        public int TipoDetalleId { get; set; }
        public TipoDetalle TipoDetalle { get; set; } // Propiedad de navegación

        // El contenido del detalle
        public string? valor_detalle { get; set; }

        [Column("media_url")]
        public string? MediaUrl { get; set; }

        [Column("idioma")] // Nuevo campo
        [StringLength(5)] // Para valores como 'ES', 'EN', 'PT'
        public string Idioma { get; set; } = "ES";
    }
}
