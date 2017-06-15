using System;
using Xamarin.Forms;
using OAuthXamarin.Model;
using OAuthXamarin.Helpers;
using System.Threading.Tasks;

namespace OAuthXamarin
{
    public partial class App : Application
    {
        static volatile App _Instance;
        static object _SyncRoot = new Object();

        public FacebookOAuthSettings FacebookOAuthSettings { get; private set; }
        public TwitterOAuthSettings TwitterOAuthSettings { get; private set; }
        public User User { get; set; }

        string _Token;
        public string Token
        {
            get { return _Token; }
        }

        string _TokenSecret;
        public string TokenSecret
        {
            get { return _TokenSecret; }
        }

        public void SaveToken(string token, string tokenSecret = "")
        {
            _Token = token;
            _TokenSecret = tokenSecret;
            MessagingCenter.Send<App>(this, "Authenticated");
        }

        public void ClearToken()
        {
            _Token = "";
            _TokenSecret = "";
        }

        public Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() => _NavPage.Navigation.PopModalAsync());
            }
        }

        NavigationPage _NavPage;

        public static App Instance
        {
            get {
                if (_Instance == null) {
                    lock (_SyncRoot) {
                        if (_Instance == null) {
                            _Instance = new App();

                            _Instance.FacebookOAuthSettings =
                                new FacebookOAuthSettings(
                                    clientId: Constants.FacebookAppID,
                                    scope: Constants.FacebookScope,
                                    authorizeUrl: Constants.FacebookAuthURL,
                                    redirectUrl: Constants.FacebookRedirectURL);

                            _Instance.TwitterOAuthSettings =
                                new TwitterOAuthSettings(
                                    key: Constants.TwitterKey,
                                    secret: Constants.TwitterSecret,
                                    requestTokenUrl: Constants.TwitterRequestURL,
                                    authorizeUrl: Constants.TwitterAuthURL,
                                    accessUrl: Constants.TwitterURLAccess,
                                    callbackUrl: Constants.TwitterCallbackURL);
                        }
                    }
                }
                return _Instance;
            }
        }


        public Page GetMainPage()
        {
            _NavPage = new NavigationPage(new View.LoginView()) { BarBackgroundColor = Color.Black, BarTextColor = Color.White };
            return _NavPage;
        }

        public bool IsAuthenticated
        {
            get { return !string.IsNullOrWhiteSpace(_Token); }
        }

        public async Task IniciarSesion()
        {
            await _NavPage.Navigation.PushAsync(new View.ProfileInfoView());
        }

        protected override void OnStart() { // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
