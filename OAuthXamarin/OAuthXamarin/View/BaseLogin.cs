using Xamarin.Forms;

namespace OAuthXamarin.View
{
    public class BaseLogin : ContentPage
    {
        public BaseLogin(string Provider)
        {
            BackgroundColor = Color.White;

            Label label = new Label()
            {
                FontSize = 16,
                Text = $"Getting access from {Provider}",
                TextColor = Color.Black
            };

            ActivityIndicator activityIndicator = new ActivityIndicator()
            {
                Color = Color.Blue,
                IsRunning = true,
            };

            StackLayout stackLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White
            };

            stackLayout.Children.Add(activityIndicator);
            stackLayout.Children.Add(label);

            Content = stackLayout;
        }
    }
}