using Microsoft.AspNetCore.Mvc;
using SoftwareControle.Context;
using SoftwareControle.Models;
using SoftwareControle.Repositories;
using SoftwareControle.Repositories.Interfaces;

namespace SoftwareControle.Controllers
{
    public class CriarOrdemController : Controller
    {
        private readonly ICriarOrdemRepository _criarOrdemRepository;
        private readonly IFerramentaRepository _ferramentaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly AppDbContext _dbContext;
        public CriarOrdemController(ICriarOrdemRepository criarOrdemRepository, IFerramentaRepository ferramentaRepository, IUsuarioRepository usuarioRepository, AppDbContext dbContext)
        {
            _criarOrdemRepository = criarOrdemRepository;
            _ferramentaRepository = ferramentaRepository;
            _usuarioRepository = usuarioRepository;
            _dbContext = dbContext;
        }
        private bool VerificarExistenciaFerramenta(int ferramentaId)
        {
            return _dbContext.Ferramentas.Any(f => f.FerramentaId == ferramentaId);
        }

        public IActionResult Index()
        {
            var ordens = _criarOrdemRepository.GetCriarOrdens();
            return View(ordens);
        }


        public IActionResult Detalhes(int id)
        {
            var ordem = _criarOrdemRepository.GetCriarOrdemById(id);
            if (ordem == null)
            {
                return NotFound();
            }
            return View(ordem);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(CriarOrdem criarOrdem)
        {
            if (ModelState.IsValid)
            {

                var ferramenta = _ferramentaRepository.GetFerramentaById(criarOrdem.FerramentaId);
                if (ferramenta == null)
                {
                    ModelState.AddModelError("FerramentaId", "A ferramenta não foi encontrada no banco de dados.");
                    return View(criarOrdem);
                }


                _criarOrdemRepository.AddCriarOrdem(criarOrdem);
                return RedirectToAction("Index");
            }
            return View(criarOrdem);
        }

        public IActionResult Editar(int id)
        {
            var ordem = _criarOrdemRepository.GetCriarOrdemById(id);
            if (ordem == null)
            {
                return NotFound();
            }
            return View(ordem);
        }

        [HttpPost]
        public IActionResult Editar(CriarOrdem criarOrdem)
        {
            if (ModelState.IsValid)
            {
                _criarOrdemRepository.UpdateCriarOrdem(criarOrdem);
                return RedirectToAction("Index");
            }
            return View(criarOrdem);
        }

        public IActionResult Excluir(int id)
        {
            var ordem = _criarOrdemRepository.GetCriarOrdemById(id);
            if (ordem == null)
            {
                return NotFound();
            }
            return View(ordem);
        }

        [HttpPost, ActionName("Excluir")]
        public IActionResult ConfirmarExclusao(int id)
        {
            var ordem = _criarOrdemRepository.GetCriarOrdemById(id);
            if (ordem == null)
            {
                return NotFound();
            }
            _criarOrdemRepository.DeleteCriarOrdem(ordem);
            return RedirectToAction("Index");
        }
    }
}
