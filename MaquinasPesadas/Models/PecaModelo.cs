using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class PecaModelo
    {
        private int _pecaModeloID;

        public int PecaModeloID
        {
            get { return _pecaModeloID; }
            set
            {
                if (value >= 0)
                    _pecaModeloID = value;
                else
                    throw new Exception("ID da compatibilidade inválido!");
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

        private Modelo _modelo;

        public Modelo Modelo
        {
            get { return _modelo; }
            set
            {
                if (value != null)
                    _modelo = value;
                else
                    throw new Exception("O modelo é obrigatório!");
            }
        }
    }
}
