using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace GeekyTool.Core.Converters
{
    public class DoubleToStringFromatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double retValue;
            if (double.TryParse(value.ToString(), out retValue))
            {
                var format = (string)parameter;
                var culture = CultureInfo.CurrentCulture;
                culture.NumberFormat.CurrencyNegativePattern = 1;
                return retValue.ToString(format ?? "N", culture);

            }
            else
                return "0";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
