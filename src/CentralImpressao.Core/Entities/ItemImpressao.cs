using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CentralImpressao.Core.Entities
{
  public class ItemImpressao : INotifyPropertyChanged
  {
    public Produto Produto { get; set; }
    private int _quantidadeEtiquetas;
    public int QuantidadeEtiquetas
    {
      get => _quantidadeEtiquetas;
      set { _quantidadeEtiquetas = value; OnPropertyChanged(); }
    }
    public ItemImpressao(Produto produto, int quandidadeEtiquetas = 1)
    {
      Produto = produto;
      QuantidadeEtiquetas = quandidadeEtiquetas;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string nome = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
    }
  }
}