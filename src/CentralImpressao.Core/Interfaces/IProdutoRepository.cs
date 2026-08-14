using CentralImpressao.Core.Entities;

namespace CentralImpressao.Core.Interfaces
{
  public interface IProdutoRepository
  {
    Task<List<Produto>> ObterTodosAsync();
    Task<Produto> ObterPorIdAsync(int id);
    Task<Produto> ObterPorCodigoBarrasAsync(string codigoBarras);
    Task AdicionarAsync(Produto produto);
    Task AtualizarAsync(Produto produto);
    Task RemoverAsync(int id);
  }
}