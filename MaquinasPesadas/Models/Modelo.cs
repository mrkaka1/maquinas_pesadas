using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class Modelo
    {
        private int _modeloID;

        public int ModeloID
        {
            get { return _modeloID; }
            set
            {
                if (value >= 0)
                    _modeloID = value;
                else
                    throw new Exception("ID do modelo inválido!");
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
                    throw new Exception("O nome do modelo é obrigatório!");
            }
        }

        private string _tipo;

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private int _potenciaCV;

        public int PotenciaCV
        {
            get { return _potenciaCV; }
            set
            {
                if (value >= 0)
                    _potenciaCV = value;
                else
                    throw new Exception("A potência não pode ser negativa!");
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
                    throw new Exception("A marca do modelo é obrigatória!");
            }
        }
    }
}
