using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace xamarinCompraList.Helpers
{
    public class AvatarImageSelector : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            Avatar avatar = (Avatar)Enum.Parse(typeof(Avatar), value.ToString(), true);
            return ImageSource.FromResource($"xamarinCompraList.Imgs.{(int)avatar}.png");

            //switch (avatar)
            //{
            //    case Avatar.None:
            //        return null;
            //        //break;
            //    case Avatar.Papa:
            //        return ImageSource.FromResource($"xamarinCompraList.Imgs.{avatar}.jpg");
            //    //break;
            //    case Avatar.Mama:
            //    //break;
            //    case Avatar.Hijo:
            //    //break;
            //    case Avatar.Hija:
            //    //break;
            //    case Avatar.Mascota:
            //    //break;
            //    case Avatar.Auto:
            //    //break;
            //    case Avatar.Avion:
            //    //break;
            //    case Avatar.Barco:
            //    //break;
            //    case Avatar.Helicoptero:
            //    //break;
            //    case Avatar.Robot:
            //    //break;
            //    case Avatar.Planta:
            //    //break;
            //    case Avatar.Alien:
            //    //break;
            //    default:
            //        return null;
            //        //break;
            //}
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
