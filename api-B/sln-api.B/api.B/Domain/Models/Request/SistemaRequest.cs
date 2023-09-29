namespace Domain.Models.Request
{
    public struct SistemaRequest
    {

        public string Nome { get; set; }
        public decimal Valor { get; set; }


        public SistemaRequest(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }
    }
}
