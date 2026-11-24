using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class Maquina
    {
        private int _maquinaID;

        public int MaquinaID
        {
            get { return _maquinaID; }
            set
            {
                if (value >= 0)
                    _maquinaID = value;
                else
                    throw new Exception("ID da máquina inválido!");
            }
        }

        private string _numeroSerie;

        public string NumeroSerie
        {
            get { return _numeroSerie; }
            set
            {
                if (!(value == "" || value == null))
                    _numeroSerie = value.Trim().ToUpper();
                else
                    throw new Exception("O número de série é obrigatório!");
            }
        }

        private int _anoFabricacao;

        public int AnoFabricacao
        {
            get { return _anoFabricacao; }
            set
            {
                if (value >= 1950 && value <= DateTime.Now.Year)
                    _anoFabricacao = value;
                else
                    throw new Exception("Ano de fabricação inválido!");
            }
        }

        private int _horimetro;

        public int Horimetro
        {
            get { return _horimetro; }
            set
            {
                if (value >= 0)
                    _horimetro = value;
                else
                    throw new Exception("O horímetro não pode ser negativo!");
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
                    throw new Exception("O cliente da máquina é obrigatório!");
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
                    throw new Exception("O modelo da máquina é obrigatório!");
            }
        }
    }
}
