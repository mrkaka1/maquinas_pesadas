using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class Marca
    {
        private int _marcaID;
        public int MarcaID
        {
            get { return _marcaID; }
            set
            {
                if (value >= 0)
                    _marcaID = value;
                else
                    throw new Exception("ID da marca inválido!");
            }
        }

        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (!(value == "" || value == null))
                    _nome = value.Trim();
                else
                    throw new Exception("O nome da marca é obrigatório!");
            }
        }

        private string _paisOrigem;

        public string PaisOrigem
        {
            get { return _paisOrigem; }
            set { _paisOrigem = value; }
        }
    }
}
