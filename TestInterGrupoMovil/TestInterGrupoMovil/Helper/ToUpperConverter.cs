using System;
using System.Collections.Generic;
using System.Text;

namespace TestInterGrupoMovil.Helper
{

    public class ToUpperConverter : Xamarin.Forms.IValueConverter
    {

        #region Converts
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var text = $"{value}";
            if (!string.IsNullOrEmpty(text))
                return text.ToUpper();

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Empty;
        }
        #endregion Converts
    }
}
