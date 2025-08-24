using DemoDapperPlus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoDapperPlus.EntityMap;

public class EnderecoMapper : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("Endereco");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Logradouro).HasColumnType("varchar(120)").IsRequired();
        builder.Property(e => e.Numero).HasColumnType("varchar(20)").IsRequired();
        builder.Property(e => e.Complemento).HasColumnType("varchar(100)");
        builder.Property(e => e.Bairro).HasColumnType("varchar(80)").IsRequired();
        builder.Property(e => e.Cidade).HasColumnType("varchar(80)").IsRequired();
        builder.Property(e => e.Estado).HasColumnType("varchar(2)").IsRequired();
        builder.Property(e => e.Cep).HasColumnType("varchar(10)").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnType("timestamp with time zone");
        builder.Property(x => x.UpdatedAt).HasColumnType("timestamp with time zone");

        builder.Property(e => e.PessoaId).IsRequired();

        builder.HasIndex(p => p.Logradouro)
               .HasDatabaseName("IX_Endereco_Logradouro");

        builder.HasIndex(p => p.Numero)
               .HasDatabaseName("IX_Endereco_Numero");

        builder.HasIndex(p => p.Complemento)
               .HasDatabaseName("IX_Endereco_Complemento");

        builder.HasIndex(p => p.Bairro)
               .HasDatabaseName("IX_Endereco_Bairro");

        builder.HasIndex(p => p.Cep)
               .HasDatabaseName("IX_Endereco_Cep");

        //Índice em múltiplas colunas
        //EF ira cria algo como: CREATE INDEX IX_Endereco_Cidade_Estado ON Endereco (Cidade, Estado);
        builder.HasIndex(p => new { p.Cidade, p.Estado});

    }
}

// CREATE TABLE Endereco(
//     Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
//     Logradouro VARCHAR(120) NOT NULL,
//     Numero VARCHAR(20) NOT NULL,
//     Complemento VARCHAR(100),
//     Bairro VARCHAR(80) NOT NULL,
//     Cidade VARCHAR(80) NOT NULL,
//     Estado VARCHAR(2) NOT NULL,
//     Cep VARCHAR(10) NOT NULL,
//     PessoaId UNIQUEIDENTIFIER NOT NULL,
//     CONSTRAINT FK_Endereco_Pessoa FOREIGN KEY(PessoaId) REFERENCES Pessoa(Id)
// );
// CREATE INDEX IX_Endereco_PessoaId ON Endereco(PessoaId);
// CREATE INDEX IX_Endereco_Cep ON Endereco(Cep);
// CREATE INDEX IX_Endereco_Cidade ON Endereco(Cidade);
// CREATE INDEX IX_Endereco_Estado ON Endereco(Estado);
// CREATE INDEX IX_Endereco_Bairro ON Endereco(Bairro);
// CREATE INDEX IX_Endereco_Logradouro ON Endereco(Logradouro);
// CREATE INDEX IX_Endereco_Numero ON Endereco(Numero);
// CREATE INDEX IX_Endereco_Complemento ON Endereco(Complemento);