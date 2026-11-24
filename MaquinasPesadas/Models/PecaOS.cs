using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class PecaOS
    {
        private int _pecaOSID;

        public int PecaOSID
        {
            get { return _pecaOSID; }
            set
            {
                if (value >= 0)
                    _pecaOSID = value;
                else
                    throw new Exception("ID da peça da OS inválido!");
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

        private OrdemServico _ordemServico;

        public OrdemServico OrdemServico
        {
            get { return _ordemServico; }
            set
            {
                if (value != null)
                    _ordemServico = value;
                else
                    throw new Exception("A ordem de serviço é obrigatória!");
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
                    throw new Exception("A peça é obrigatória!");
            }
        }
    }
}
