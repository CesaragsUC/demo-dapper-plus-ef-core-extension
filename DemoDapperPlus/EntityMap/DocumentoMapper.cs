using DemoDapperPlus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoDapperPlus.EntityMap;

public class DocumentoMapper : IEntityTypeConfiguration<Documento>
{
    public void Configure(EntityTypeBuilder<Documento> builder)
    {
        builder.ToTable("Documento");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.CPF)
               .HasColumnType("varchar(15)")
               .IsRequired();

        builder.Property(d => d.UF)
               .HasColumnType("varchar(2)")
               .IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnType("timestamp with time zone");
        builder.Property(x => x.UpdatedAt).HasColumnType("timestamp with time zone");


        builder.Property(d => d.PessoaId).IsRequired();

        // Opcional: garantir unicidade da relação 1–1 por índice único
        builder.HasIndex(d => d.PessoaId).IsUnique();

        builder.HasIndex(p => p.CPF)
       .HasDatabaseName("IX_Documento_Bairro");

        builder.HasIndex(p => p.UF)
       .HasDatabaseName("IX_Documento_UF");
    }
}

// CREATE TABLE Documento(
//     Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
//     CPF VARCHAR(11) NOT NULL,
//     DataNascimento DATETIME NOT NULL,
//     UF VARCHAR(2) NOT NULL,
//     PessoaId UNIQUEIDENTIFIER NOT NULL,
//     CONSTRAINT FK_Documento_Pessoa FOREIGN KEY(PessoaId) REFERENCES Pessoa(Id)
// );
// CREATE INDEX IX_Documento_PessoaId ON Documento(PessoaId);
// CREATE INDEX IX_Documento_CPF ON Documento(CPF);