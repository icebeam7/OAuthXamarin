using System.ComponentModel;
using System.Runtime.CompilerServices;
using OAuthXamarin.Model;

namespace OAuthXamarin.ViewModel
{
    public class ProfileInfoViewModel : INotifyPropertyChanged
    {
        private User _user;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public ProfileInfoViewModel(User user)
        {
            this.User = user;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
