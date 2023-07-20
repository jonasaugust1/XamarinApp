using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : ContentPage
    {
        public MasterViewModel ViewModel { get; set; }
        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            ViewModel = new MasterViewModel(usuario);
            BindingContext = ViewModel;
        }
    }
}