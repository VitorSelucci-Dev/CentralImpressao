public class Produto
{
  public int Id { get; set; }
  public string Codigo { get; set; }
  public string Referencia { get; set; }
  public string Marca { get; set; }
  public string CodigoBarras { get; set; }
  public string Nome { get; set; }
  public UnidadeMedida Unidade { get; set; }
  public int Quantidade { get; set; }
}