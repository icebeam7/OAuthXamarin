using Android.App;
using Android.Content.PM;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using OAuthXamarin;

namespace OAuthXamarin.Droid
{
    [Activity(Label = "OAuthXamarin", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //LoadApplication(new App());
            SetPage(App.Instance.GetMainPage());
        }
    }
}

