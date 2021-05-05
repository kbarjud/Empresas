namespace Empresas.Infra.Interfaces.Commands
{
    public interface ICommandResult
    {
        bool Sucesso { get; set; }
        string Mensagem { get; set; }
        object Dados { get; set; }
    }
}
