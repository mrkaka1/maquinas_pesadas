using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class Funcionario
    {
        private int _funcionarioID;
        public int FuncionarioID
        {
            get { return _funcionarioID; }
            set
            {
                if (value >= 0)
                    _funcionarioID = value;
                else
                    throw new Exception("ID de funcionario inválido!");
            }   
        }

        private int _matricula;
        public int Matricula
        {
            get { return _matricula; }
            set
            {
                if (value >= 0)
                    _matricula = value;
                else
                    throw new Exception("Matricula inválida !");
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

        private string _cpf;

        public string Cpf
        {
            get { return _cpf; }
            set
            {
                if (!(value == "" || value == null))
                    _cpf = value.Trim();
                else
                    throw new Exception("O CPF é obrigatório!");
            }
        }

        private string _cargo;

        public string Cargo
        {
            get { return _cargo; }
            set { _cargo = value.Trim(); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private DateOnly _dataAdmissao;

        public DateOnly DataAdmissao
        {
            get { return _dataAdmissao; }
            set
            {
                if (value <= DateOnly.FromDateTime(DateTime.Now))
                    _dataAdmissao = value;
                else
                    throw new Exception("A data de admissao não pode ser maior que a data atual!");
            }
        }

        private bool _ativo = true;
        public bool Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }
    }
}
