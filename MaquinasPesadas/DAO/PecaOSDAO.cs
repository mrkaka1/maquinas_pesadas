using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class PecaOSDAO : IDAO<PecaOS>
    {
        public void Insert(PecaOS po)
        {
            try
            {
                string sql = @"INSERT INTO pecaOS (quantidade, precoUnitario, FK_ordemServicoID, FK_pecaID)
                    VALUES (@quantidade, @precoUnitario, @FK_ordemServicoID, @FK_pecaID)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@quantidade", po.Quantidade);
                    cmd.Parameters.AddWithValue("@precoUnitario", po.PrecoUnitario);
                    cmd.Parameters.AddWithValue("@FK_ordemServicoID", po.OrdemServico.OrdemServicoID);
                    cmd.Parameters.AddWithValue("@FK_pecaID", po.Peca.PecaID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int pecaOSID)
        {
            try
            {
                string sql = "DELETE FROM pecaOS WHERE pecaOSID = @pecaOSID;";
                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@pecaOSID", pecaOSID);
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

        public void Atualizar(PecaOS po)
        {
            try
            {
                string sql = @"UPDATE pecaOS SET quantidade = @quantidade, precoUnitario = @precoUnitario, FK_ordemServicoID = @FK_ordemServicoID, FK_pecaID = @FK_pecaID
                    WHERE pecaOSID = @pecaOSID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@quantidade", po.Quantidade);
                    cmd.Parameters.AddWithValue("@precoUnitario", po.PrecoUnitario);
                    cmd.Parameters.AddWithValue("@FK_ordemServicoID", po.OrdemServico.OrdemServicoID);
                    cmd.Parameters.AddWithValue("@FK_pecaID", po.Peca.PecaID);
                    cmd.Parameters.AddWithValue("@pecaOSID", po.PecaOSID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o pecaOSID)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<PecaOS> GetAll()

        {
            List<PecaOS> pecas = new List<PecaOS>();

            try
            {
                string sql = @"SELECT * FROM pecaOS ORDER BY FK_ordemServicoID";

                using(var conexao = Conexao.Conectar())
                    using(var comando = new MySqlCommand(sql, conexao))
                        using(MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PecaOS po = new PecaOS()
                        {
                            PecaOSID = Convert.ToInt32(dr["pecaOSID"]),
                            Quantidade = Convert.ToInt32(dr["quantidade"]),
                            PrecoUnitario = Convert.ToDouble(dr["precoUnitario"]),
                            OrdemServico = new OrdemServico()
                            {
                                OrdemServicoID = Convert.ToInt32(dr["FK_ordemServicoID"])
                            },
                            Peca = new Peca()
                            {
                                PecaID = Convert.ToInt32(dr["FK_pecaID"])
                            }
                        };
                        pecas.Add(po);
                    }
                }
                return pecas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar as peças da OS: {ex.Message}");
            }
        }

        public PecaOS BuscarID(int pecaOSID)
        {
            try
            {
                string sql = @"SELECT * FROM pecaOS WHERE pecaOSID = @pecaOSID";

                using (var conexao = Conexao.Conectar())
                    using(var cmd =  new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@pecaOSID", pecaOSID);

                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            PecaOS po = new PecaOS();

                            po.PecaOSID = Convert.ToInt32(dr["pecaOSID"]);
                            po.Quantidade = Convert.ToInt32(dr["quantidade"]);
                            po.PrecoUnitario = Convert.ToDouble(dr["precoUnitario"]);
                            po.OrdemServico = new OrdemServico()
                            {
                                OrdemServicoID = Convert.ToInt32(dr["FK_ordemServicoID"])
                            };
                            po.Peca = new Peca()
                            {
                                PecaID = Convert.ToInt32(dr["FK_pecaID"])
                            };

                            return po;
                        }
                        else
                        {
                            throw new Exception("Nenhuma peça da OS encontrada com esse ID.");
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
