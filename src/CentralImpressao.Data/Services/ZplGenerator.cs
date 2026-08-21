using System.Text;
using CentralImpressao.Core.Entities;

namespace CentralImpressao.Data.Services
{
  public class ZplGenerator
  {
    private const int LarguraColuna = 320; // 40mm por coluna, a 203dpi
    private const int AlturaEtiqueta = 200; // 25mm de altura
    private const int LarguraTotal = LarguraColuna * 2; // 80mm (2 colunas)

    public string GerarZplParaImpressao(List<ItemImpressao> itens)
    {
      var todasEtiquetas = new List<Produto>();
      foreach (var item in itens)
      {
        for (int i = 0; i < item.QuantidadeEtiquetas; i++)
          todasEtiquetas.Add(item.Produto);
      }

      var sb = new StringBuilder();

      for (int i = 0; i < todasEtiquetas.Count; i += 2)
      {
        var produtoEsquerda = todasEtiquetas[i];
        Produto produtoDireita = (i + 1 < todasEtiquetas.Count) ? todasEtiquetas[i + 1] : null;

        sb.Append(GerarZplParaPar(produtoEsquerda, produtoDireita));
      }

      return sb.ToString();
    }

    private string GerarZplParaPar(Produto produtoEsquerda, Produto produtoDireita)
    {
      var sb = new StringBuilder();

      sb.AppendLine("^XA");
      sb.AppendLine($"^PW{LarguraTotal}");
      sb.AppendLine($"^LL{AlturaEtiqueta}");
      sb.AppendLine("^CI28");

      sb.Append(GerarBlocoEtiqueta(produtoEsquerda, offsetX: 0));

      if (produtoDireita != null)
        sb.Append(GerarBlocoEtiqueta(produtoDireita, offsetX: LarguraColuna));

      sb.AppendLine("^XZ");

      return sb.ToString();
    }

    private string GerarBlocoEtiqueta(Produto produto, int offsetX)
    {
      var sb = new StringBuilder();
      int larguraBloco = LarguraColuna - 20;

      sb.AppendLine($"^FO{offsetX + 10},10^A0N,32,32^FB{larguraBloco},1,0,C,0");
      sb.AppendLine("^FDAUTONIVEL^FS");

      sb.AppendLine($"^FO{offsetX + 10},50^A0N,25,25^FB{larguraBloco},2,0,C,0");
      sb.AppendLine($"^FD{produto.Nome}^FS");

      sb.AppendLine($"^FO{offsetX + 10},95^A0N,23,23^FB{larguraBloco},1,0,C,0");
      sb.AppendLine($"^FDCod: {produto.Codigo}^FS");

      sb.AppendLine($"^FO{offsetX + 10},118^A0N,23,23^FB{larguraBloco},1,0,C,0");
      sb.AppendLine($"^FDRef: {produto.Referencia}^FS");

      sb.AppendLine($"^FO{offsetX + 10},150^A0N,23,23^FB{larguraBloco},1,0,C,0");
      sb.AppendLine($"^FD{produto.UnidadeMedida?.Sigla} | Qtd: {produto.Quantidade}^FS");

      return sb.ToString();
    }
  }
}