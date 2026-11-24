using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class CategoriaDAO : IDAO<Categoria>
    {
        public void Insert(Categoria c)
        {
            try
            {
                string sql = "INSERT INTO categoria (descricao) VALUES (@descricao)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@descricao", c.Descricao);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Categoria c)
        {
            try
            {
                string sql = "UPDATE categoria SET descricao = @descricao WHERE categoriaID = @categoriaID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@descricao", c.Descricao);
                    cmd.Parameters.AddWithValue("@categoriaID", c.CategoriaID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhuma categoria foi atualizada (verifique o ID)!");
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
                string sql = "DELETE FROM categoria WHERE categoriaID = @categoriaID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@categoriaID", id);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhuma categoria encontrada com esse ID!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Categoria> GetAll()
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                string sql = "SELECT * FROM categoria ORDER BY descricao";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Categoria c = new Categoria()
                        {
                            CategoriaID = Convert.ToInt32(dr["categoriaID"]),
                            Descricao = dr["descricao"].ToString()
                        };
                        lista.Add(c);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar as categorias: {ex.Message}");
            }
        }

        public Categoria BuscarID(int id)
        {
            try
            {
                string sql = "SELECT * FROM categoria WHERE categoriaID = @categoriaID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@categoriaID", id);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Categoria c = new Categoria();
                            c.CategoriaID = Convert.ToInt32(dr["categoriaID"]);
                            c.Descricao = dr["descricao"].ToString();
                            return c;
                        }
                        else
                        {
                            throw new Exception("Nenhuma categoria encontrada com esse ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
