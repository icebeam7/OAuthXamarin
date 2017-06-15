using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OAuthXamarin.ViewModel;

namespace OAuthXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        LoginViewModel viewModel;

        public LoginView()
        {
            InitializeComponent();

            viewModel = new LoginViewModel();
            viewModel.Navigation = this.Navigation;
            this.BindingContext = viewModel;
        }
    }
}
