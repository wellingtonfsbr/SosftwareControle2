using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareControle.Models
{

    [Table("OrdensFeitas")]
    public class OrdensFeitas
    {
        [Key]
        public int OrdensFeitasId { get; set; }
        public int UsuarioId { get; set; }
        public int FerramentaId { get; set; }
        public int CriarOrdemId { get; set; }
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Descricao { get; set; }

        public Usuarios Usuario { get; set; }
        public Ferramenta Ferramenta { get; set; }
        public CriarOrdem CriarOrdem { get; set; }

    }
}
