namespace DemoDapperPlus.Entities;

public class Endereco : BaseEntity
{
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Complemento { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;

    // FK do lado N
    public Guid PessoaId { get; set; }
    public Pessoa Pessoa { get; set; } = null!;
}
