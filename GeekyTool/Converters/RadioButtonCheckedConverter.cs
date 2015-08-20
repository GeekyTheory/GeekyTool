using System;
using Windows.UI.Xaml.Data;

namespace GeekyTool.Converters
{
    public class RadioButtonCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            bool boolVal;
            bool.TryParse(parameter.ToString(), out boolVal);

            return value.Equals(boolVal);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            bool boolVal;
            bool.TryParse(parameter.ToString(), out boolVal);

            return value.Equals(true) ? boolVal : new bool?();
        }
    }
}
