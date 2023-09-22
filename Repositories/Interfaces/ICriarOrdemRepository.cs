using SoftwareControle.Models;
using System.Collections.Generic;

namespace SoftwareControle.Repositories.Interfaces
{
    public interface ICriarOrdemRepository
    {
        IEnumerable<CriarOrdem> GetCriarOrdens();
        CriarOrdem GetCriarOrdemById(int id);
        void AddCriarOrdem(CriarOrdem criarOrdem);
        void UpdateCriarOrdem(CriarOrdem criarOrdem);
        void DeleteCriarOrdem(CriarOrdem criarOrdem);
    }
}
