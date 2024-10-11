using AppCrud1.Models;
using AppCrud1.Repository.Contract;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System.Data;

namespace AppCrud1.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _conexaoMySQL;

        public UsuarioRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Usuario usuario)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL)) {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Update usuario set nomeUsu=@nomeUsu, Cargo=@Cargo, " +
                                                    " DataNasc=@DataNasc Where IdUsu=@IdUsu;", conexao);


                cmd.Parameters.Add("@nomeUsu", MySqlDbType.VarChar).Value = usuario.nomeUsu;
                cmd.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = usuario.Cargo;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = usuario.DataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@IdUsu", MySqlDbType.VarChar).Value = usuario.IdUsu;

                cmd.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public void Cadastrar(Usuario usuario)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Insert into usuario(nomeUsu, Cargo, dataNasc)" +
                                                             " values(@nomeUsu, @Cargo, @DataNasc)", conexao);

                cmd.Parameters.Add("@nomeUsu", MySqlDbType.VarChar).Value = usuario.nomeUsu;
                cmd.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = usuario.Cargo;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = usuario.DataNasc.ToString("yyyy/MM/dd");

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from usuario where IdUsu=@IdUsu", conexao);
                cmd.Parameters.AddWithValue("@IdUsu", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            List<Usuario> UsuarioList = new List<Usuario>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {

                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from usuario", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    UsuarioList.Add(
                        new Usuario
                        {
                            IdUsu = Convert.ToInt32(dr["IdUsu"]),
                            nomeUsu = (string)dr["nomeUsu"],
                            Cargo = (string)dr["Cargo"],
                            DataNasc = Convert.ToDateTime(dr["DataNasc"])
                        });
                }
                return UsuarioList;


            }
        }

        public Usuario ObterUsuario(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL)) {

                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * from usuario " +
                                                    " where IdUsu=@IdUsu", conexao);

                cmd.Parameters.AddWithValue("@IdUsu", Id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                Usuario usuario = new Usuario();

                while (dr.Read()) 
                {

                    usuario.IdUsu = Convert.ToInt32(dr["IdUsu"]);
                    usuario.nomeUsu = (string)dr["nomeUsu"];
                    usuario.Cargo = (string)dr["Cargo"];
                    usuario.DataNasc = Convert.ToDateTime(dr["DataNasc"]);
                }
                return usuario;

            }

        }
    }
}
