using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class PecaModeloDAO : IDAO<PecaModelo>
    {
        public void Insert(PecaModelo pm)
        {
            try
            {
                string sql = @"INSERT INTO pecaModelo (FK_pecaID, FK_modeloID)
                    VALUES (@FK_pecaID, @FK_modeloID)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@FK_pecaID", pm.Peca.PecaID);
                    cmd.Parameters.AddWithValue("@FK_modeloID", pm.Modelo.ModeloID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int pecaModeloID)
        {
            try
            {
                string sql = "DELETE FROM pecaModelo WHERE pecaModeloID = @pecaModeloID;";
                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@pecaModeloID", pecaModeloID);
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

        public void Atualizar(PecaModelo pm)
        {
            try
            {
                string sql = @"UPDATE pecaModelo SET FK_pecaID = @FK_pecaID, FK_modeloID = @FK_modeloID
                    WHERE pecaModeloID = @pecaModeloID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@FK_pecaID", pm.Peca.PecaID);
                    cmd.Parameters.AddWithValue("@FK_modeloID", pm.Modelo.ModeloID);
                    cmd.Parameters.AddWithValue("@pecaModeloID", pm.PecaModeloID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o pecaModeloID)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<PecaModelo> GetAll()

        {
            List<PecaModelo> lista = new List<PecaModelo>();

            try
            {
                string sql = @"SELECT * FROM pecaModelo ORDER BY pecaModeloID";

                using(var conexao = Conexao.Conectar())
                    using(var comando = new MySqlCommand(sql, conexao))
                        using(MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PecaModelo pm = new PecaModelo()
                        {
                            PecaModeloID = Convert.ToInt32(dr["pecaModeloID"]),
                            Peca = new Peca()
                            {
                                PecaID = Convert.ToInt32(dr["FK_pecaID"])
                            },
                            Modelo = new Modelo()
                            {
                                ModeloID = Convert.ToInt32(dr["FK_modeloID"])
                            }
                        };
                        lista.Add(pm);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar as compatibilidades: {ex.Message}");
            }
        }

        public PecaModelo BuscarID(int pecaModeloID)
        {
            try
            {
                string sql = @"SELECT * FROM pecaModelo WHERE pecaModeloID = @pecaModeloID";

                using (var conexao = Conexao.Conectar())
                    using(var cmd =  new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@pecaModeloID", pecaModeloID);

                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            PecaModelo pm = new PecaModelo();

                            pm.PecaModeloID = Convert.ToInt32(dr["pecaModeloID"]);
                            pm.Peca = new Peca()
                            {
                                PecaID = Convert.ToInt32(dr["FK_pecaID"])
                            };
                            pm.Modelo = new Modelo()
                            {
                                ModeloID = Convert.ToInt32(dr["FK_modeloID"])
                            };

                            return pm;
                        }
                        else
                        {
                            throw new Exception("Nenhuma compatibilidade encontrada com esse ID.");
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
