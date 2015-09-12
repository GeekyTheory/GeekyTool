using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace GeekyTool.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter == null)
                throw new ArgumentNullException("The converter parameter must be a valid format string.");

            DateTime date = (DateTime)value;
            
            return date.ToString(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (parameter == null)
                throw new ArgumentNullException("The converter parameter must be a valid format string.");

            var dateString = value.ToString();

            try
            {
                return DateTime.ParseExact(dateString, parameter.ToString(), null);
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }
    }
}
