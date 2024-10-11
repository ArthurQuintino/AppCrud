using AppCrud1.Models;

namespace AppCrud1.Repository.Contract
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> ObterTodosUsuarios();

        void Cadastrar(Usuario usuario);

        void Atualizar(Usuario usuario);

        Usuario ObterUsuario(int Id);

        void Excluir(int Id);
    }
}
