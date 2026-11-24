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

        public void Deletar(int funcionarioID)
        {
            try
            {
                string sql = "DELETE FROM funcionario WHERE funcionarioID = @funcionarioID;";
                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@funcionarioID", funcionarioID);
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

        public void Atualizar(Funcionario f)
        {
            try
            {
                string sql = @"UPDATE funcionario SET matricula = @matricula, nome = @nome, cpf = @cpf, cargo = @cargo, dataAdmissao = @dataAdmissao, email = @email, ativo = @ativo
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
                        throw new Exception("Nenhum registro foi atualizado (verifique o funcionarioID)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Funcionario> GetAll()

        {
            List<Funcionario> func = new List<Funcionario>();

            try
            {
                string sql = @"SELECT * FROM funcionario ORDER BY nome";

                using(var conexao = Conexao.Conectar())
                    using(var comando = new MySqlCommand(sql, conexao))
                        using(MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Funcionario f = new Funcionario()
                        {
                            FuncionarioID = Convert.ToInt32(dr["funcionarioID"]),
                            Matricula = Convert.ToInt32(dr["matricula"]),
                            Nome = dr["nome"].ToString(),
                            Cpf = dr["cpf"].ToString(),
                            Cargo = dr["cargo"].ToString(),
                            DataAdmissao = DateOnly.FromDateTime(Convert.ToDateTime(dr["dataAdmissao"])),
                            Email = dr["email"].ToString(),
                            Ativo = Convert.ToBoolean(dr["ativo"])
                        };
                        func.Add(f);
                    }
                }
                return func;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar os funcionários: {ex.Message}");
            }
        }

        public Funcionario BuscarID(int funcionarioID)
        {
            try
            {
                string sql = @"SELECT * FROM funcionario WHERE funcionarioID = @funcionarioID";

                using (var conexao = Conexao.Conectar())
                    using(var cmd =  new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@funcionarioID", funcionarioID);

                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
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
                        else
                        {
                            throw new Exception("Nenhum funcionário encontrado com esse ID.");
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
