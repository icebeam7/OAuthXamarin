namespace OAuthXamarin.Helpers
{
    public static class Constants
    {
        public const string FacebookAppID = "1707741476198627";
        public const string FacebookAuthURL = "https://m.facebook.com/dialog/oauth/";
        public const string FacebookRedirectURL = "https://www.facebook.com/connect/login_success.html";
        public const string FacebookProfileInfoURL = "https://graph.facebook.com/me?fields=name,picture,work,website,religion,location,locale,link,cover,age_range,birthday,devices,email,first_name,last_name,gender,hometown,is_verified,languages";
        public const string FacebookScope = "email";

        public const string TwitterKey = "fZpXiiVJXQawKgNBdmjz2FzBe";
        public const string TwitterSecret = "L5ReI7KC88gwjJ9nflYDAWUoWLQwt4bhzp5xt2vWXLVOFC06Bd";
        public const string TwitterRequestURL = "https://api.twitter.com/oauth/request_token";
        public static string TwitterAuthURL = "https://twitter.com/oauth/authenticate";
        public const string TwitterURLAccess = "https://api.twitter.com/oauth/access_token";
        public const string TwitterCallbackURL = "https://icebeamwp.blogspot.cz";
        public const string TwitterProfileInfoURL = "https://api.twitter.com/1.1/account/verify_credentials.json";
    }
}
