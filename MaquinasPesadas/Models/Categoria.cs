using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Models
{
    internal class Categoria
    {
        private int _categoriaID;
        public int CategoriaID
        {
            get { return _categoriaID; }
            set
            {
                if (value >= 0)
                    _categoriaID = value;
                else
                    throw new Exception("ID da categoria inválido!");
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
                    throw new Exception("A descrição da categoria é obrigatório!");
            }
        }
    }
}
