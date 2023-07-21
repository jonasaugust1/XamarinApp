
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : TabbedPage
    {
        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            BindingContext = new MasterViewModel(usuario); ;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();
        }
        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil", (msg) =>
            {
                CurrentPage = Children[1];
            });

            MessagingCenter.Subscribe<Usuario>(this, "SalvarPerfil", (msg) =>
            {
                CurrentPage = Children[0];
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarMensagens();
        }
        private void CancelarMensagens()
        {
            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
            MessagingCenter.Unsubscribe<Usuario>(this, "SalvarPerfil");
        }
    }
}