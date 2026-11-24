using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class Venda
    {
        private int _vendaID;

        public int VendaID
        {
            get { return _vendaID; }
            set
            {
                if (value >= 0)
                    _vendaID = value;
                else
                    throw new Exception("ID da venda inválido!");
            }
        }

        private DateTime _dataHoraVenda;

        public DateTime DataHoraVenda
        {
            get { return _dataHoraVenda; }
            set
            {
                if (value <= DateTime.Now)
                    _dataHoraVenda = value;
                else
                    throw new Exception("A data da venda não pode ser maior que a data atual!");
            }
        }

        private string _formaPagamento;

        public string FormaPagamento
        {
            get { return _formaPagamento; }
            set { _formaPagamento = value; }
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
                    throw new Exception("A situação da venda é obrigatória!");
            }
        }

        private double _desconto;

        public double Desconto
        {
            get { return _desconto; }
            set
            {
                if (value >= 0)
                    _desconto = value;
                else
                    throw new Exception("O desconto não pode ser negativo!");
            }
        }

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set
            {
                if (value != null)
                    _cliente = value;
                else
                    throw new Exception("O cliente da venda é obrigatório!");
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
                    throw new Exception("O vendedor da venda é obrigatório!");
            }
        }

        private List<ItemVenda> _itens;

        public List<ItemVenda> Itens
        {
            get { return _itens; }
        }

        public Venda()
        {
            _itens = new List<ItemVenda>();
        }

        public double CalcularValorTotal()
        {
            double total = 0;
            foreach (ItemVenda item in _itens)
            {
                total += item.Quantidade * item.PrecoUnitario;
            }
            return total - Desconto;
        }
    }
}
