namespace DemoDapperPlus.Entities;

public class Documento : BaseEntity
{
    public string CPF { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; } = DateTime.UtcNow;
    public string UF { get; set; } = string.Empty;

    // FK do lado dependente (Documento)
    public Guid PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
}
