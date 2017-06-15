namespace OAuthXamarin.Model
{
    public class TwitterOAuthSettings
    {
        public string Key { get; set; }
        public string Secret { get; set; }
        public string RequestTokenUrl { get; set; }
        public string AuthorizeUrl { get; set; }
        public string AccessUrl { get; set; }
        public string CallbackUrl { get; set; }

        public TwitterOAuthSettings(string key, string secret, string requestTokenUrl, string authorizeUrl, string accessUrl, string callbackUrl)
        {
            Key = key;
            Secret = secret;
            RequestTokenUrl = requestTokenUrl;
            AuthorizeUrl = authorizeUrl;
            CallbackUrl = callbackUrl;
            AccessUrl = accessUrl;
        }
    }
}
