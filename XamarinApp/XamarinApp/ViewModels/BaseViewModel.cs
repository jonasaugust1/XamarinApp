using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /*
           Se nada for passado no parâmetro o CallerMemberName vai assumir 
           que o name é o da própria propriedade que está chamando o método
        */
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
