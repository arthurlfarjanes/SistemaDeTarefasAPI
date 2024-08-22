using SistemaDeTarefas.Integration.Interfaces;
using SistemaDeTarefas.Integration.Refit;

namespace SistemaDeTarefas.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }

        public async Task<IViaCepIntegration> ObterDadosViaCep(string cep)
        {
            var responseData = await _viaCepIntegrationRefit.ObterDadosViaCep(cep);

            if(responseData != null && responseData.IsSuccessStatusCode)
            {
                return (IViaCepIntegration)responseData.Content;
                //return responseData.Content;
            }

            return null;
        }
    }
}
