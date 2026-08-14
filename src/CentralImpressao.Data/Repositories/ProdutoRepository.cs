using CentralImpressao.Core.Entities;
using CentralImpressao.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CentralImpressao.Data.Repositories
{
  public class ProdutoRepository : IProdutoRepository
  {
    private readonly AppDbContext _context;
    public ProdutoRepository(AppDbContext context)
    {
      _context = context;
    }
    public async Task<List<Produto>> ObterTodosAsync()
    {
      return await _context.Produtos
        .Include(p => p.UnidadeMedida)
        .OrderBy(p => p.Nome)
        .ToListAsync();
    }
    public async Task<Produto> ObterPorIdAsync(int id)
    {
      return await _context.Produtos
        .Include(p => p.UnidadeMedida)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<Produto> ObterPorCodigoBarrasAsync(string codigoBarras)
    {
      return await _context.Produtos
        .Include(p => p.UnidadeMedida)
        .FirstOrDefaultAsync(p => p.CodigoBarras == codigoBarras);
    }
    public async Task AdicionarAsync(Produto produto)
    {
      _context.Produtos.Add(produto);
      await _context.SaveChangesAsync();
    }
    public async Task AtualizarAsync(Produto produto)
    {
      _context.Produtos.Update(produto);
      await _context.SaveChangesAsync();
    }
    public async Task RemoverAsync(int id)
    {
      var entidade = await _context.Produtos.FindAsync(id);
      if (entidade != null)
      {
        _context.Produtos.Remove(entidade);
        await _context.SaveChangesAsync();
      }
    }
  }
}