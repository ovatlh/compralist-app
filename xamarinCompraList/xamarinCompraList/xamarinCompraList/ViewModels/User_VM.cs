using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using xamarinCompraList.Views;

namespace xamarinCompraList.ViewModels
{
    public class User_VM
    {
        public Command SavePreferencesCommand { get; set; }
        public Command AvatarSelectedCommand { get; set; }

        public Avatar Avatar { get; set; }
        public string AvatarString { get; set; }
        public List<string> Avatars { get; set; }
        public string Username { get; set; }

        public User_VM()
        {
            Avatar = App.UserAvatar;
            Username = App.Username;

            string[] result = Enum.GetNames(typeof(Avatar));
            Avatars = new List<string>();
            foreach (var item in result)
            {
                Avatars.Add(item);
            }
            Avatars.RemoveAt(0);

            SavePreferencesCommand = new Command(SavePreferences);
            AvatarSelectedCommand = new Command(AvatarSelected);
        }

        async void SavePreferences(object obj)
        {
            if (Avatar != Avatar.None && !string.IsNullOrWhiteSpace(Username))
            {
                App.SetPreferences(Avatar, Username);
                //App.Current.MainPage = new MasterDetail_View();
                //App.Current.MainPage = new NavigationPage(new MainPage());
                App.Current.MainPage = new MainPage();
            }
            else
            {
                await App.Current.MainPage.DisplayToastAsync("Campos obligatorios", 300);
            }
        }

        private void AvatarSelected(object obj)
        {
            Avatar = (Avatar)Enum.Parse(typeof(Avatar), AvatarString, true);
        }
    }
}
