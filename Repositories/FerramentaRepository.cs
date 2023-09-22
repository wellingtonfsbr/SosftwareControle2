using SoftwareControle.Context;
using SoftwareControle.Models;
using SoftwareControle.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareControle.Repositories
{
    public class FerramentaRepository : IFerramentaRepository
    {
        private readonly AppDbContext _context;

        public FerramentaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ferramenta> GetFerramentas()
        {
            return _context.Ferramentas.ToList();
        }

        public Ferramenta GetFerramentaById(int id)
        {
            return _context.Ferramentas.FirstOrDefault(f => f.FerramentaId == id);
        }

        public void AddFerramenta(Ferramenta ferramenta, byte[] imagem)
        {
            ferramenta.Imagem = imagem;
            _context.Ferramentas.Add(ferramenta);
            _context.SaveChanges();
        }

        public void UpdateFerramenta(Ferramenta ferramenta, byte[] imagem)
        {
            ferramenta.Imagem = imagem;
            _context.Ferramentas.Update(ferramenta);
            _context.SaveChanges();
        }

        public void DeleteFerramenta(Ferramenta ferramenta)
        {
             
            _context.Ferramentas.Remove(ferramenta);
            _context.SaveChanges();
        }


       


      
    }

}
