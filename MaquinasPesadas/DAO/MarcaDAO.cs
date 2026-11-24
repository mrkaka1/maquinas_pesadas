using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class MarcaDAO : IDAO<Marca>
    {
        public void Insert(Marca m)
        {
            try
            {
                string sql = @"INSERT INTO marca (nome, paisOrigem)
                    VALUES (@nome, @paisOrigem)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", m.Nome);
                    cmd.Parameters.AddWithValue("@paisOrigem", m.PaisOrigem);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Marca m)
        {
            try
            {
                string sql = @"UPDATE marca SET nome = @nome, paisOrigem = @paisOrigem
                    WHERE marcaID = @marcaID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", m.Nome);
                    cmd.Parameters.AddWithValue("@paisOrigem", m.PaisOrigem);
                    cmd.Parameters.AddWithValue("@marcaID", m.MarcaID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhuma marca foi atualizada (verifique o ID)!");
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
                string sql = "DELETE FROM marca WHERE marcaID = @marcaID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@marcaID", id);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhuma marca encontrada com esse ID!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Marca> GetAll()
        {
            List<Marca> lista = new List<Marca>();

            try
            {
                string sql = "SELECT * FROM marca ORDER BY nome";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Marca m = new Marca()
                        {
                            MarcaID = Convert.ToInt32(dr["marcaID"]),
                            Nome = dr["nome"].ToString(),
                            PaisOrigem = dr["paisOrigem"].ToString()
                        };
                        lista.Add(m);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar as marcas: {ex.Message}");
            }
        }

        public Marca BuscarID(int id)
        {
            try
            {
                string sql = "SELECT * FROM marca WHERE marcaID = @marcaID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@marcaID", id);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Marca m = new Marca();
                            m.MarcaID = Convert.ToInt32(dr["marcaID"]);
                            m.Nome = dr["nome"].ToString();
                            m.PaisOrigem = dr["paisOrigem"].ToString();
                            return m;
                        }
                        else
                        {
                            throw new Exception("Nenhuma marca encontrada com esse ID.");
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
