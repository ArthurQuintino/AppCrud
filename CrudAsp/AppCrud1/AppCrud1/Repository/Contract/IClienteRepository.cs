using AppCrud1.Models;

namespace AppCrud1.Repository.Contract
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ObterTodosClientes();

        void cadastrar(Cliente cliente);

        void Atualizar(Cliente cliente);

        Cliente obterCliente(int Id);

        void Excluir(int Id);
    }
}
