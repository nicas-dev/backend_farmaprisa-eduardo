namespace FarmaPrisa.Models.Entities
{
    public class TipoDetalle
    {
        public int Id { get; set; }
        public string Nombre { get; set; } // Nombre para el administrador (Ej: "Ingredientes")
        public string IdentificadorUnico { get; set; } // Clave usada por el Front (Ej: "INGREDIENTS")
        public string? Descripcion { get; set; } // Descripción para el admin
        public bool EstaActivo { get; set; } // Para habilitar/deshabilitar tipos

        // Propiedad de navegación inversa (opcional)
        public ICollection<ProductoDetalle> ProductoDetalles { get; set; }
    }
}
