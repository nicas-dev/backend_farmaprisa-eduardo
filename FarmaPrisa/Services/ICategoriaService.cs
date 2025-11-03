using FarmaPrisa.Data;
using FarmaPrisa.Models.Dtos.Categoria;
using FarmaPrisa.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmaPrisa.Services
{
    public interface ICategoriaService
    {
        Task<CategoriaDto> CreateCategoriaAsync(CategoriaCreateUpdateDto dto);
        Task<IEnumerable<CategoriaDto>> GetCategoriasJerarquiaAsync();
        Task<bool> UpdateCategoriaAsync(int id, CategoriaCreateUpdateDto dto);
    }
    public class CategoriaService : ICategoriaService
    {
        private readonly FarmaPrisaContext _context;

        public CategoriaService(FarmaPrisaContext context)
        {
            _context = context;
        }

        public async Task<CategoriaDto> CreateCategoriaAsync(CategoriaCreateUpdateDto dto)
        {
            var nuevaCategoria = new Categoria
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                CategoriaPadreId = dto.CategoriaPadreId
            };

            _context.Categorias.Add(nuevaCategoria);
            await _context.SaveChangesAsync();

            // Mapeamos la entidad guardada al DTO y la devolvemos
            var categoriaDto = new CategoriaDto
            {
                Id = nuevaCategoria.Id,
                Nombre = nuevaCategoria.Nombre,
                Descripcion = nuevaCategoria.Descripcion,
                CategoriaPadreId = nuevaCategoria.CategoriaPadreId,
                // Subcategorias será null, ya que se acaba de crear
                Subcategorias = null
            };

            return categoriaDto;
        }

        public async Task<IEnumerable<CategoriaDto>> GetCategoriasJerarquiaAsync()
        {
            // Carga todas las categorías a la vez para evitar múltiples consultas a la BD
            var todasCategorias = await _context.Categorias.ToListAsync();

            // Mapeamos todas las entidades a DTOs
            var categoriaDtos = todasCategorias.Select(c => new CategoriaDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                CategoriaPadreId = c.CategoriaPadreId,
                Subcategorias = new List<CategoriaDto>() // Inicializamos la lista de hijos
            }).ToList();

            // Estructura para búsqueda rápida
            var diccionario = categoriaDtos.ToDictionary(c => c.Id);
            var categoriasRaiz = new List<CategoriaDto>();

            // Construimos la jerarquía
            foreach (var dto in categoriaDtos)
            {
                if (dto.CategoriaPadreId.HasValue && diccionario.ContainsKey(dto.CategoriaPadreId.Value))
                {
                    // Es una subcategoría: la añadimos a la lista de hijos de su padre
                    diccionario[dto.CategoriaPadreId.Value].Subcategorias.Add(dto);
                }
                else
                {
                    // Es una categoría raíz o su padre no existe: la añadimos a la lista principal
                    categoriasRaiz.Add(dto);
                }
            }

            return categoriasRaiz;
        }

        public async Task<bool> UpdateCategoriaAsync(int id, CategoriaCreateUpdateDto dto)
        {
            var categoriaAActualizar = await _context.Categorias
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoriaAActualizar == null)
            {
                return false; // Categoría no encontrada
            }

            // Aplicar solo los cambios que se envían en el DTO
            if (!string.IsNullOrEmpty(dto.Nombre))
            {
                categoriaAActualizar.Nombre = dto.Nombre;
            }

            // La descripción puede ser vacía o nula, lo validamos si se envió
            if (dto.Descripcion != null)
            {
                categoriaAActualizar.Descripcion = dto.Descripcion;
            }

            // El CategoriaPadreId puede ser null (cambiar a categoría principal) o un ID
            if (dto.CategoriaPadreId.HasValue)
            {
                // Si el ID del padre es 0, lo tratamos como NULL (categoría raíz)
                categoriaAActualizar.CategoriaPadreId = (dto.CategoriaPadreId.Value == 0)
                                                       ? null
                                                       : dto.CategoriaPadreId.Value;
            }
            else if (dto.CategoriaPadreId == null && categoriaAActualizar.CategoriaPadreId.HasValue)
            {
                // Si se envía NULL explícitamente y antes tenía un padre, lo eliminamos
                categoriaAActualizar.CategoriaPadreId = null;
            }

            // Guardar cambios
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
