using Dapper;
using Empresas.Dominio.Entidades;
using Empresas.Dominio.Interfaces.Repositorios;
using Empresas.Dominio.Queries;
using Empresas.Infra.Data.DataContexts;
using System;
using System.Collections.Generic;
using System.Data;

namespace Empresas.Infra.Data.Repositorio
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContext _dataContext;

        public EmpresaRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Empresa empresas)
        {
            try
            {
                _parametros.Add("@CNPJ", empresas.CNPJ, DbType.String);
                _parametros.Add("@Inscricao_Estadual", empresas.Inscricao_Estadual, DbType.String);
                _parametros.Add("@Nome_Empresarial", empresas.Nome_Empresarial, DbType.String);
                _parametros.Add("@Nome_Fantasia", empresas.Nome_Fantasia, DbType.String);
                _parametros.Add("@Atividade_Economica", empresas.Atividade_Economica, DbType.String);
                _parametros.Add("@Telefone_Fixo", empresas.Telefone_Fixo, DbType.String);
                _parametros.Add("@Whatsapp", empresas.Whatsapp, DbType.String);
                _parametros.Add("@Logradouro", empresas.Logradouro, DbType.String);
                _parametros.Add("@Num_Logradouro", empresas.Num_Logradouro, DbType.Int16);
                _parametros.Add("@Complemento", empresas.Complemento, DbType.String);
                _parametros.Add("@CEP", empresas.CEP, DbType.String);
                _parametros.Add("@Bairro", empresas.Bairro, DbType.String);
                _parametros.Add("@Municipio", empresas.Municipio, DbType.String);
                _parametros.Add("@UF", empresas.UF, DbType.String);
                _parametros.Add("@Status", empresas.Status, DbType.String);
                _parametros.Add("@Data_Abertura", empresas.Data_Abertura, DbType.DateTime);
                _parametros.Add("@Data_Modificacao", empresas.Data_Modificacao, DbType.DateTime);
                _parametros.Add("@Data_Encerramento", empresas.Data_Encerramento, DbType.DateTime);

                string sql = @"INSERT INTO cadastro_empresas (CNPJ, INSCRICAO_ESTADUAL, NOME_EMPRESARIAL, NOME_FANTASIA, ATIVIDADE_ECONOMICA, TELEFONE_FIXO, WHATSAPP, LOGRADOURO,
                              NUM_LOGRADOURO, COMPLEMENTO, CEP, BAIRRO, MUNICIPIO, UF, STATUS, DATA_ABERTURA, DATA_MODIFICACAO, DATA_ENCERRAMENTO) 
                              VALUES (@CNPJ, @Inscricao_Estadual, @Nome_Empresarial, @Nome_Fantasia, @Atividade_Economica, @Telefone_Fixo, @Whatsapp, @Logradouro,
                              @Num_Logradouro, @Complemento, @CEP, @Bairro, @Municipio, @UF, @Status, @Data_Abertura, @Data_Modificacao, @Data_Encerramento)";

                _dataContext.Connection.Execute(sql, _parametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<Empresa> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Alterar(Empresa empresas)
        {
            try
            {
                _parametros.Add("@CNPJ", empresas.CNPJ, DbType.String);
                _parametros.Add("@Inscricao_Estadual", empresas.Inscricao_Estadual, DbType.String);
                _parametros.Add("@Nome_Empresarial", empresas.Nome_Empresarial, DbType.String);
                _parametros.Add("@Nome_Fantasia", empresas.Nome_Fantasia, DbType.String);
                _parametros.Add("@Atividade_Economica", empresas.Atividade_Economica, DbType.String);
                _parametros.Add("@Telefone_Fixo", empresas.Telefone_Fixo, DbType.String);
                _parametros.Add("@Whatsapp", empresas.Whatsapp, DbType.String);
                _parametros.Add("@Logradouro", empresas.Logradouro, DbType.String);
                _parametros.Add("@Num_Logradouro", empresas.Num_Logradouro, DbType.Int16);
                _parametros.Add("@Complemento", empresas.Complemento, DbType.String);
                _parametros.Add("@CEP", empresas.CEP, DbType.String);
                _parametros.Add("@Bairro", empresas.Bairro, DbType.String);
                _parametros.Add("@Municipio", empresas.Municipio, DbType.String);
                _parametros.Add("@UF", empresas.UF, DbType.String);
                _parametros.Add("@Status", empresas.Status, DbType.String);
                _parametros.Add("@Data_Abertura", empresas.Data_Abertura, DbType.DateTime);
                _parametros.Add("@Data_Modificacao", empresas.Data_Modificacao, DbType.DateTime);
                _parametros.Add("@Data_Encerramento", empresas.Data_Encerramento, DbType.DateTime);

                string sql = @"UPDATE cadastro_empresas SET INSCRICAO_ESTADUAL=@Inscricao_Estadual, NOME_EMPRESARIAL=@Nome_Empresarial, NOME_FANTASIA=@Nome_Fantasia, 
                            ATIVIDADE_ECONOMICA=@Atividade_Economica, TELEFONE_FIXO=@Telefone_Fixo, WHATSAPP=@Whatsapp, LOGRADOURO=@Logradouro, 
                            NUM_LOGRADOURO=@Num_Logradouro, COMPLEMENTO=@Complemento, CEP=@CEP, BAIRRO=@Bairro, MUNICIPIO=@Municipio, UF=@UF, 
                            STATUS=@Status, DATA_ABERTURA=@Data_Abertura, DATA_MODIFICACAO=@Data_Modificacao, DATA_ENCERRAMENTO=@Data_Encerramento where CNPJ=@CNPJ";

                _dataContext.Connection.Execute(sql, _parametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(string cnpj)
        {
            try
            {
                _parametros.Add("@CNPJ", cnpj, DbType.String);

                string sql = @"DELETE FROM cadastro_empresas where CNPJ=@CNPJ";

                _dataContext.Connection.Execute(sql, _parametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<EmpresaQueryResult> ListarEmpresas() => 
            _dataContext.Connection.Query<EmpresaQueryResult>("SELECT * FROM cadastro_empresas");

        public EmpresaQueryResult ListarEmpresa(string cnpj) =>
           _dataContext.Connection.QueryFirstOrDefault<EmpresaQueryResult>("SELECT * FROM cadastro_empresas WHERE CNPJ=@CNPJ", new { CNPJ = cnpj });
    }
}
