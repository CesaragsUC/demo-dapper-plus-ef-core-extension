using Bogus;
using Bogus.Extensions.Brazil;
using DemoDapperPlus.Abstractions;
using DemoDapperPlus.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DemoDapperPlus.Controllers;

[ApiController]
[Route("api/pessoa")]
public class PessoaController(IPessoaService productService) : ControllerBase
{


    [HttpGet]
    public async Task<IEnumerable<Pessoa>> Get()
    {
        return null;
    }

    [HttpPost("cadastro-em-massa")]
    public async Task<IActionResult> Post()
    {
        // 10 pessoas, cada uma com 1 a 3 endereços, sempre os mesmos dados
        var pessoas = GeneratePessoas(100000);

        // 5 pessoas, cada uma com exatamente 2 endereços, dados sempre iguais
       // var pessoasCom2Enderecos = GeneratePessoas(5, minEnd: 2, maxEnd: 2);

        // 20 pessoas, cada uma com 1 a 5 endereços, dados diferentes a cada execução
       // var pessoasAleatorias = GeneratePessoas(20, 1, 5, seed: null);


        await productService.AddAsync(pessoas);
        return Ok(new { Message = "Product updated successfully" });
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update()
    {
        return Ok(new { Message = "Product updated successfully" });
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> Delete()
    {
        return Ok(new { Message = "Product updated successfully" });
    }


    public static List<Pessoa> GeneratePessoas(int total, int minEnd = 1, int maxEnd = 3, int? seed = 123)
    {
        if (seed.HasValue) Randomizer.Seed = new Random(seed.Value);
        // Faker de Documento (dependente)
        var documentoFaker = new Faker<Documento>("pt_BR")
            .RuleFor(d => d.Id, _ => Guid.NewGuid())
            .RuleFor(d => d.CPF, f => f.Person.Cpf())
           .RuleFor(d => d.DataNascimento,
                    f => DateTime.SpecifyKind(
                            f.Date.Past(70, DateTime.UtcNow.AddYears(-18)),DateTimeKind.Utc));

        // Faker de Endereço (N)
        var enderecoFaker = new Faker<Endereco>("pt_BR")
            .RuleFor(e => e.Id, _ => Guid.NewGuid())
            .RuleFor(e => e.Logradouro, f => f.Address.StreetName())
            .RuleFor(e => e.Numero, f => f.Address.BuildingNumber())
            .RuleFor(e => e.Complemento, f => f.Random.Bool(0.3f) ? $"apto {f.Random.Int(1, 999)}" : string.Empty)
            .RuleFor(e => e.Bairro, f => f.Address.CitySuffix())
            .RuleFor(e => e.Cidade, f => f.Address.City())
            .RuleFor(e => e.Estado, f => f.Address.StateAbbr()) // ex: SP, PR, RJ...
            .RuleFor(e => e.Cep, f => f.Address.ZipCode("#####-###"));

        var faker = new Faker<Pessoa>("pt_BR")
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Person.FirstName)
            .RuleFor(p => p.Idade, f => f.Random.Int(1, 99))
            // 1–1 Documento
            .RuleFor(p => p.Documento, (f, p) =>
            {
                var d = documentoFaker.Generate();
                d.PessoaId = p.Id;
                d.Pessoa = p;
                return d;
            })
            // 1–N Endereços
            .RuleFor(p => p.Enderecos, (f, p) =>
            {
                var list = enderecoFaker.GenerateBetween(minEnd, maxEnd).ToList();
                foreach (var e in list)
                {
                    e.PessoaId = p.Id;
                    e.Pessoa = p;
                }
                return list;
            });

        return faker.Generate(total);
    }

    public static Pessoa GenerateUmaPessoa(int minEnd = 1, int maxEnd = 3, int? seed = 123)
    {
        if (seed.HasValue) Randomizer.Seed = new Random(seed.Value);
        // Faker de Documento (dependente)
        var documentoFaker = new Faker<Documento>("pt_BR")
            .RuleFor(d => d.Id, _ => Guid.NewGuid())
            .RuleFor(d => d.CPF, f => f.Person.Cpf())
            .RuleFor(d => d.DataNascimento, f => f.Person.DateOfBirth);

        // Faker de Endereço (N)
        var enderecoFaker = new Faker<Endereco>("pt_BR")
            .RuleFor(e => e.Id, _ => Guid.NewGuid())
            .RuleFor(e => e.Logradouro, f => f.Address.StreetName())
            .RuleFor(e => e.Numero, f => f.Address.BuildingNumber())
            .RuleFor(e => e.Complemento, f => f.Random.Bool(0.3f) ? $"apto {f.Random.Int(1, 999)}" : string.Empty)
            .RuleFor(e => e.Bairro, f => f.Address.CitySuffix())
            .RuleFor(e => e.Cidade, f => f.Address.City())
            .RuleFor(e => e.Estado, f => f.Address.StateAbbr()) // ex: SP, PR, RJ...
            .RuleFor(e => e.Cep, f => f.Address.ZipCode("#####-###"));

        var faker = new Faker<Pessoa>("pt_BR")
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Person.FirstName)
            .RuleFor(p => p.Idade, f => f.Random.Int(1, 99))
            // 1–1 Documento
            .RuleFor(p => p.Documento, (f, p) =>
            {
                var d = documentoFaker.Generate();
                d.PessoaId = p.Id;
                d.Pessoa = p;
                return d;
            })
            // 1–N Endereços
            .RuleFor(p => p.Enderecos, (f, p) =>
            {
                var list = enderecoFaker.GenerateBetween(minEnd, maxEnd).ToList();
                foreach (var e in list)
                {
                    e.PessoaId = p.Id;
                    e.Pessoa = p;
                }
                return list;
            });

        return faker.Generate();
    }
}