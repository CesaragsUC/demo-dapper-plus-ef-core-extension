namespace DemoDapperPlus.Entities;

public class Pessoa : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Idade { get; set; }


    // 1–1
    public Documento Documento { get; set; }

    // 1–N
    public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();

}

//CREATE TABLE "Products" (
//    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
//    "Name" TEXT NOT NULL,
//    "Price" NUMERIC(18,2) NOT NULL
//);
