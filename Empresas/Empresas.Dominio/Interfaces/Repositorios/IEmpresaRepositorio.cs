using Empresas.Dominio.Entidades;
using Empresas.Dominio.Queries;
using System.Collections.Generic;

namespace Empresas.Dominio.Interfaces.Repositorios
{
    public interface IEmpresaRepositorio
    {
        void Inserir(Empresa empresas);
        void Alterar(Empresa empresas);
        void Excluir(string cnpj);

        IEnumerable<EmpresaQueryResult> ListarEmpresas();

        EmpresaQueryResult ListarEmpresa(string cnpj);
    }
}
