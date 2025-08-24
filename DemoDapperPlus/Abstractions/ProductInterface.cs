using DemoDapperPlus.Entities;

namespace DemoDapperPlus.Abstractions;

public interface IPessoaService
{
    Task<IEnumerable<Pessoa>> GetAllAsync();
    Task<Pessoa> GetByIdAsync(Guid id);
    Task AddAsync(Pessoa product);
    Task AddAsync(List<Pessoa> product);
    Task UpdateAsync(Pessoa product);
    Task DeleteAsync(int id);
}
