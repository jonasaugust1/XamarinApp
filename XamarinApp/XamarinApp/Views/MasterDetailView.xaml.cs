
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailView : MasterDetailPage
    {
        private readonly Usuario _Usuario;
        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();
            _Usuario = usuario;
            Master = new MasterView(usuario);
        }
    }
}