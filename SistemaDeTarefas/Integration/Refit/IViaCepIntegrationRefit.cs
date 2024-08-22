using Refit;
using SistemaDeTarefas.Integration.Response;

namespace SistemaDeTarefas.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}
