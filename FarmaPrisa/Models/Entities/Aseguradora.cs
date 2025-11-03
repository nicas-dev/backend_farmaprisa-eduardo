using System;
using System.Collections.Generic;

namespace FarmaPrisa.Models.Entities;

/// <summary>
/// Tabla para gestionar las aseguradoras, contendrá la lista de todas las compañías de seguros con las que la farmacia tiene convenio
/// </summary>
public partial class Aseguradora
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? ContactoEmail { get; set; }

    public string? ContactoTelefono { get; set; }

    public bool? EstaActiva { get; set; }

    public virtual ICollection<UsuarioAseguradora> UsuarioAseguradoras { get; set; } = new List<UsuarioAseguradora>();
}
