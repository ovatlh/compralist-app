using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using xamarinCompraList.Models;
using xamarinCompraList.Views;

namespace xamarinCompraList.ViewModels
{
    public class MainPage_VM
    {
        public Command UserCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command AddCommand { get; set; }
        public Command CompleteCommand { get; set; }
        public compralistContext CompralistContext { get; set; }
        public Avatar UserAvatar { get; set; }
        public string AvatarString { get; set; }
        public string Username { get; set; }

        public MainPage_VM()
        {
            CompralistContext = App.CompralistContext;
            CompralistContext.List_OrderBy();
            UserAvatar = App.UserAvatar;
            AvatarString = Enum.GetName(typeof(Avatar), UserAvatar);
            Username = App.Username;

            UserCommand = new Command(User);
            DeleteCommand = new Command(Delete);
            AddCommand = new Command(Add);
            CompleteCommand = new Command(Complete);
        }

        private async void User(object obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new User_View());
        }

        private async void Delete(object obj)
        {
            var item = obj as Item;
            //App.CompralistContext.ListItems.Remove(item);
            //App.CompralistContext.Item_Delete(item);
            CompralistContext.Item_Delete(item);
            await App.Current.MainPage.DisplayToastAsync("DeleteCommand activado", 500);
            //CompralistContext.ListItems = App.CompralistContext.ListItems;
        }

        private async void Add(object obj)
        {
            string result = await App.Current.MainPage.DisplayPromptAsync("Agregando...", "¿Que quieres agregar?", "Agregar", "Cancelar", "" , 45);
            if (!string.IsNullOrWhiteSpace(result))
            {
                CompralistContext.Item_Add(result, Username);
            }
            //CompralistContext.List_OrderBy();
        }

        private void Complete(object obj)
        {
            var result = obj as Item;
            //res.Listo = true;
            CompralistContext.Item_Complete(result, Username);
            //CompralistContext = App.CompralistContext;
        }
    }
}
