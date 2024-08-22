namespace SistemaDeTarefas.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<IViaCepIntegration> ObterDadosViaCep(string cep);
    }
}
