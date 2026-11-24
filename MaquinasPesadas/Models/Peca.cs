using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class Peca
    {
        private int _pecaID;

        public int PecaID
        {
            get { return _pecaID; }
            set
            {
                if (value >= 0)
                    _pecaID = value;
                else
                    throw new Exception("ID da peça inválido!");
            }
        }

        private string _codigoFabricante;

        public string CodigoFabricante
        {
            get { return _codigoFabricante; }
            set
            {
                if (!(value == "" || value == null))
                    _codigoFabricante = value.Trim();
                else
                    throw new Exception("O código do fabricante é obrigatório!");
            }
        }

        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set
            {
                if (!(value == "" || value == null))
                    _descricao = value.Trim();
                else
                    throw new Exception("A descrição da peça é obrigatória!");
            }
        }

        private double _precoCusto;

        public double PrecoCusto
        {
            get { return _precoCusto; }
            set
            {
                if (value >= 0)
                    _precoCusto = value;
                else
                    throw new Exception("O preço de custo não pode ser negativo!");
            }
        }

        private double _precoVenda;

        public double PrecoVenda
        {
            get { return _precoVenda; }
            set
            {
                if (value > 0)
                    _precoVenda = value;
                else
                    throw new Exception("O preço de venda deve ser maior que zero!");
            }
        }

        private int _estoque;

        public int Estoque
        {
            get { return _estoque; }
            set
            {
                if (value >= 0)
                    _estoque = value;
                else
                    throw new Exception("O estoque não pode ser negativo!");
            }
        }

        private int _estoqueMinimo;

        public int EstoqueMinimo
        {
            get { return _estoqueMinimo; }
            set
            {
                if (value >= 0)
                    _estoqueMinimo = value;
                else
                    throw new Exception("O estoque mínimo não pode ser negativo!");
            }
        }

        private bool _ativo = true;

        public bool Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        private Categoria _categoria;

        public Categoria Categoria
        {
            get { return _categoria; }
            set
            {
                if (value != null)
                    _categoria = value;
                else
                    throw new Exception("A categoria da peça é obrigatória!");
            }
        }

        private Marca _marca;

        public Marca Marca
        {
            get { return _marca; }
            set
            {
                if (value != null)
                    _marca = value;
                else
                    throw new Exception("A marca da peça é obrigatória!");
            }
        }

        private Fornecedor _fornecedor;

        public Fornecedor Fornecedor
        {
            get { return _fornecedor; }
            set
            {
                if (value != null)
                    _fornecedor = value;
                else
                    throw new Exception("O fornecedor da peça é obrigatório!");
            }
        }
    }
}
