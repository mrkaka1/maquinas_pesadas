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
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new Exception("Já existe um cliente cadastrado com esse CPF/CNPJ!");
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
                string sql = @"UPDATE cliente SET nome = @nome, cpfCnpj = @cpfCnpj, tipoPessoa = @tipoPessoa,
                    telefone = @telefone, email = @email, cidade = @cidade, uf = @uf, dataCadastro = @dataCadastro
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
                        throw new Exception("Nenhum cliente foi atualizado (verifique o ID)!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int id)
        {
            try
            {
                string sql = "DELETE FROM cliente WHERE clienteID = @clienteID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteID", id);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum cliente encontrado com esse ID!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Cliente> GetAll()
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                string sql = "SELECT * FROM cliente ORDER BY nome";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(LerCliente(dr));
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar os clientes: {ex.Message}");
            }
        }

        public Cliente BuscarID(int id)
        {
            try
            {
                string sql = "SELECT * FROM cliente WHERE clienteID = @clienteID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@clienteID", id);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                            return LerCliente(dr);
                        else
                            throw new Exception("Nenhum cliente encontrado com esse ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Cliente LerCliente(MySqlDataReader dr)
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
    }
}
