using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class FornecedorDAO : IDAO<Fornecedor>
    {
        public void Insert(Fornecedor f)
        {
            try
            {
                string sql = @"INSERT INTO fornecedor (razaoSocial, cnpj, telefone, email, cidade, uf)
                    VALUES (@razaoSocial, @cnpj, @telefone, @email, @cidade, @uf)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@razaoSocial", f.Razao);
                    cmd.Parameters.AddWithValue("@cnpj", f.CNPJ);
                    cmd.Parameters.AddWithValue("@telefone", f.Telefone);
                    cmd.Parameters.AddWithValue("@email", f.Email);
                    cmd.Parameters.AddWithValue("@cidade", f.Cidade);
                    cmd.Parameters.AddWithValue("@uf", f.UF);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Fornecedor f)
        {
            try
            {
                string sql = @"UPDATE fornecedor SET razaoSocial = @razaoSocial, cnpj = @cnpj, telefone = @telefone,
                    email = @email, cidade = @cidade, uf = @uf
                    WHERE fornecedorID = @fornecedorID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@razaoSocial", f.Razao);
                    cmd.Parameters.AddWithValue("@cnpj", f.CNPJ);
                    cmd.Parameters.AddWithValue("@telefone", f.Telefone);
                    cmd.Parameters.AddWithValue("@email", f.Email);
                    cmd.Parameters.AddWithValue("@cidade", f.Cidade);
                    cmd.Parameters.AddWithValue("@uf", f.UF);
                    cmd.Parameters.AddWithValue("@fornecedorID", f.FornecedorID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum fornecedor foi atualizado (verifique o ID)!");
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
                string sql = "DELETE FROM fornecedor WHERE fornecedorID = @fornecedorID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@fornecedorID", id);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum fornecedor encontrado com esse ID!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Fornecedor> GetAll()
        {
            List<Fornecedor> lista = new List<Fornecedor>();

            try
            {
                string sql = "SELECT * FROM fornecedor ORDER BY razaoSocial";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(LerFornecedor(dr));
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar os fornecedores: {ex.Message}");
            }
        }

        public Fornecedor BuscarID(int id)
        {
            try
            {
                string sql = "SELECT * FROM fornecedor WHERE fornecedorID = @fornecedorID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@fornecedorID", id);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                            return LerFornecedor(dr);
                        else
                            throw new Exception("Nenhum fornecedor encontrado com esse ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Fornecedor LerFornecedor(MySqlDataReader dr)
        {
            Fornecedor f = new Fornecedor();
            f.FornecedorID = Convert.ToInt32(dr["fornecedorID"]);
            f.Razao = dr["razaoSocial"].ToString();
            f.CNPJ = dr["cnpj"].ToString();
            f.Telefone = dr["telefone"].ToString();
            f.Email = dr["email"].ToString();
            f.Cidade = dr["cidade"].ToString();
            f.UF = dr["uf"].ToString();
            return f;
        }
    }
}
