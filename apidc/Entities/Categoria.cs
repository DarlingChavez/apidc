using System.ComponentModel.DataAnnotations;

namespace apidc.Entities
{
    public class Categoria
    {

        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public virtual ICollection<Producto>? Productos { get; set; }
    }
}
