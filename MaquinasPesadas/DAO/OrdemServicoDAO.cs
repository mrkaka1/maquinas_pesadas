using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class OrdemServicoDAO : IDAO<OrdemServico>
    {
        public void Insert(OrdemServico os)
        {
            try
            {
                string sql = @"INSERT INTO ordemServico (dataAbertura, dataFechamento, descricaoProblema, horimetroEntrada, valorMaoObra, situacao, FK_maquinaID, FK_funcionarioID)
                    VALUES (@dataAbertura, @dataFechamento, @descricaoProblema, @horimetroEntrada, @valorMaoObra, @situacao, @FK_maquinaID, @FK_funcionarioID)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.Add("@dataAbertura", MySqlDbType.Date).Value = os.DataAbertura.ToDateTime(TimeOnly.MinValue);
                    if (os.DataFechamento == DateOnly.MinValue)
                        cmd.Parameters.Add("@dataFechamento", MySqlDbType.Date).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add("@dataFechamento", MySqlDbType.Date).Value = os.DataFechamento.ToDateTime(TimeOnly.MinValue);
                    cmd.Parameters.AddWithValue("@descricaoProblema", os.DescricaoProblema);
                    cmd.Parameters.AddWithValue("@horimetroEntrada", os.HorimetroEntrada);
                    cmd.Parameters.AddWithValue("@valorMaoObra", os.ValorMaoObra);
                    cmd.Parameters.AddWithValue("@situacao", os.Situacao);
                    cmd.Parameters.AddWithValue("@FK_maquinaID", os.Maquina.MaquinaID);
                    cmd.Parameters.AddWithValue("@FK_funcionarioID", os.Funcionario.FuncionarioID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int ordemServicoID)
        {
            try
            {
                string sql = "DELETE FROM ordemServico WHERE ordemServicoID = @ordemServicoID;";
                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@ordemServicoID", ordemServicoID);
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

        public void Atualizar(OrdemServico os)
        {
            try
            {
                string sql = @"UPDATE ordemServico SET dataAbertura = @dataAbertura, dataFechamento = @dataFechamento, descricaoProblema = @descricaoProblema, horimetroEntrada = @horimetroEntrada, valorMaoObra = @valorMaoObra, situacao = @situacao, FK_maquinaID = @FK_maquinaID, FK_funcionarioID = @FK_funcionarioID
                    WHERE ordemServicoID = @ordemServicoID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.Add("@dataAbertura", MySqlDbType.Date).Value = os.DataAbertura.ToDateTime(TimeOnly.MinValue);
                    if (os.DataFechamento == DateOnly.MinValue)
                        cmd.Parameters.Add("@dataFechamento", MySqlDbType.Date).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add("@dataFechamento", MySqlDbType.Date).Value = os.DataFechamento.ToDateTime(TimeOnly.MinValue);
                    cmd.Parameters.AddWithValue("@descricaoProblema", os.DescricaoProblema);
                    cmd.Parameters.AddWithValue("@horimetroEntrada", os.HorimetroEntrada);
                    cmd.Parameters.AddWithValue("@valorMaoObra", os.ValorMaoObra);
                    cmd.Parameters.AddWithValue("@situacao", os.Situacao);
                    cmd.Parameters.AddWithValue("@FK_maquinaID", os.Maquina.MaquinaID);
                    cmd.Parameters.AddWithValue("@FK_funcionarioID", os.Funcionario.FuncionarioID);
                    cmd.Parameters.AddWithValue("@ordemServicoID", os.OrdemServicoID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o ordemServicoID)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<OrdemServico> GetAll()

        {
            List<OrdemServico> ordens = new List<OrdemServico>();

            try
            {
                string sql = @"SELECT * FROM ordemServico ORDER BY dataAbertura DESC";

                using(var conexao = Conexao.Conectar())
                    using(var comando = new MySqlCommand(sql, conexao))
                        using(MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        OrdemServico os = new OrdemServico()
                        {
                            OrdemServicoID = Convert.ToInt32(dr["ordemServicoID"]),
                            DataAbertura = DateOnly.FromDateTime(Convert.ToDateTime(dr["dataAbertura"])),
                            DescricaoProblema = dr["descricaoProblema"].ToString(),
                            HorimetroEntrada = Convert.ToInt32(dr["horimetroEntrada"]),
                            ValorMaoObra = Convert.ToDouble(dr["valorMaoObra"]),
                            Situacao = dr["situacao"].ToString(),
                            Maquina = new Maquina()
                            {
                                MaquinaID = Convert.ToInt32(dr["FK_maquinaID"])
                            },
                            Funcionario = new Funcionario()
                            {
                                FuncionarioID = Convert.ToInt32(dr["FK_funcionarioID"])
                            }
                        };
                        if (dr["dataFechamento"] != DBNull.Value)
                            os.DataFechamento = DateOnly.FromDateTime(Convert.ToDateTime(dr["dataFechamento"]));
                        ordens.Add(os);
                    }
                }
                return ordens;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar as ordens de serviço: {ex.Message}");
            }
        }

        public OrdemServico BuscarID(int ordemServicoID)
        {
            try
            {
                string sql = @"SELECT * FROM ordemServico WHERE ordemServicoID = @ordemServicoID";

                using (var conexao = Conexao.Conectar())
                    using(var cmd =  new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@ordemServicoID", ordemServicoID);

                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            OrdemServico os = new OrdemServico();

                            os.OrdemServicoID = Convert.ToInt32(dr["ordemServicoID"]);
                            os.DataAbertura = DateOnly.FromDateTime(Convert.ToDateTime(dr["dataAbertura"]));
                            if (dr["dataFechamento"] != DBNull.Value)
                                os.DataFechamento = DateOnly.FromDateTime(Convert.ToDateTime(dr["dataFechamento"]));
                            os.DescricaoProblema = dr["descricaoProblema"].ToString();
                            os.HorimetroEntrada = Convert.ToInt32(dr["horimetroEntrada"]);
                            os.ValorMaoObra = Convert.ToDouble(dr["valorMaoObra"]);
                            os.Situacao = dr["situacao"].ToString();
                            os.Maquina = new Maquina()
                            {
                                MaquinaID = Convert.ToInt32(dr["FK_maquinaID"])
                            };
                            os.Funcionario = new Funcionario()
                            {
                                FuncionarioID = Convert.ToInt32(dr["FK_funcionarioID"])
                            };

                            return os;
                        }
                        else
                        {
                            throw new Exception("Nenhuma ordem de serviço encontrada com esse ID.");
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
