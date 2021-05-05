using Empresas.Dominio.Commands.Empresas.Input;
using Empresas.Infra.Interfaces.Commands;

namespace Empresas.Dominio.Interfaces.Handlers
{
    public interface IEmpresaHandler
    {
        ICommandResult Handle(AddEmpresaCommand comando);
        ICommandResult Handle(UpdateEmpresaCommand comando);
        ICommandResult Handle(string cnpj);
    }
}
