using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class ClienteDAO : IDAO<Cliente>
    {
        public void Insert(Cliente c)
        {
            try
            {
                string sql = @"INSERT INTO cliente (nome, cpfCnpj, tipoPessoa, telefone, email, cidade, uf, dataCadastro)
                    VALUES (@nome, @cpfCnpj, @tipoPessoa, @telefone, @email, @cidade, @uf, @dataCadastro)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", c.Nome);
                    cmd.Parameters.AddWithValue("@cpfCnpj", c.CpfCnpj);
                    cmd.Parameters.AddWithValue("@tipoPessoa", c.TipoPessoa);
                    cmd.Parameters.AddWithValue("@telefone", c.Telefone);
                    cmd.Parameters.AddWithValue("@email", c.Email);
                    cmd.Parameters.AddWithValue("@cidade", c.Cidade);
                    cmd.Parameters.AddWithValue("@uf", c.UF);
                    cmd.Parameters.Add("@dataCadastro", MySqlDbType.Date).Value = c.DataCadastro.ToDateTime(TimeOnly.MinValue);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int clienteID)
        {
            try
            {
                string sql = "DELETE FROM cliente WHERE clienteID = @clienteID;";
                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteID", clienteID);
                    var linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                        throw new Exception("Nenhum registro encontrado com esse ID!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Cliente c)
        {
            try
            {
                string sql = @"UPDATE cliente SET nome = @nome, cpfCnpj = @cpfCnpj, tipoPessoa = @tipoPessoa, telefone = @telefone, email = @email, cidade = @cidade, uf = @uf, dataCadastro = @dataCadastro
                    WHERE clienteID = @clienteID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", c.Nome);
                    cmd.Parameters.AddWithValue("@cpfCnpj", c.CpfCnpj);
                    cmd.Parameters.AddWithValue("@tipoPessoa", c.TipoPessoa);
                    cmd.Parameters.AddWithValue("@telefone", c.Telefone);
                    cmd.Parameters.AddWithValue("@email", c.Email);
                    cmd.Parameters.AddWithValue("@cidade", c.Cidade);
                    cmd.Parameters.AddWithValue("@uf", c.UF);
                    cmd.Parameters.Add("@dataCadastro", MySqlDbType.Date).Value = c.DataCadastro.ToDateTime(TimeOnly.MinValue);
                    cmd.Parameters.AddWithValue("@clienteID", c.ClienteID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o clienteID)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Cliente> GetAll()

        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                string sql = @"SELECT * FROM cliente ORDER BY nome";

                using(var conexao = Conexao.Conectar())
                    using(var comando = new MySqlCommand(sql, conexao))
                        using(MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Cliente c = new Cliente()
                        {
                            ClienteID = Convert.ToInt32(dr["clienteID"]),
                            Nome = dr["nome"].ToString(),
                            CpfCnpj = dr["cpfCnpj"].ToString(),
                            TipoPessoa = dr["tipoPessoa"].ToString(),
                            Telefone = dr["telefone"].ToString(),
                            Email = dr["email"].ToString(),
                            Cidade = dr["cidade"].ToString(),
                            UF = dr["uf"].ToString(),
                            DataCadastro = DateOnly.FromDateTime(Convert.ToDateTime(dr["dataCadastro"]))
                        };
                        clientes.Add(c);
                    }
                }
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar os clientes: {ex.Message}");
            }
        }

        public Cliente BuscarID(int clienteID)
        {
            try
            {
                string sql = @"SELECT * FROM cliente WHERE clienteID = @clienteID";

                using (var conexao = Conexao.Conectar())
                    using(var cmd =  new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteID", clienteID);

                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Cliente c = new Cliente();

                            c.ClienteID = Convert.ToInt32(dr["clienteID"]);
                            c.Nome = dr["nome"].ToString();
                            c.CpfCnpj = dr["cpfCnpj"].ToString();
                            c.TipoPessoa = dr["tipoPessoa"].ToString();
                            c.Telefone = dr["telefone"].ToString();
                            c.Email = dr["email"].ToString();
                            c.Cidade = dr["cidade"].ToString();
                            c.UF = dr["uf"].ToString();
                            c.DataCadastro = DateOnly.FromDateTime(Convert.ToDateTime(dr["dataCadastro"]));

                            return c;
                        }
                        else
                        {
                            throw new Exception("Nenhum cliente encontrado com esse ID.");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
