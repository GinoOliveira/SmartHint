using SmartHint.Data;
using System.Data;
using System.Drawing;

namespace SmartHint.Data
{
    public class Parametro<TDataType> : Parametro
    {
        public Parametro(string nome, SqlDbType tipo, TDataType valor)
        {
            Nome = nome;
            Tipo = tipo;
            if (typeof(TDataType) == typeof(string))
            {
                Valor = valor == null ? string.Empty : valor.ToString().Trim();
            }
            else
            {
                Valor = valor;
            }
        }
    }
}
