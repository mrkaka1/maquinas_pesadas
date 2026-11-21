using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class Fornecedor
    {
        private int _fornecedorID;
        public int ForncedorID
        {
            get { return _fornecedorID; }
            set
            {
                if (value >= 0)
                    _fornecedorID = value;
                else
                    throw new Exception("ID de fornecedor inválido!");
            }
        }

        private string _razao;

        public string Razao
        {
            get { return _razao; }
            set
            {
                if (!(value == "" || value == null))
                    _razao = value.Trim();
                else
                    throw new Exception("A razão social é obrigatório!");
            }
        }

        private string _cpnj;

        public string CNPJ
        {
            get { return _cpnj; }
            set
            {
                if (!(value == "" || value == null))
                    _cpnj = value.Trim();
                else
                    throw new Exception("O CNPJ é obrigatório!");
            }
        }

        private string _telefone;

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _cidade;

        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }

        private string _uf;

        public string UF
        {
            get { return _uf; }
            set { _uf = value; }
        }


    }
}
