
using Domain.Models.Request;

namespace Domain.Models.Transacao
{
    public record TransacaoRequest
    {
        public int Codigo { get; private set; } = 10000;

        public string Nome { get; private set; }
        public int Numero { get; private set; }


        public TransacaoRequest(SistemaRequest request)
        {
            this.Nome = request.Nome;
            this.Numero = request.Numero;
        }


    }
}
