namespace CentralImpressao.Data.Services
{
  public class ImpressoraService
  {
    public bool Imprimir(string nomeImpressora, string zpl)
    {
      return RawPrinterHelper.SendStringToPrinter(nomeImpressora, zpl);
    }
  }
}