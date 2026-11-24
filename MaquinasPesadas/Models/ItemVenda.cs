using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class ItemVenda
    {
        private int _itemVendaID;

        public int ItemVendaID
        {
            get { return _itemVendaID; }
            set
            {
                if (value >= 0)
                    _itemVendaID = value;
                else
                    throw new Exception("ID do item inválido!");
            }
        }

        private int _quantidade;

        public int Quantidade
        {
            get { return _quantidade; }
            set
            {
                if (value > 0)
                    _quantidade = value;
                else
                    throw new Exception("A quantidade deve ser maior que zero");
            }
        }

        private double _precoUnitario;

        public double PrecoUnitario
        {
            get { return _precoUnitario; }
            set
            {
                if (value > 0)
                    _precoUnitario = value;
                else
                    throw new Exception("O preço unitário deve ser maior que zero!");
            }
        }

        private Venda _venda;

        public Venda Venda
        {
            get { return _venda; }
            set
            {
                if (value != null)
                    _venda = value;
                else
                    throw new Exception("A venda do item é obrigatória!");
            }
        }

        private Peca _peca;

        public Peca Peca
        {
            get { return _peca; }
            set
            {
                if (value != null)
                    _peca = value;
                else
                    throw new Exception("A peça do item é obrigatória!");
            }
        }
    }
}
