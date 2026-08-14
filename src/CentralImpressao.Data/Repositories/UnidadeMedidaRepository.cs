using CentralImpressao.Core.Entities;
using CentralImpressao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CentralImpressao.Data.Repositories
{
  public class UnidadeMedidaRepository : IUnidadeMedidaRepository
  {
    private readonly AppDbContext _context;
    public UnidadeMedidaRepository(AppDbContext context)
    {
      _context = context;
    }
    public async Task<List<UnidadeMedida>> ObterTodasAsync()
    {
      return await _context.UnidadesMedida.OrderBy(u => u.Sigla).ToListAsync();
    }
    public async Task<UnidadeMedida> ObterPorIdAsync(int id)
    {
      return await _context.UnidadesMedida.FindAsync(id);
    }
    public async Task AdicionarAsync(UnidadeMedida unidadeMedida)
    {
      _context.UnidadesMedida.Add(unidadeMedida);
      await _context.SaveChangesAsync();
    }
    public async Task AtualizarAsync(UnidadeMedida unidadeMedida)
    {
      _context.UnidadesMedida.Update(unidadeMedida);
      await _context.SaveChangesAsync();

    }
    public async Task RemoverAsync(int id)
    {
      var entidade = await _context.UnidadesMedida.FindAsync(id);
      if (entidade != null)
      {
        _context.UnidadesMedida.Remove(entidade);
        await _context.SaveChangesAsync();
      }
    }

    Task<UnidadeMedida> IUnidadeMedidaRepository.ObterPorIdAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}