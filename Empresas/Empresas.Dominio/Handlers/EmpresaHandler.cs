using Empresas.Dominio.Commands;
using Empresas.Dominio.Commands.Empresas.Input;
using Empresas.Dominio.Commands.Empresas.Output;
using Empresas.Dominio.Entidades;
using Empresas.Dominio.Interfaces.Handlers;
using Empresas.Dominio.Interfaces.Repositorios;
using Empresas.Infra.Interfaces.Commands;
using System;

namespace Empresas.Dominio.Handlers
{
    public class EmpresaHandler : IEmpresaHandler
    {
        private readonly IEmpresaRepositorio _repositorio;

        public EmpresaHandler(IEmpresaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(AddEmpresaCommand comando)
        {

            try
            {
                //fazer validaçãoo do command
                Empresa empresa = new Empresa(
                    comando.CNPJ,
                    comando.Inscricao_Estadual,
                    comando.Nome_Empresarial,
                    comando.Nome_Fantasia,
                    comando.Atividade_Economica,
                    comando.Telefone_Fixo,
                    comando.Whatsapp,
                    comando.Logradouro,
                    comando.Num_Logradouro,
                    comando.Complemento,
                    comando.CEP,
                    comando.Bairro,
                    comando.Municipio,
                    comando.UF,
                    comando.Status,
                    comando.Data_Abertura,
                    comando.Data_Modificacao,
                    comando.Data_Encerramento);

                _repositorio.Inserir(empresa);

                var retorno = new CommandResult(true, "Empresa Cadastrada com Sucesso", new
                {
                    CNPJ = empresa.CNPJ,
                    Inscricao_Estadual = empresa.Inscricao_Estadual,
                    Nome_Empresarial = empresa.Nome_Empresarial,
                    Nome_Fantasia = empresa.Nome_Fantasia,
                    Atividade_Economica = empresa.Atividade_Economica,
                    Telefone_Fixo = empresa.Telefone_Fixo,
                    Whatsapp = empresa.Whatsapp,
                    Logradouro = empresa.Logradouro,
                    Num_Logradouro = empresa.Num_Logradouro,
                    Complemento = empresa.Complemento,
                    CEP = empresa.CEP,
                    Bairro = empresa.Bairro,
                    Municipio = empresa.Municipio,
                    UF = empresa.UF,
                    Status = empresa.Status,
                    Data_Abertura = empresa.Data_Abertura,
                    Data_Modificacao = empresa.Data_Modificacao,
                    Data_Encerramento = empresa.Data_Encerramento,
                });

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(UpdateEmpresaCommand comando)
        {
            try
            {
                //fazer validação do command

                Empresa empresa = new Empresa(
                    comando.CNPJ,
                    comando.Inscricao_Estadual,
                    comando.Nome_Empresarial,
                    comando.Nome_Fantasia,
                    comando.Atividade_Economica,
                    comando.Telefone_Fixo,
                    comando.Whatsapp,
                    comando.Logradouro,
                    comando.Num_Logradouro,
                    comando.Complemento,
                    comando.CEP,
                    comando.Bairro,
                    comando.Municipio,
                    comando.UF,
                    comando.Status,
                    comando.Data_Abertura,
                    comando.Data_Modificacao,
                    comando.Data_Encerramento);

                _repositorio.Alterar(empresa);

                var retorno = new CommandResult(true, "Empresa Alterada com Sucesso", new
                {
                    CNPJ = empresa.CNPJ,
                    Inscricao_Estadual = empresa.Inscricao_Estadual,
                    Nome_Empresarial = empresa.Nome_Empresarial,
                    Nome_Fantasia = empresa.Nome_Fantasia,
                    Atividade_Economica = empresa.Atividade_Economica,
                    Telefone_Fixo = empresa.Telefone_Fixo,
                    Whatsapp = empresa.Whatsapp,
                    Logradouro = empresa.Logradouro,
                    Num_Logradouro = empresa.Num_Logradouro,
                    Complemento = empresa.Complemento,
                    CEP = empresa.CEP,
                    Bairro = empresa.Bairro,
                    Municipio = empresa.Municipio,
                    UF = empresa.UF,
                    Status = empresa.Status,
                    Data_Abertura = empresa.Data_Abertura,
                    Data_Modificacao = empresa.Data_Modificacao,
                    Data_Encerramento = empresa.Data_Encerramento,
                });

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(string cnpj)
        {
            try
            {
                //fazer validação do id

                _repositorio.Excluir(cnpj);

                var retorno = new CommandResult(true, "Empresa Excluída com Sucesso", new
                {
                    CNPJ = cnpj
                });

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
