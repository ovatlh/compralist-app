using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using xamarinCompraList.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace xamarinCompraList.ViewModels
{
    public class User_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Actualizar([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public Command SavePreferencesCommand { get; set; }
        public Command AvatarSelectedCommand { get; set; }
        public Command ThemeCommand { get; set; }

        public Avatar Avatar { get; set; }
        public string AvatarString { get; set; }
        public List<string> Avatars { get; set; }
        public string Username { get; set; }
        //public string BtnThemeText { get; set; }
        private string btnThemeText;

        public string BtnThemeText
        {
            get { return btnThemeText; }
            set { btnThemeText = value; Actualizar(); }
        }

        public User_VM()
        {
            Avatar = App.UserAvatar;
            Username = App.Username;
            BtnText();

            string[] result = Enum.GetNames(typeof(Avatar));
            Avatars = new List<string>();
            foreach (var item in result)
            {
                Avatars.Add(item);
            }
            Avatars.RemoveAt(0);

            SavePreferencesCommand = new Command(SavePreferences);
            AvatarSelectedCommand = new Command(AvatarSelected);
            ThemeCommand = new Command(Theme);
        }

        public void BtnText()
        {
            BtnThemeText = App.NightTheme == true ? "Cambiar tema a: Dia" : "Cambiar tema a: Noche";
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

        private void Theme(object obj)
        {
            App.SaveTheme(!App.NightTheme);
            BtnText();
        }
    }
}
