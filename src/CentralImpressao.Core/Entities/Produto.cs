namespace CentralImpressao.Core.Entities
{
  public class Produto
  {
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Referencia { get; set; }
    public string Marca { get; set; }
    public string CodigoBarras { get; set; }
    public string Nome { get; set; }

    public int UnidadeMedidaId { get; set; }
    public UnidadeMedida UnidadeMedida { get; set; }

    public int Quantidade { get; set; }
  }
}