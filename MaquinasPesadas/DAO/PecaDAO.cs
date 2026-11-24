using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class PecaDAO : IDAO<Peca>
    {
        public void Insert(Peca p)
        {
            try
            {
                string sql = @"INSERT INTO peca (codigoFabricante, descricao, precoCusto, precoVenda, estoque, estoqueMinimo, ativo, FK_categoriaID, FK_marcaID, FK_fornecedorID)
                    VALUES (@codigoFabricante, @descricao, @precoCusto, @precoVenda, @estoque, @estoqueMinimo, @ativo, @FK_categoriaID, @FK_marcaID, @FK_fornecedorID)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@codigoFabricante", p.CodigoFabricante);
                    cmd.Parameters.AddWithValue("@descricao", p.Descricao);
                    cmd.Parameters.AddWithValue("@precoCusto", p.PrecoCusto);
                    cmd.Parameters.AddWithValue("@precoVenda", p.PrecoVenda);
                    cmd.Parameters.AddWithValue("@estoque", p.Estoque);
                    cmd.Parameters.AddWithValue("@estoqueMinimo", p.EstoqueMinimo);
                    cmd.Parameters.AddWithValue("@ativo", p.Ativo);
                    cmd.Parameters.AddWithValue("@FK_categoriaID", p.Categoria.CategoriaID);
                    cmd.Parameters.AddWithValue("@FK_marcaID", p.Marca.MarcaID);
                    cmd.Parameters.AddWithValue("@FK_fornecedorID", p.Fornecedor.FornecedorID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int pecaID)
        {
            try
            {
                string sql = "DELETE FROM peca WHERE pecaID = @pecaID;";
                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@pecaID", pecaID);
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

        public void Atualizar(Peca p)
        {
            try
            {
                string sql = @"UPDATE peca SET codigoFabricante = @codigoFabricante, descricao = @descricao, precoCusto = @precoCusto, precoVenda = @precoVenda, estoque = @estoque, estoqueMinimo = @estoqueMinimo, ativo = @ativo, FK_categoriaID = @FK_categoriaID, FK_marcaID = @FK_marcaID, FK_fornecedorID = @FK_fornecedorID
                    WHERE pecaID = @pecaID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@codigoFabricante", p.CodigoFabricante);
                    cmd.Parameters.AddWithValue("@descricao", p.Descricao);
                    cmd.Parameters.AddWithValue("@precoCusto", p.PrecoCusto);
                    cmd.Parameters.AddWithValue("@precoVenda", p.PrecoVenda);
                    cmd.Parameters.AddWithValue("@estoque", p.Estoque);
                    cmd.Parameters.AddWithValue("@estoqueMinimo", p.EstoqueMinimo);
                    cmd.Parameters.AddWithValue("@ativo", p.Ativo);
                    cmd.Parameters.AddWithValue("@FK_categoriaID", p.Categoria.CategoriaID);
                    cmd.Parameters.AddWithValue("@FK_marcaID", p.Marca.MarcaID);
                    cmd.Parameters.AddWithValue("@FK_fornecedorID", p.Fornecedor.FornecedorID);
                    cmd.Parameters.AddWithValue("@pecaID", p.PecaID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o pecaID)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Peca> GetAll()

        {
            List<Peca> pecas = new List<Peca>();

            try
            {
                string sql = @"SELECT * FROM peca ORDER BY descricao";

                using(var conexao = Conexao.Conectar())
                    using(var comando = new MySqlCommand(sql, conexao))
                        using(MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Peca p = new Peca()
                        {
                            PecaID = Convert.ToInt32(dr["pecaID"]),
                            CodigoFabricante = dr["codigoFabricante"].ToString(),
                            Descricao = dr["descricao"].ToString(),
                            PrecoCusto = Convert.ToDouble(dr["precoCusto"]),
                            PrecoVenda = Convert.ToDouble(dr["precoVenda"]),
                            Estoque = Convert.ToInt32(dr["estoque"]),
                            EstoqueMinimo = Convert.ToInt32(dr["estoqueMinimo"]),
                            Ativo = Convert.ToBoolean(dr["ativo"]),
                            Categoria = new Categoria()
                            {
                                CategoriaID = Convert.ToInt32(dr["FK_categoriaID"])
                            },
                            Marca = new Marca()
                            {
                                MarcaID = Convert.ToInt32(dr["FK_marcaID"])
                            },
                            Fornecedor = new Fornecedor()
                            {
                                FornecedorID = Convert.ToInt32(dr["FK_fornecedorID"])
                            }
                        };
                        pecas.Add(p);
                    }
                }
                return pecas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar as peças: {ex.Message}");
            }
        }

        public Peca BuscarID(int pecaID)
        {
            try
            {
                string sql = @"SELECT * FROM peca WHERE pecaID = @pecaID";

                using (var conexao = Conexao.Conectar())
                    using(var cmd =  new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@pecaID", pecaID);

                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Peca p = new Peca();

                            p.PecaID = Convert.ToInt32(dr["pecaID"]);
                            p.CodigoFabricante = dr["codigoFabricante"].ToString();
                            p.Descricao = dr["descricao"].ToString();
                            p.PrecoCusto = Convert.ToDouble(dr["precoCusto"]);
                            p.PrecoVenda = Convert.ToDouble(dr["precoVenda"]);
                            p.Estoque = Convert.ToInt32(dr["estoque"]);
                            p.EstoqueMinimo = Convert.ToInt32(dr["estoqueMinimo"]);
                            p.Ativo = Convert.ToBoolean(dr["ativo"]);
                            p.Categoria = new Categoria()
                            {
                                CategoriaID = Convert.ToInt32(dr["FK_categoriaID"])
                            };
                            p.Marca = new Marca()
                            {
                                MarcaID = Convert.ToInt32(dr["FK_marcaID"])
                            };
                            p.Fornecedor = new Fornecedor()
                            {
                                FornecedorID = Convert.ToInt32(dr["FK_fornecedorID"])
                            };

                            return p;
                        }
                        else
                        {
                            throw new Exception("Nenhuma peça encontrada com esse ID.");
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
