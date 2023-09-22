using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareControle.Models
{
    [Table("Relatorios")]
    public class Relatorio
    {
        [Key]
        public int RelatorioId { get; set; }
        public List<OrdensFeitas> OrdensFeitas { get; set; } = new List<OrdensFeitas>();
        public List<CriarOrdem> CriarOrdens { get; set; } = new List<CriarOrdem>();
        public List<Ferramenta> Ferramentas { get; set; } = new List<Ferramenta>();
        public List<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
        public List<Administrador> Administradores { get; set; } = new List<Administrador>();
   
    
    }
}
