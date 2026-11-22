using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class Cliente
    {
        private int _clienteID;
        public int ClienteID
        {
            get { return _clienteID; }
            set
            {
                if (value >= 0)
                    _clienteID = value;
                else
                    throw new Exception("ID de Cliente inválido!");
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
                    throw new Exception("O nome é obrigatório!");
            }
        }

        private string _cpfCpnj;

        public string CpfCnpj
        {
            get { return _cpfCpnj; }
            set
            {
                if (!(value == "" || value == null))
                    _cpfCpnj = value.Trim();
                else
                    throw new Exception("O CPF/CNPJ é obrigatório!");
            }
        }

        private string _tipoPessoa;

        public string TipoPessoa
        {
            get { return _tipoPessoa; }
            set
            {
                if (value != null && (value.ToUpper() == "F" || value.ToUpper() == "J"))
                    _tipoPessoa = value.ToUpper();
                else
                    throw new Exception("O Tipo de Pessoa é obrigatório! ( F / J )");
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
            set {
                if (string.IsNullOrWhiteSpace(value))
                    _uf = null;
                else if (value.Trim().Length == 2)
                    _uf = value.Trim().ToUpper();
                else
                    throw new Exception("A UF deve ter 2 letras!");
            }
        }

        private DateOnly _dataCadastro;

        public DateOnly DataCadastro
        {
            get { return _dataCadastro; }
            set
            {
                if (value <= DateOnly.FromDateTime(DateTime.Now))
                    _dataCadastro = value;
                else
                    throw new Exception("A data de cadastro não pode ser maior que a data atual!");
            }
        }
    }
}
