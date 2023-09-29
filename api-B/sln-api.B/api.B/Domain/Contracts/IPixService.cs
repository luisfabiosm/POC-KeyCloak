

using Domain.Models.Response;
using Domain.Models.Transacao;

namespace Domain.Contracts
{
    public interface IPixService
    {

        Task<SistemaResponse> ProcessarTransacao(TransacaoRequest transacao);
    }
}
