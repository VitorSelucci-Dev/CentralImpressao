using CentralImpressao.Core.Entities;

namespace CentralImpressao.Core.Interfaces
{
  public interface IUnidadeMedidaRepository
  {
    Task<List<UnidadeMedida>> ObterTodasAsync();
    Task<UnidadeMedida> ObterPorIdAsync(int id);
    Task AdicionarAsync(UnidadeMedida unidadeMedida);
    Task AtualizarAsync(UnidadeMedida unidadeMedida);
    Task RemoverAsync(int id);
  }
}

