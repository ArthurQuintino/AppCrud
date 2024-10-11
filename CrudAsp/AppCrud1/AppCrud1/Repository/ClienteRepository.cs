using AppCrud1.Models;
using AppCrud1.Repository.Contract;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Data;

namespace AppCrud1.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _conexaoMySQL;

        public ClienteRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Update cliente set nomeCli=@nomeCli, emailCli=@emailCli, " +
                                                    " teleCli=@teleCli, endCli=@endCli Where IdCli=@IdCli;", conexao);


                cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = cliente.nomeCli;
                cmd.Parameters.Add("@emailCli", MySqlDbType.VarChar).Value = cliente.emailCli   ;
                cmd.Parameters.Add("@teleCli", MySqlDbType.VarChar).Value = cliente.teleCli;
                cmd.Parameters.Add("@endCli", MySqlDbType.VarChar).Value = cliente.endCli;
                cmd.Parameters.Add("@IdCli", MySqlDbType.VarChar).Value = cliente.IdCli;

                cmd.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public void cadastrar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL)) 
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into cliente(nomeCli, emailCli, teleCli, endCli) " +
                                                     "values(@nomeCli, @emailCli, @TeleCli, @EndCli)", conexao);


                cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = cliente.nomeCli;
                cmd.Parameters.Add("@emailCli", MySqlDbType.VarChar).Value = cliente.emailCli;
                cmd.Parameters.Add("@teleCli", MySqlDbType.VarChar).Value = cliente.teleCli;
                cmd.Parameters.Add("@endCli", MySqlDbType.VarChar).Value = cliente.endCli;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from cliente where IdCli=@IdCli", conexao);
                cmd.Parameters.AddWithValue("@IdCli", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Cliente obterCliente(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL)) 
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM cliente " + 
                                                    " WHERE IdCli=@IdCli", conexao);

                cmd.Parameters.AddWithValue("@IdCli", Id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                Cliente cliente = new Cliente();

                while (dr.Read())
                {
                    cliente.IdCli = Convert.ToInt32(dr["IdCli"]);
                    cliente.nomeCli = (string)dr["nomeCli"];
                    cliente.emailCli = (string)dr["emailCli"];
                    cliente.teleCli = Convert.ToInt64(dr["teleCli"]);
                    cliente.endCli = (string)dr["endCli"];
                }
                return cliente;
            }
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
           List<Cliente> ClienteList = new List<Cliente>();
            using (var conexao = new MySqlConnection(_conexaoMySQL)) {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from cliente", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Clone();

                foreach (DataRow dr in dt.Rows) 
                {
                    ClienteList.Add
                      (
                       new Cliente
                       {
                           IdCli = Convert.ToInt32(dr["IdCli"]),
                           nomeCli = (string)dr["nomeCli"],
                           emailCli = (string)dr["emailCli"],
                           teleCli = Convert.ToInt64(dr["teleCli"]),
                           endCli = (string)dr["endCli"]
                       }

                      );
                }
                return ClienteList;

            }
        }
    }
}
