using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class ItemVendaDAO : IDAO<ItemVenda>
    {
        public void Insert(ItemVenda i)
        {
            try
            {
                string sql = @"INSERT INTO itemVenda (quantidade, precoUnitario, FK_vendaID, FK_pecaID)
                    VALUES (@quantidade, @precoUnitario, @FK_vendaID, @FK_pecaID)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@quantidade", i.Quantidade);
                    cmd.Parameters.AddWithValue("@precoUnitario", i.PrecoUnitario);
                    cmd.Parameters.AddWithValue("@FK_vendaID", i.Venda.VendaID);
                    cmd.Parameters.AddWithValue("@FK_pecaID", i.Peca.PecaID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int itemVendaID)
        {
            try
            {
                string sql = "DELETE FROM itemVenda WHERE itemVendaID = @itemVendaID;";
                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@itemVendaID", itemVendaID);
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

        public void Atualizar(ItemVenda i)
        {
            try
            {
                string sql = @"UPDATE itemVenda SET quantidade = @quantidade, precoUnitario = @precoUnitario, FK_vendaID = @FK_vendaID, FK_pecaID = @FK_pecaID
                    WHERE itemVendaID = @itemVendaID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@quantidade", i.Quantidade);
                    cmd.Parameters.AddWithValue("@precoUnitario", i.PrecoUnitario);
                    cmd.Parameters.AddWithValue("@FK_vendaID", i.Venda.VendaID);
                    cmd.Parameters.AddWithValue("@FK_pecaID", i.Peca.PecaID);
                    cmd.Parameters.AddWithValue("@itemVendaID", i.ItemVendaID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o itemVendaID)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ItemVenda> GetAll()

        {
            List<ItemVenda> itens = new List<ItemVenda>();

            try
            {
                string sql = @"SELECT * FROM itemVenda ORDER BY FK_vendaID";

                using(var conexao = Conexao.Conectar())
                    using(var comando = new MySqlCommand(sql, conexao))
                        using(MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ItemVenda i = new ItemVenda()
                        {
                            ItemVendaID = Convert.ToInt32(dr["itemVendaID"]),
                            Quantidade = Convert.ToInt32(dr["quantidade"]),
                            PrecoUnitario = Convert.ToDouble(dr["precoUnitario"]),
                            Venda = new Venda()
                            {
                                VendaID = Convert.ToInt32(dr["FK_vendaID"])
                            },
                            Peca = new Peca()
                            {
                                PecaID = Convert.ToInt32(dr["FK_pecaID"])
                            }
                        };
                        itens.Add(i);
                    }
                }
                return itens;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar os itens: {ex.Message}");
            }
        }

        public ItemVenda BuscarID(int itemVendaID)
        {
            try
            {
                string sql = @"SELECT * FROM itemVenda WHERE itemVendaID = @itemVendaID";

                using (var conexao = Conexao.Conectar())
                    using(var cmd =  new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@itemVendaID", itemVendaID);

                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ItemVenda i = new ItemVenda();

                            i.ItemVendaID = Convert.ToInt32(dr["itemVendaID"]);
                            i.Quantidade = Convert.ToInt32(dr["quantidade"]);
                            i.PrecoUnitario = Convert.ToDouble(dr["precoUnitario"]);
                            i.Venda = new Venda()
                            {
                                VendaID = Convert.ToInt32(dr["FK_vendaID"])
                            };
                            i.Peca = new Peca()
                            {
                                PecaID = Convert.ToInt32(dr["FK_pecaID"])
                            };

                            return i;
                        }
                        else
                        {
                            throw new Exception("Nenhum item encontrado com esse ID.");
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
