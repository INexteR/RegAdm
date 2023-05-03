using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RegAdm.Converters
{
    public class FromDictionaryConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dictionary = (IDictionary)parameter;
            return value != null ? dictionary[value] : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private FromDictionaryConverter() { }

        public static FromDictionaryConverter Instance { get; } = new();
    }
}
