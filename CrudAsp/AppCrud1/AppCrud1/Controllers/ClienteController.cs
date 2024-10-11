using AppCrud1.Models;
using AppCrud1.Repository;
using AppCrud1.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AppCrud1.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;

        public ClienteController (IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index()
        {
            return View(_clienteRepository.ObterTodosClientes());
        }
        [HttpGet]
        public IActionResult CadastrarCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente) {
            if (ModelState.IsValid) {
                _clienteRepository.cadastrar(cliente);
            }
            return View(); 
        }

        [HttpGet]
        public IActionResult AtualizarCliente(int Id) 
        {
            return View(_clienteRepository.obterCliente(Id));
        }
        [HttpPost]
        public IActionResult AtualizarCliente(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult ExcluirCliente(int id)
        {
            _clienteRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DetalhesCliente(int Id)
        {
            return View(_clienteRepository.obterCliente(Id));
        }
        [HttpPost]
        public IActionResult DetalhesCliente(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);

            return RedirectToAction(nameof(Index));
        }
    }
}
