

using Domain.Contracts;
using Domain.Models.Response;
using Domain.Models.Transacao;

namespace Domain.Services
{
    public class CartaoService : ICartaoService
    {
        public async Task<SistemaResponse> ProcessarTransacao(TransacaoRequest transacao)
        {
            try
            {
                return new SistemaResponse(true);
            }
            catch (Exception ex)
            {
                return new SistemaResponse(ex);
            }
        }
    }
}
