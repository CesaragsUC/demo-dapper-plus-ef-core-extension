using DemoDapperPlus.Entities;

namespace DemoDapperPlus.Abstractions;

public interface IPessoaRepository
{
    Task<IEnumerable<Pessoa>> GetAllAsync();
    Task<Pessoa> GetByIdAsync(Guid id);
    Task<Pessoa> GetByNameAsync(string name);
    Task<Pessoa> GetByCidadeAsync(string cidade);
    Task<Pessoa> GetByEstadoAsync(string uf);
    Task AddAsync(Pessoa product);
    Task AddAsync(List<Pessoa> product);
    Task UpdateAsync(Pessoa product);
    Task DeleteAsync(int id);
}
