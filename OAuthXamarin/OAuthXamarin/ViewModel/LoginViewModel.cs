using System.Threading.Tasks;
using Xamarin.Forms;

namespace OAuthXamarin.ViewModel
{
    public class LoginViewModel
    {
        public Command FacebookLoginCommand { get; set; }
        public Command TwitterLoginCommand { get; set; }

        public INavigation Navigation;

        public LoginViewModel()
        {
            FacebookLoginCommand = new Command(async () => await ExecuteFacebookLoginCommand(Navigation));
            TwitterLoginCommand = new Command(async () => await ExecuteTwitterLoginCommand(Navigation));
        }

        async Task ExecuteFacebookLoginCommand(INavigation navigation)
        {
            await navigation.PushModalAsync(new View.LoginFacebookView("Facebook"));
        }

        async Task ExecuteTwitterLoginCommand(INavigation navigation)
        {
            await navigation.PushModalAsync(new View.LoginTwitterView("Twitter"));
        }
    }
}
