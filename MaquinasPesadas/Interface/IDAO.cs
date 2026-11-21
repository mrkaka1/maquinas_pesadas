using System;
using System.Collections.Generic;
using System.Text;

namespace MaquinasPesadas.Interface
{
    internal interface IDAO<T>
    {
        void Insert(T t);
        void Atualizar(T t);
        void Deletar(int id);
        List<T> GetAll();
        T BuscarID(int id);
    }
}
