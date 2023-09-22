using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareControle.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage ="Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Senha { get; set; }
        public bool IsAdministrador { get; set; }


        public List<CriarOrdem> CriarOrdens { get; set; } = new List<CriarOrdem>();
        public List<OrdensFeitas> OrdensFeitas { get; set; } = new List<OrdensFeitas>();
   
    
    }
}
