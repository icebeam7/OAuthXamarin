namespace OAuthXamarin.Model
{
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string SocialName { get; set; }
        public string Email { get; set; }
        public string ProfilePictureURL { get; set; }
        public string Provider { get; set; }

        public User(string id, string name, string socialName, string email, string profilePictureUrl, string provider)
        {
            ID = id;
            Name = name;
            SocialName = socialName;
            Email = email;
            ProfilePictureURL = profilePictureUrl;
            Provider = provider;
        }
    }
}
