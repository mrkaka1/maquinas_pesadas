using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class OrdemServico
    {
        private int _ordemServicoID;

        public int OrdemServicoID
        {
            get { return _ordemServicoID; }
            set
            {
                if (value >= 0)
                    _ordemServicoID = value;
                else
                    throw new Exception("ID da ordem de serviço inválido!");
            }
        }

        private DateOnly _dataAbertura;

        public DateOnly DataAbertura
        {
            get { return _dataAbertura; }
            set
            {
                if (value <= DateOnly.FromDateTime(DateTime.Now))
                    _dataAbertura = value;
                else
                    throw new Exception("A data de abertura não pode ser maior que a data atual!");
            }
        }

        private DateOnly? _dataFechamento;

        public DateOnly? DataFechamento
        {
            get { return _dataFechamento; }
            set
            {
                if (value == null || value >= _dataAbertura)
                    _dataFechamento = value;
                else
                    throw new Exception("A data de fechamento não pode ser menor que a data de abertura!");
            }
        }

        private string _descricaoProblema;

        public string DescricaoProblema
        {
            get { return _descricaoProblema; }
            set { _descricaoProblema = value; }
        }

        private int _horimetroEntrada;

        public int HorimetroEntrada
        {
            get { return _horimetroEntrada; }
            set
            {
                if (value >= 0)
                    _horimetroEntrada = value;
                else
                    throw new Exception("O horímetro de entrada não pode ser negativo!");
            }
        }

        private double _valorMaoObra;

        public double ValorMaoObra
        {
            get { return _valorMaoObra; }
            set
            {
                if (value >= 0)
                    _valorMaoObra = value;
                else
                    throw new Exception("O valor da mão de obra não pode ser negativo!");
            }
        }

        private string _situacao = "Aberta";

        public string Situacao
        {
            get { return _situacao; }
            set
            {
                if (!(value == "" || value == null))
                    _situacao = value.Trim();
                else
                    throw new Exception("A situação da OS é obrigatória!");
            }
        }

        private Maquina _maquina;

        public Maquina Maquina
        {
            get { return _maquina; }
            set
            {
                if (value != null)
                    _maquina = value;
                else
                    throw new Exception("A máquina da OS é obrigatória!");
            }
        }

        private Funcionario _funcionario;

        public Funcionario Funcionario
        {
            get { return _funcionario; }
            set
            {
                if (value != null)
                    _funcionario = value;
                else
                    throw new Exception("O mecânico da OS é obrigatório!");
            }
        }

        private List<PecaOS> _pecas;

        public List<PecaOS> Pecas
        {
            get { return _pecas; }
        }

        public OrdemServico()
        {
            _pecas = new List<PecaOS>();
        }

        public double CalcularValorTotal()
        {
            double total = 0;
            foreach (PecaOS item in _pecas)
            {
                total += item.Quantidade * item.PrecoUnitario;
            }
            return ValorMaoObra + total;
        }
    }
}
