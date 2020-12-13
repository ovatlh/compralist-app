using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarinCompraList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail_View : MasterDetailPage
    {
        public MasterDetail_View()
        {
            InitializeComponent();

            this.Master = new Master_View();
            this.Detail = new NavigationPage(new Detail_View());

            App.MasterDetail_Main = this;
        }
    }
}