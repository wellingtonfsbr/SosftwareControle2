using Microsoft.AspNetCore.Mvc;
using SoftwareControle.Models;
using SoftwareControle.Repositories.Interfaces;

namespace SoftwareControle.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepository.AddUsuario(usuario);
                return RedirectToAction("Index", "Home"); // Redireciona após o cadastro
            }
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            Usuarios usuario = _usuarioRepository.GetUsuarioById(id);
            if (usuario != null)
            {
                _usuarioRepository.DeleteUsuario(usuario);
                // Você pode redirecionar para uma página ou exibir uma mensagem de sucesso aqui
            }
            return RedirectToAction("Index", "Home"); // Redireciona após a exclusão
        }
    }
}
