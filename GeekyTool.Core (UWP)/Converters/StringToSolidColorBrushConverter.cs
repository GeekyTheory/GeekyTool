using System;
using Windows.UI.Xaml.Data;
using GeekyTool.Core.Common;

namespace GeekyTool.Core.Converters
{
    public class StringToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var retVal = string.Empty;
            if (value is string)
            {
                retVal = (string) value;
                return ColorHelper.GetBrushColorFromHexa(retVal);
            }
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        
    }
}
