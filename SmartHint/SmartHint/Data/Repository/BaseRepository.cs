using SmartHint.Data;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
namespace SmartHint.Data.Repository
{
    public class BaseRepository
    {

        private readonly string _connectionString;
        protected List<Parametro> _parametros;

        public BaseRepository()
        {
            //177.70.123.193 ATUAL PRODUCAO
            _connectionString = "Data Source=desktop-96pbl4q\\sqlexpress;Initial Catalog=SmartHint;Integrated Security=True;TrustServerCertificate=True; ";
            _parametros = new List<Parametro>();
        }

        public string ExecutarProcedure(string procedure)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(procedure, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                string sqlquery = procedure + " ";
                foreach (var parametro in _parametros)
                {
                    cmd.Parameters.Add(parametro.Nome, parametro.Tipo).Value = parametro.Valor;
                    sqlquery += "" + parametro.Nome + " = " + $@"'{parametro.Valor}', ";
                }
                sqlquery = sqlquery.Substring(0, sqlquery.Length - 1);
                _parametros.Clear();

                con.Open();

                using (var dataReader = cmd.ExecuteReader())
                {
                    var tabela = new DataTable();
                    tabela.Load(dataReader);

                    return ConvertDataTabletoJSON(tabela);
                }
            }
        }
        public DataTable ExecutarProcedureTable(string procedure)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(procedure, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                string sqlquery = procedure + " ";
                foreach (var parametro in _parametros)
                {
                    cmd.Parameters.Add(parametro.Nome, parametro.Tipo).Value = parametro.Valor;
                    sqlquery += "" + parametro.Nome + " = " + $@"'{parametro.Valor}', ";
                }
                sqlquery = sqlquery.Substring(0, sqlquery.Length - 1);
                _parametros.Clear();

                con.Open();

                using (var dataReader = cmd.ExecuteReader())
                {
                    var tabela = new DataTable();
                    tabela.Load(dataReader);

                    return tabela;
                }
            }
        }

        public DataTable ExecutaSqlTable(string procedure)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(procedure, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 300;
                string sqlquery = procedure + " ";
                foreach (var parametro in _parametros)
                {
                    cmd.Parameters.Add(parametro.Nome, parametro.Tipo).Value = parametro.Valor;
                    sqlquery += "" + parametro.Nome + " = " + $@"'{parametro.Valor}', ";
                }
                sqlquery = sqlquery.Substring(0, sqlquery.Length - 1);
                _parametros.Clear();

                con.Open();

                using (var dataReader = cmd.ExecuteReader())
                {
                    var tabela = new DataTable();
                    tabela.Load(dataReader);

                    return tabela;
                }
            }
        }


        public string ExecutaSql(string procedure)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(procedure, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 300;
                string sqlquery = procedure + " ";
                foreach (var parametro in _parametros)
                {
                    cmd.Parameters.Add(parametro.Nome, parametro.Tipo).Value = parametro.Valor;
                    sqlquery += "" + parametro.Nome + " = " + $@"'{parametro.Valor}', ";
                }
                sqlquery = sqlquery.Substring(0, sqlquery.Length - 1);
                _parametros.Clear();

                con.Open();

                using (var dataReader = cmd.ExecuteReader())
                {
                    var tabela = new DataTable();
                    tabela.Load(dataReader);

                    return ConvertDataTabletoJSON(tabela);
                }
            }
        }

        public void AddParametro<TDataType>(string nome, SqlDbType tipo, TDataType valor)
        {
            _parametros.Add(new Parametro<TDataType>(nome, tipo, valor));
        }
        public void ClearParametros()
        {
            _parametros.Clear();
        }

        public string ConvertDataTabletoJSON(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return JsonSerializer.Serialize(rows);
        }
    }
}
