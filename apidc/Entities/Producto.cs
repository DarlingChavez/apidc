using System.ComponentModel.DataAnnotations;

namespace apidc.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
    }
}
