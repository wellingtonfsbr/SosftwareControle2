using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareControle.Models
{
    [Table("Admnistradores")]
    public class Administrador
    {
        [Key]   
        public int AdministradorId { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuarios Usuario { get; set; }

    }
}
