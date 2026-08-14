namespace CentralImpressao.Core.Entities
{
  public class UnidadeMedida
  {
    public int Id { get; set; }
    public string Sigla { get; set; }       // Ex: UN, JG, KIT, CX
    public string Descricao { get; set; }   // Ex: "Unidade", "Jogo", "Kit"

    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
  }
}