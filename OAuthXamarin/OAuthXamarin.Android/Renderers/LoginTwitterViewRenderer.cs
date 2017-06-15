using System;
using Android.App;
using OAuthXamarin.View;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using OAuthXamarin.Droid.Renderers;
using OAuthXamarin.Model;
using System.Threading.Tasks;
using OAuthXamarin.Helpers;

[assembly: ExportRenderer(typeof(LoginTwitterView), typeof(LoginTwitterViewRenderer))]
namespace OAuthXamarin.Droid.Renderers
{
    public class LoginTwitterViewRenderer : PageRenderer
    {
        Account loggedInAccount = null;

        protected override void OnElementPropertyChanged(object s, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(s, e);

            var auth = new  OAuth1Authenticator(
                consumerKey: App.Instance.TwitterOAuthSettings.Key,
                consumerSecret: App.Instance.TwitterOAuthSettings.Secret,
                requestTokenUrl: new Uri(App.Instance.TwitterOAuthSettings.RequestTokenUrl),
                authorizeUrl: new Uri(App.Instance.TwitterOAuthSettings.AuthorizeUrl),
                callbackUrl: new Uri(App.Instance.TwitterOAuthSettings.CallbackUrl),
                accessTokenUrl: new Uri(App.Instance.TwitterOAuthSettings.AccessUrl)
            );

            auth.Title = "Twitter login";
            auth.AllowCancel = true;

            var activity = this.Context as Activity;
            activity.StartActivity(auth.GetUI(activity));

            auth.Completed += async (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    loggedInAccount = eventArgs.Account;
                    string idSocial = loggedInAccount.Properties["user_id"];
                    string screenName = loggedInAccount.Properties["screen_name"];

                    await GetTwitterData(idSocial, screenName);

                    AccountStore.Create(activity).Save(loggedInAccount, "Twitter");
                    App.Instance.SuccessfulLoginAction.Invoke();
                    App.Instance.SaveToken(loggedInAccount.Properties["oauth_token"], eventArgs.Account.Properties["oauth_token_secret"]);

                    await App.Instance.IniciarSesion();
                }
                else
                {
                    // The user cancelled
                    App.Instance.SuccessfulLoginAction.Invoke();
                }
            };
        }

        public async Task GetTwitterData(string socialId, string screenName)
        {
            var request = new OAuth1Request("GET", new Uri(Constants.TwitterProfileInfoURL), null, loggedInAccount);

            await request.GetResponseAsync().ContinueWith(t =>
            {
                var res = t.Result;
                var resString = res.GetResponseText();
                Console.WriteLine("Result Text: " + resString);
                var jo = Newtonsoft.Json.Linq.JObject.Parse(resString);

                string name = screenName;
                string socialName = (string)jo["name"];
                string email = "";
                string profilePictureUrl = (string)jo["profile_image_url_https"];

                App.Instance.User = new User(socialId, name, socialName, email, profilePictureUrl, "Twitter");
            });
        }
    }
}