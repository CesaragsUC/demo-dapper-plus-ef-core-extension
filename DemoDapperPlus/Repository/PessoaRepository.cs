using DemoDapperPlus.Abstractions;
using DemoDapperPlus.Entities;
using DemoDapperPlus.Infrasctructure;
using EFCore.BulkExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Diagnostics;
using Z.Dapper.Plus;

namespace DemoDapperPlus.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly NpgsqlConnection connection;
        private readonly PessoaDbContext _context;

        public PessoaRepository(PessoaDbContext context)
        {
            _context = context;
            connection =   new NpgsqlConnection(EnviromentSettings.ConnectionString);
            IsDatabaseConnected(EnviromentSettings.ConnectionString);
        }
        public async Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            return null;
        }
        public async Task<Pessoa> GetByIdAsync(Guid id)
        {
            return null;
        }

        public async Task<Pessoa> GetByNameAsync(string name)
        {
            return null;
        }

        public async Task<Pessoa> GetByCidadeAsync(string cidade)
        {
            return null;
        }

        public async Task<Pessoa> GetByEstadoAsync(string uf)
        {
            return null;
        }

        public async Task AddAsync(Pessoa pessoa)
        {
            DapperPlusManager.Entity<Pessoa>().Table("Pessoa")
                .Identity(x => x.Id, true);

           await connection.SingleInsertAsync(pessoa);
        }

        public async Task AddAsync(List<Pessoa> pessoa)
        {
            var stopwatch = new Stopwatch();

            //DapperPlusManager.Entity<Pessoa>().Table("Pessoa")
            //    .Identity(x => x.Id, true);

            // Dapper Plus
            //stopwatch.Start();
            //await connection.BulkInsertAsync(pessoa);
            //Console.WriteLine($"Dapper Plus BulkInsertAsync took: {stopwatch.ElapsedMilliseconds} ms");
            //await connection.BulkDeleteAsync(pessoa);
            //stopwatch.Reset();

            // EF Core Bulk Extensions
            stopwatch.Start();

            using var ctx = await _context.Database.BeginTransactionAsync();

            var documento = pessoa.Select(p => p.Documento).ToList();
            var enderecos = pessoa.SelectMany(p => p.Enderecos).ToList();

            await _context.BulkInsertAsync(pessoa);

            await _context.BulkInsertAsync(documento);

            await _context.BulkInsertAsync(enderecos);

            await ctx.CommitAsync();

            stopwatch.Stop();

            Console.WriteLine($"EF Core Bulk Extensions BulkInsertAsync took: {stopwatch.Elapsed:hh\\:mm\\:ss\\.fff}");
        }

        public async Task UpdateAsync(Pessoa pessoa)
        {

        }
        public async Task DeleteAsync(int id)
        {

        }

        public bool IsDatabaseConnected(string connectionString)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true; // Connection succeeded
                }
                catch (SqlException)
                {
                    return false; // Connection failed
                }
            }
        }


    }
}
