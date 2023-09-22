using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareControle.Models

{

    [Table("Ferramentas")]
    public class Ferramenta
    {
        [Key]
        public int FerramentaId { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [Display(Name = "Nome da Ferramenta")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [Display(Name ="Descrição da Ferramenta")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public bool Disponivel { get; set; }

        public byte[] Imagem { get; set; }

        public List<CriarOrdem> CriarOrdens { get; set; } = new List<CriarOrdem>();

    }
}
