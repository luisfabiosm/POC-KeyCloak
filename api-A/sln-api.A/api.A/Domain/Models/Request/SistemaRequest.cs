namespace Domain.Models.Request
{
    public struct SistemaRequest
    {

        public string Nome { get; set; }
        public int Numero { get; set; }


        public SistemaRequest(string nome, int numero)
        {
            Nome = nome;
            Numero = numero;
        }
    }
}
