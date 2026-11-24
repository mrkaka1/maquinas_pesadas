using MaquinasPesadas.DataBase;
using MaquinasPesadas.Interface;
using MaquinasPesadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.DAO
{
    internal class MaquinaDAO : IDAO<Maquina>
    {
        public void Insert(Maquina m)
        {
            try
            {
                string sql = @"INSERT INTO maquina (numeroSerie, anoFabricacao, horimetro, FK_clienteID, FK_modeloID)
                    VALUES (@numeroSerie, @anoFabricacao, @horimetro, @FK_clienteID, @FK_modeloID)";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@numeroSerie", m.NumeroSerie);
                    cmd.Parameters.AddWithValue("@anoFabricacao", m.AnoFabricacao);
                    cmd.Parameters.AddWithValue("@horimetro", m.Horimetro);
                    cmd.Parameters.AddWithValue("@FK_clienteID", m.Cliente.ClienteID);
                    cmd.Parameters.AddWithValue("@FK_modeloID", m.Modelo.ModeloID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int maquinaID)
        {
            try
            {
                string sql = "DELETE FROM maquina WHERE maquinaID = @maquinaID;";
                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@maquinaID", maquinaID);
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

        public void Atualizar(Maquina m)
        {
            try
            {
                string sql = @"UPDATE maquina SET numeroSerie = @numeroSerie, anoFabricacao = @anoFabricacao, horimetro = @horimetro, FK_clienteID = @FK_clienteID, FK_modeloID = @FK_modeloID
                    WHERE maquinaID = @maquinaID";

                using (var conexao = Conexao.Conectar())
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@numeroSerie", m.NumeroSerie);
                    cmd.Parameters.AddWithValue("@anoFabricacao", m.AnoFabricacao);
                    cmd.Parameters.AddWithValue("@horimetro", m.Horimetro);
                    cmd.Parameters.AddWithValue("@FK_clienteID", m.Cliente.ClienteID);
                    cmd.Parameters.AddWithValue("@FK_modeloID", m.Modelo.ModeloID);
                    cmd.Parameters.AddWithValue("@maquinaID", m.MaquinaID);
                    var linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        throw new Exception("Nenhum registro foi atualizado (verifique o maquinaID)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Maquina> GetAll()

        {
            List<Maquina> maquinas = new List<Maquina>();

            try
            {
                string sql = @"SELECT * FROM maquina ORDER BY numeroSerie";

                using(var conexao = Conexao.Conectar())
                    using(var comando = new MySqlCommand(sql, conexao))
                        using(MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Maquina m = new Maquina()
                        {
                            MaquinaID = Convert.ToInt32(dr["maquinaID"]),
                            NumeroSerie = dr["numeroSerie"].ToString(),
                            AnoFabricacao = Convert.ToInt32(dr["anoFabricacao"]),
                            Horimetro = Convert.ToInt32(dr["horimetro"]),
                            Cliente = new Cliente()
                            {
                                ClienteID = Convert.ToInt32(dr["FK_clienteID"])
                            },
                            Modelo = new Modelo()
                            {
                                ModeloID = Convert.ToInt32(dr["FK_modeloID"])
                            }
                        };
                        maquinas.Add(m);
                    }
                }
                return maquinas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar as máquinas: {ex.Message}");
            }
        }

        public Maquina BuscarID(int maquinaID)
        {
            try
            {
                string sql = @"SELECT * FROM maquina WHERE maquinaID = @maquinaID";

                using (var conexao = Conexao.Conectar())
                    using(var cmd =  new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@maquinaID", maquinaID);

                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Maquina m = new Maquina();

                            m.MaquinaID = Convert.ToInt32(dr["maquinaID"]);
                            m.NumeroSerie = dr["numeroSerie"].ToString();
                            m.AnoFabricacao = Convert.ToInt32(dr["anoFabricacao"]);
                            m.Horimetro = Convert.ToInt32(dr["horimetro"]);
                            m.Cliente = new Cliente()
                            {
                                ClienteID = Convert.ToInt32(dr["FK_clienteID"])
                            };
                            m.Modelo = new Modelo()
                            {
                                ModeloID = Convert.ToInt32(dr["FK_modeloID"])
                            };

                            return m;
                        }
                        else
                        {
                            throw new Exception("Nenhuma máquina encontrada com esse ID.");
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
