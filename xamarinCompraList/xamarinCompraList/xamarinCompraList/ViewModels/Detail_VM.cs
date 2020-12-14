using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using xamarinCompraList.Models;
using xamarinCompraList.Views;

namespace xamarinCompraList.ViewModels
{
    public class Detail_VM
    {
        public Command UserCommand { get; set; }
        public compralistContext CompralistContext { get; set; }
        public Avatar UserAvatar { get; set; }
        public string Username { get; set; }

        public Detail_VM()
        {
            CompralistContext = App.CompralistContext;
            UserAvatar = App.UserAvatar;
            Username = App.Username;

            UserCommand = new Command(User);
        }

        private async void User(object obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new User_View());
        }
    }
}
