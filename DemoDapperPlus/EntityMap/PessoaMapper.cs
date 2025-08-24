using DemoDapperPlus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoDapperPlus.EntityMap;

public class PessoaMapper : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoa");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(p => p.Idade)
            .HasColumnType("integer")
            .IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnType("timestamp with time zone");
        builder.Property(x => x.UpdatedAt).HasColumnType("timestamp with time zone");


        // Índice único
        builder.HasIndex(p => p.Name)
             .HasDatabaseName("IX_Pessoa_Name");


        builder.HasIndex(p => p.Idade)
             .HasDatabaseName("IX_Pessoa_Idade");

        // 1–1 Pessoa -> Documento (Documento dependente)
        builder.HasOne(p => p.Documento)
               .WithOne(d => d.Pessoa)
               .HasForeignKey<Documento>(d => d.PessoaId) // configura FK no dependente
               .IsRequired();

        // 1–N Pessoa -> Enderecos
        builder.HasMany(p => p.Enderecos)
               .WithOne(e => e.Pessoa)
               .HasForeignKey(e => e.PessoaId)
               .IsRequired();
    }
}

//CREATE TABLE Pessoa(
//    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
//    Name VARCHAR(100) NOT NULL,
//    Idade INT NOT NULL
//);

//CREATE TABLE Documento(
//    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
//    Name VARCHAR(100) NOT NULL,
//    Description VARCHAR(200) NOT NULL,
//    PessoaId UNIQUEIDENTIFIER NOT NULL,
//    CONSTRAINT FK_Documento_Pessoa FOREIGN KEY(PessoaId) REFERENCES Pessoa(Id)
//);
