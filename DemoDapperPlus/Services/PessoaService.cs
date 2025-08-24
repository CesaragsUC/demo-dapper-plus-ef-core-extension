using DemoDapperPlus.Abstractions;
using DemoDapperPlus.Entities;

namespace DemoDapperPlus.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _productRepository;
        public PessoaService(IPessoaRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }
        public async Task<Pessoa> GetByIdAsync(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(Pessoa pessoa)
        {
            await _productRepository.AddAsync(pessoa);
        }
        public async Task UpdateAsync(Pessoa pessoa)
        {
            await _productRepository.UpdateAsync(pessoa);
        }
        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task AddAsync(List<Pessoa> pessoa)
        {
            await _productRepository.AddAsync(pessoa);
        }
    }
}
