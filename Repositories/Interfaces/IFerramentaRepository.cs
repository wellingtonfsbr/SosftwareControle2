using SoftwareControle.Models;
using System.Collections.Generic;


namespace SoftwareControle.Repositories.Interfaces
{
    public interface IFerramentaRepository
    {

        IEnumerable<Ferramenta> GetFerramentas();
        Ferramenta GetFerramentaById(int id);
         void AddFerramenta(Ferramenta ferramenta, byte[] imagem);
         void UpdateFerramenta(Ferramenta ferramenta, byte[] imagem);
         void DeleteFerramenta(Ferramenta ferramenta);
       
    }
}
