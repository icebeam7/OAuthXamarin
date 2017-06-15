using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OAuthXamarin.ViewModel;

namespace OAuthXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileInfoView : ContentPage
    {
        ProfileInfoViewModel viewModel;

        public ProfileInfoView()
        {
            InitializeComponent();

            viewModel = new ProfileInfoViewModel(App.Instance.User);
            this.BindingContext = viewModel;
        }
    }
}
