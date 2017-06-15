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

[assembly: ExportRenderer(typeof(LoginFacebookView), typeof(LoginFacebookViewRenderer))]
namespace OAuthXamarin.Droid.Renderers
{
    public class LoginFacebookViewRenderer : PageRenderer
    {
        Account loggedInAccount = null;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var auth = new OAuth2Authenticator(
                clientId: App.Instance.FacebookOAuthSettings.ClientId,
                scope: App.Instance.FacebookOAuthSettings.Scope,
                authorizeUrl: new Uri(App.Instance.FacebookOAuthSettings.AuthorizeUrl),
                redirectUrl: new Uri(App.Instance.FacebookOAuthSettings.RedirectUrl));

            auth.Title = "Facebook login";
            auth.AllowCancel = true;

            var activity = this.Context as Activity;
            activity.StartActivity(auth.GetUI(activity));

            auth.Completed += async (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    loggedInAccount = eventArgs.Account;

                    await GetFacebookData();

                    AccountStore.Create(activity).Save(loggedInAccount, "Facebook");
                    App.Instance.SuccessfulLoginAction.Invoke();
                    App.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);

                    await App.Instance.IniciarSesion();
                }
                else
                {
                    // The user cancelled
                    App.Instance.SuccessfulLoginAction.Invoke();
                }
            };
        }

        public async Task GetFacebookData()
        {
            var request = new OAuth2Request("GET", new Uri(Constants.FacebookProfileInfoURL), null, loggedInAccount);

            await request.GetResponseAsync().ContinueWith(t => {
                if (t.IsFaulted)
                    Console.WriteLine("Error: " + t.Exception.InnerException.Message);
                else
                {
                    var res = t.Result;
                    var resString = res.GetResponseText();
                    var jo = Newtonsoft.Json.Linq.JObject.Parse(resString);

                    string socialId = (string)jo["id"];
                    string name = (string)jo["first_name"] + " " + (string)jo["last_name"];
                    string email = (string)jo["email"];
                    string pictureUrl = (string)jo["picture"]["data"]["url"];
                    string socialName = email;

                    App.Instance.User = new User(socialId, name, socialName, email, pictureUrl, "Facebook");
                }
            });
        }
    }
}