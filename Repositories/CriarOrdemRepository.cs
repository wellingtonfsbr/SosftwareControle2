using SoftwareControle.Context;
using SoftwareControle.Models;
using SoftwareControle.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareControle.Repositories
{
    public class CriarOrdemRepository : ICriarOrdemRepository
    {
        private readonly AppDbContext _dbContext;

        public CriarOrdemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CriarOrdem> GetCriarOrdens()
        {
            return _dbContext.CriarOrdens.ToList();
        }

        public CriarOrdem GetCriarOrdemById(int id)
        {
            return _dbContext.CriarOrdens.FirstOrDefault(o => o.CriarOrdemId == id);
        }

        public void AddCriarOrdem(CriarOrdem criarOrdem)
        {
            _dbContext.CriarOrdens.Add(criarOrdem);
            _dbContext.SaveChanges();
        }

        public void UpdateCriarOrdem(CriarOrdem criarOrdem)
        {
            _dbContext.CriarOrdens.Update(criarOrdem);
            _dbContext.SaveChanges();
        }

        public void DeleteCriarOrdem(CriarOrdem criarOrdem)
        {
            _dbContext.CriarOrdens.Remove(criarOrdem);
            _dbContext.SaveChanges();
        }
    }
}
