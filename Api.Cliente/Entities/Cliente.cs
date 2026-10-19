namespace Api.Cliente.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; } = DateTime.Now;

    }
}
