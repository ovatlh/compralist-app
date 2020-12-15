using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using xamarinCompraList.Models;

namespace xamarinCompraList.Helpers
{
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Item_Listo { get; set; }
        public DataTemplate Item_NoListo { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return  (item as Item).Listo == true ?  Item_Listo : Item_NoListo;
        }
    }
}
