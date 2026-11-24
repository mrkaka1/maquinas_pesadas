using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class FuncionarioDAO : IDAO<Funcionario>
    {
        public void Insert(Funcionario f)
        {
            try
            {
                string sql = @"INSERT INTO funcionario (matricula, nome, cpf, cargo, dataAdmissao, email, ativo)
                    VALUES (@matricula, @nome, @cpf, @cargo, @dataAdmissao, @email, @ativo)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@matricula", f.Matricula);
                    cmd.Parameters.AddWithValue("@nome", f.Nome);
                    cmd.Parameters.AddWithValue("@cpf", f.Cpf);
                    cmd.Parameters.AddWithValue("@cargo", f.Cargo);
                    cmd.Parameters.Add("@dataAdmissao", MySqlDbType.Date).Value = f.DataAdmissao.ToDateTime(TimeOnly.MinValue);
                    cmd.Parameters.AddWithValue("@email", f.Email);
                    cmd.Parameters.AddWithValue("@ativo", f.Ativo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Funcionario f)
        {
            try
            {
                string sql = @"UPDATE funcionario SET matricula = @matricula, nome = @nome, cpf = @cpf, cargo = @cargo,
                    dataAdmissao = @dataAdmissao, email = @email, ativo = @ativo
                    WHERE funcionarioID = @funcionarioID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@matricula", f.Matricula);
                    cmd.Parameters.AddWithValue("@nome", f.Nome);
                    cmd.Parameters.AddWithValue("@cpf", f.Cpf);
                    cmd.Parameters.AddWithValue("@cargo", f.Cargo);
                    cmd.Parameters.Add("@dataAdmissao", MySqlDbType.Date).Value = f.DataAdmissao.ToDateTime(TimeOnly.MinValue);
                    cmd.Parameters.AddWithValue("@email", f.Email);
                    cmd.Parameters.AddWithValue("@ativo", f.Ativo);
                    cmd.Parameters.AddWithValue("@funcionarioID", f.FuncionarioID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum funcionário foi atualizado (verifique o ID)!");
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
                string sql = "DELETE FROM funcionario WHERE funcionarioID = @funcionarioID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@funcionarioID", id);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum funcionário encontrado com esse ID!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Funcionario> GetAll()
        {
            List<Funcionario> lista = new List<Funcionario>();

            try
            {
                string sql = "SELECT * FROM funcionario ORDER BY nome";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(LerFuncionario(dr));
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar os funcionários: {ex.Message}");
            }
        }

        public Funcionario BuscarID(int id)
        {
            try
            {
                string sql = "SELECT * FROM funcionario WHERE funcionarioID = @funcionarioID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@funcionarioID", id);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                            return LerFuncionario(dr);
                        else
                            throw new Exception("Nenhum funcionário encontrado com esse ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Funcionario LerFuncionario(MySqlDataReader dr)
        {
            Funcionario f = new Funcionario();
            f.FuncionarioID = Convert.ToInt32(dr["funcionarioID"]);
            f.Matricula = Convert.ToInt32(dr["matricula"]);
            f.Nome = dr["nome"].ToString();
            f.Cpf = dr["cpf"].ToString();
            f.Cargo = dr["cargo"].ToString();
            f.DataAdmissao = DateOnly.FromDateTime(Convert.ToDateTime(dr["dataAdmissao"]));
            f.Email = dr["email"].ToString();
            f.Ativo = Convert.ToBoolean(dr["ativo"]);
            return f;
        }
    }
}
