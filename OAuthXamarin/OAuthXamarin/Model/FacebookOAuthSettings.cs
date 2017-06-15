namespace OAuthXamarin.Model
{
    public class FacebookOAuthSettings
    {
        public string ClientId { get; private set; }
        public string Scope { get; private set; }
        public string AuthorizeUrl { get; private set; }
        public string RedirectUrl { get; private set; }

        public FacebookOAuthSettings(string clientId, string scope, string authorizeUrl, string redirectUrl)
        {
            this.ClientId = clientId;
            this.Scope = scope;
            this.AuthorizeUrl = authorizeUrl;
            this.RedirectUrl = redirectUrl;
        }
    }
}
