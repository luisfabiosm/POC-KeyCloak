
using Domain.Models.Request;

namespace Domain.Models.Transacao
{
    public record TransacaoRequest
    {
        public int Codigo { get; private set; } = 10001;

        public string Nome { get; private set; }
        public decimal Valor { get; private set; }


        public TransacaoRequest(SistemaRequest request)
        {
            this.Nome = request.Nome;
            this.Valor = request.Valor;
        }


    }
}
