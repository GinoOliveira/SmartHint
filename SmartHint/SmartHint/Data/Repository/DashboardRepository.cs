using Microsoft.IdentityModel.Tokens;
using SmartHint.Data.Repository;
using System.Data;
using System.Text.Json;

namespace SmartHint.Data.Repository
{
    public class DashboardRepository : BaseRepository
    {
        public string CarregarClientes(string data)
        {
            return ExecutaSql("SELECT* FROM cliente");
        }
        public string CadastroCliente(string nomeCliente, string email, string telefone, string tipoPessoa, string cpfCnpj, string inscricaoEstadual, string genero, string dataNascimento, string senha, string isento, string bloqueado)
        {
            if (dataNascimento == "")
            {
                dataNascimento = "2024-01-01";
            }
            AddParametro("@nomeRazaoSocial", SqlDbType.VarChar, nomeCliente);
            AddParametro("@email", SqlDbType.VarChar, email);
            AddParametro("@telefone", SqlDbType.VarChar, telefone);
            AddParametro("@tipoPessoa", SqlDbType.Char, tipoPessoa);
            AddParametro("@cpfCnpj", SqlDbType.VarChar, cpfCnpj);
            AddParametro("@inscricaoEst", SqlDbType.VarChar, inscricaoEstadual);
            AddParametro("@genero", SqlDbType.VarChar, genero);
            AddParametro("@dtNascimento", SqlDbType.DateTime, dataNascimento);
            AddParametro("@senha", SqlDbType.VarChar, senha);
            AddParametro("@isento", SqlDbType.Bit, isento);
            AddParametro("@bloqueado", SqlDbType.Bit, bloqueado);
            return ExecutaSql("INSERT INTO Cliente (nomeRazaoSocial,email,telefone,tipoPessoa,cpfCnpj,inscricaoEst,genero,dtNascimento,bloqueado,isento,senha) VALUES (@nomeRazaoSocial,@email,@telefone,@tipoPessoa,@cpfCnpj,@inscricaoEst,@genero,@dtNascimento,@bloqueado,@isento,@senha);");
        }
        public string AtualizarCadastro(string nomeCliente, string email, string telefone, string tipoPessoa, string cpfCnpj, string inscricaoEstadual, string genero, string dataNascimento, string senha, string isento, string bloqueado)
        {
            if (dataNascimento == "")
            {
                dataNascimento = "2024-01-01";
            }
            AddParametro("@nomeRazaoSocial", SqlDbType.VarChar, nomeCliente);
            AddParametro("@email", SqlDbType.VarChar, email);
            AddParametro("@telefone", SqlDbType.VarChar, telefone);
            AddParametro("@tipoPessoa", SqlDbType.Char, tipoPessoa);
            AddParametro("@cpfCnpj", SqlDbType.VarChar, cpfCnpj);
            AddParametro("@inscricaoEst", SqlDbType.VarChar, inscricaoEstadual);
            AddParametro("@genero", SqlDbType.VarChar, genero);
            AddParametro("@dtNascimento", SqlDbType.DateTime, dataNascimento);
            AddParametro("@senha", SqlDbType.VarChar, senha);
            AddParametro("@isento", SqlDbType.Bit, isento);
            AddParametro("@bloqueado", SqlDbType.Bit, bloqueado);
            return ExecutaSql("UPDATE Cliente SET nomeRazaoSocial = @nomeRazaoSocial, email = @email, telefone = @telefone, tipoPessoa = @tipoPessoa, cpfCnpj = @cpfCnpj, inscricaoEst = @inscricaoEst, genero = @genero, dtNascimento = @dtNascimento, bloqueado = @bloqueado, isento = @isento, senha = @senha WHERE cpfCnpj = @cpfCnpj;");
        }
        
    }
}
