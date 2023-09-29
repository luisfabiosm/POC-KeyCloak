

using Domain.Models.Response;
using Domain.Models.Transacao;

namespace Domain.Contracts
{
    public interface ICartaoService
    {

        Task<SistemaResponse> ProcessarTransacao(TransacaoRequest transacao);
    }
}
