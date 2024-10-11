using AppCrud1.Models;
using AppCrud1.Repository.Contract;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace AppCrud1.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View(_usuarioRepository.ObterTodosUsuarios());
        }
        [HttpGet]
        public IActionResult CadastrarUsuario() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid) {
                _usuarioRepository.Cadastrar(usuario);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AtualizarUsuario(int Id) 
        {
            return View(_usuarioRepository.ObterUsuario(Id));
        }
        [HttpPost]
        public IActionResult AtualizarUsuario(Usuario usuario)
        {
            _usuarioRepository.Atualizar(usuario);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult ExcluirUsuario(int id) 
        {
            _usuarioRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DetalhesUsuario(int Id)
        {
            return View(_usuarioRepository.ObterUsuario(Id));
        }
        [HttpPost]
        public IActionResult DetalhesUsuario(Usuario usuario)
        {
            _usuarioRepository.Atualizar(usuario);

            return RedirectToAction(nameof(Index));
        }

    }
}
