using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class ModeloDAO : IDAO<Modelo>
    {
        public void Insert(Modelo m)
        {
            try
            {
                string sql = @"INSERT INTO modelo (nome, tipo, potenciaCV, FK_marcaID)
                    VALUES (@nome, @tipo, @potenciaCV, @FK_marcaID)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", m.Nome);
                    cmd.Parameters.AddWithValue("@tipo", m.Tipo);
                    cmd.Parameters.AddWithValue("@potenciaCV", m.PotenciaCV);
                    cmd.Parameters.AddWithValue("@FK_marcaID", m.Marca.MarcaID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int modeloID)
        {
            try
            {
                string sql = "DELETE FROM modelo WHERE modeloID = @modeloID;";
                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@modeloID", modeloID);
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

        public void Atualizar(Modelo m)
        {
            try
            {
                string sql = @"UPDATE modelo SET nome = @nome, tipo = @tipo, potenciaCV = @potenciaCV, FK_marcaID = @FK_marcaID
                    WHERE modeloID = @modeloID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", m.Nome);
                    cmd.Parameters.AddWithValue("@tipo", m.Tipo);
                    cmd.Parameters.AddWithValue("@potenciaCV", m.PotenciaCV);
                    cmd.Parameters.AddWithValue("@FK_marcaID", m.Marca.MarcaID);
                    cmd.Parameters.AddWithValue("@modeloID", m.ModeloID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o modeloID)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Modelo> GetAll()

        {
            List<Modelo> modelos = new List<Modelo>();

            try
            {
                string sql = @"SELECT * FROM modelo ORDER BY nome";

                using(var conexao = Conexao.Conectar())
                    using(var comando = new MySqlCommand(sql, conexao))
                        using(MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Modelo m = new Modelo()
                        {
                            ModeloID = Convert.ToInt32(dr["modeloID"]),
                            Nome = dr["nome"].ToString(),
                            Tipo = dr["tipo"].ToString(),
                            PotenciaCV = Convert.ToInt32(dr["potenciaCV"]),
                            Marca = new Marca()
                            {
                                MarcaID = Convert.ToInt32(dr["FK_marcaID"])
                            }
                        };
                        modelos.Add(m);
                    }
                }
                return modelos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar os modelos: {ex.Message}");
            }
        }

        public Modelo BuscarID(int modeloID)
        {
            try
            {
                string sql = @"SELECT * FROM modelo WHERE modeloID = @modeloID";

                using (var conexao = Conexao.Conectar())
                    using(var cmd =  new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@modeloID", modeloID);

                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Modelo m = new Modelo();

                            m.ModeloID = Convert.ToInt32(dr["modeloID"]);
                            m.Nome = dr["nome"].ToString();
                            m.Tipo = dr["tipo"].ToString();
                            m.PotenciaCV = Convert.ToInt32(dr["potenciaCV"]);
                            m.Marca = new Marca()
                            {
                                MarcaID = Convert.ToInt32(dr["FK_marcaID"])
                            };

                            return m;
                        }
                        else
                        {
                            throw new Exception("Nenhum modelo encontrado com esse ID.");
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
