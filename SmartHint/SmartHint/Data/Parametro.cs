using System.Data;

namespace SmartHint.Data
{
    public class Parametro
    {
        public string Nome { get; set; }
        public SqlDbType Tipo { get; set; }
        public object Valor { get; set; }
    }
}
