using Microsoft.EntityFrameworkCore;
using SoftwareControle.Context;
using SoftwareControle.Models;
using SoftwareControle.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareControle.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public Usuarios GetUsuarioById(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        }

        public Usuarios GetUsuarioByLoginSenha(string login, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Login == login && u.Senha == senha);
        }

        public List<Usuarios> GetAllUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public void AddUsuario(Usuarios usuario)
        {
            if (_context.Entry(usuario).State == EntityState.Detached)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
        }


        public void UpdateUsuario(Usuarios usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUsuario(Usuarios usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public bool IsAdministrador(int usuarioId)
        {
            return _context.Usuarios.Any(u => u.UsuarioId == usuarioId && u.IsAdministrador);
        }
    }
}
