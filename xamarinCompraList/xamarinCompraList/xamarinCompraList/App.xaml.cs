using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarinCompraList.Models;
using xamarinCompraList.Themes;
using xamarinCompraList.Views;

namespace xamarinCompraList
{
    public enum Avatar { None, Abuelito, Abuelita, Papa, Mama, Hijo, Hija, Mascota, Auto, Avion, Barco, Helicoptero, Robot, Planta, Alien}
    public partial class App : Application
    {
        //public static MasterDetailPage MasterDetail_Main { get; set; }
        public static compralistContext CompralistContext { get; set; }
        public static Avatar UserAvatar { get; set; }
        public static string Username { get; set; }
        public static bool NightTheme { get; set; }

        //public static void Open_Menu()
        //{
        //    MasterDetail_Main.IsPresented = true;
        //}

        //public static void Close_Menu()
        //{
        //    MasterDetail_Main.IsPresented = false;
        //}

        //public static async void Root_Menu()
        //{
        //    await MasterDetail_Main.Detail.Navigation.PopToRootAsync();
        //}

        public static void GetPreferences()
        {
            UserAvatar = (Avatar)Preferences.Get("Avatar", (int)Avatar.None);
            Username = Preferences.Get("Username", string.Empty);
        }

        public static void SetPreferences(Avatar useravatar, string username)
        {
            Preferences.Set("Avatar", (int)useravatar);
            Preferences.Set("Username", username);

            GetPreferences();
        }

        public static void SaveTheme(bool nightTheme)
        {
            Preferences.Set("NightTeme", nightTheme);
            LoadTheme();
        }

        public static void LoadTheme()
        {
            NightTheme = Preferences.Get("NightTeme", false);

            if (NightTheme)
            {
                ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
                mergedDictionaries.Clear();
                mergedDictionaries.Add(new NightTheme());
            }
            else
            {
                ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
                mergedDictionaries.Clear();
                mergedDictionaries.Add(new DayTheme());
            }
        }

        public App()
        {
            Device.SetFlags(new[] { "SwipeView_Experimental" });
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzY2NjMxQDMxMzgyZTMzMmUzMElheWM0S0lLUmNoMW5icWF4Umg2ZW1pUWJlS29yYTNYU2JJcmR3bkkwanM9");

            InitializeComponent();

            //MainPage = new MainPage();
            GetPreferences();

            CompralistContext = new compralistContext();

            LoadTheme();

            if (UserAvatar == Avatar.None || string.IsNullOrWhiteSpace(Username))
            {
                MainPage = new User_View();
            }
            else
            {
                //MainPage = new MasterDetail_View();
                //MainPage = new NavigationPage(new Detail_View());
                MainPage = new NavigationPage(new MainPage());
                //MainPage = new MainPage();
                //MainPage = new Detail_View();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
