using SoftwareControle.Models;
using System.Collections.Generic;

namespace SoftwareControle.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuarios GetUsuarioById(int id);
        Usuarios GetUsuarioByLoginSenha(string login, string senha);
        List<Usuarios> GetAllUsuarios();
        void AddUsuario(Usuarios usuario);
        void UpdateUsuario(Usuarios usuario);
        void DeleteUsuario(Usuarios usuario);
        bool IsAdministrador(int usuarioId);
    }
}
