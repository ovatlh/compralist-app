using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarinCompraList.Views;

namespace xamarinCompraList
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetail_Main { get; set; }

        public static void Open_Menu()
        {
            MasterDetail_Main.IsPresented = true;
        }

        public static void Close_Menu()
        {
            MasterDetail_Main.IsPresented = false;
        }

        public static async void Root_Menu()
        {
            await MasterDetail_Main.Detail.Navigation.PopToRootAsync();
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new MasterDetail_View();
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
