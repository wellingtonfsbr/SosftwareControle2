using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareControle.Models
{

    [Table("CriarOrdem")]
    public class CriarOrdem
    {
        [Key]
        public int CriarOrdemId { get; set; }
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        [Display(Name = "ID da ferramenta Ferramenta")]
        public int FerramentaId { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        [Display(Name = "Ações a ser realizadas")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [Display(Name = "Data de Inicio")]
        public DateTime DataCriacao { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [Display(Name = "Prazo Maximo a ser feita")]
        public DateTime PrazoMaximo { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public int NivelUrgencia { get; set; }

        public Usuarios Usuario { get; set; }
   
        public Ferramenta Ferramenta { get; set; }
        public List<OrdensFeitas> OrdensFeitas { get; set; } = new List<OrdensFeitas>();
    }
}