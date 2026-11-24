using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class VendaDAO : IDAO<Venda>
    {
        public void Insert(Venda v)
        {
            try
            {
                string sql = @"INSERT INTO venda (dataHoraVenda, formaPagamento, situacao, desconto, FK_clienteID, FK_funcionarioID)
                    VALUES (@dataHoraVenda, @formaPagamento, @situacao, @desconto, @FK_clienteID, @FK_funcionarioID)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@dataHoraVenda", v.DataHoraVenda);
                    cmd.Parameters.AddWithValue("@formaPagamento", v.FormaPagamento);
                    cmd.Parameters.AddWithValue("@situacao", v.Situacao);
                    cmd.Parameters.AddWithValue("@desconto", v.Desconto);
                    cmd.Parameters.AddWithValue("@FK_clienteID", v.Cliente.ClienteID);
                    cmd.Parameters.AddWithValue("@FK_funcionarioID", v.Funcionario.FuncionarioID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int vendaID)
        {
            try
            {
                string sql = "DELETE FROM venda WHERE vendaID = @vendaID;";
                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@vendaID", vendaID);
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

        public void Atualizar(Venda v)
        {
            try
            {
                string sql = @"UPDATE venda SET dataHoraVenda = @dataHoraVenda, formaPagamento = @formaPagamento, situacao = @situacao, desconto = @desconto, FK_clienteID = @FK_clienteID, FK_funcionarioID = @FK_funcionarioID
                    WHERE vendaID = @vendaID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@dataHoraVenda", v.DataHoraVenda);
                    cmd.Parameters.AddWithValue("@formaPagamento", v.FormaPagamento);
                    cmd.Parameters.AddWithValue("@situacao", v.Situacao);
                    cmd.Parameters.AddWithValue("@desconto", v.Desconto);
                    cmd.Parameters.AddWithValue("@FK_clienteID", v.Cliente.ClienteID);
                    cmd.Parameters.AddWithValue("@FK_funcionarioID", v.Funcionario.FuncionarioID);
                    cmd.Parameters.AddWithValue("@vendaID", v.VendaID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o vendaID)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Venda> GetAll()

        {
            List<Venda> vendas = new List<Venda>();

            try
            {
                string sql = @"SELECT * FROM venda ORDER BY dataHoraVenda DESC";

                using(var conexao = Conexao.Conectar())
                    using(var comando = new MySqlCommand(sql, conexao))
                        using(MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Venda v = new Venda()
                        {
                            VendaID = Convert.ToInt32(dr["vendaID"]),
                            DataHoraVenda = Convert.ToDateTime(dr["dataHoraVenda"]),
                            FormaPagamento = dr["formaPagamento"].ToString(),
                            Situacao = dr["situacao"].ToString(),
                            Desconto = Convert.ToDouble(dr["desconto"]),
                            Cliente = new Cliente()
                            {
                                ClienteID = Convert.ToInt32(dr["FK_clienteID"])
                            },
                            Funcionario = new Funcionario()
                            {
                                FuncionarioID = Convert.ToInt32(dr["FK_funcionarioID"])
                            }
                        };
                        vendas.Add(v);
                    }
                }
                return vendas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar as vendas: {ex.Message}");
            }
        }

        public Venda BuscarID(int vendaID)
        {
            try
            {
                string sql = @"SELECT * FROM venda WHERE vendaID = @vendaID";

                using (var conexao = Conexao.Conectar())
                    using(var cmd =  new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@vendaID", vendaID);

                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Venda v = new Venda();

                            v.VendaID = Convert.ToInt32(dr["vendaID"]);
                            v.DataHoraVenda = Convert.ToDateTime(dr["dataHoraVenda"]);
                            v.FormaPagamento = dr["formaPagamento"].ToString();
                            v.Situacao = dr["situacao"].ToString();
                            v.Desconto = Convert.ToDouble(dr["desconto"]);
                            v.Cliente = new Cliente()
                            {
                                ClienteID = Convert.ToInt32(dr["FK_clienteID"])
                            };
                            v.Funcionario = new Funcionario()
                            {
                                FuncionarioID = Convert.ToInt32(dr["FK_funcionarioID"])
                            };

                            return v;
                        }
                        else
                        {
                            throw new Exception("Nenhuma venda encontrada com esse ID.");
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
