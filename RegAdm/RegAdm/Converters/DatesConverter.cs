using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RegAdm.Converters
{
    public class DatesConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateOnly = (DateOnly?)value;
            return dateOnly.HasValue ? dateOnly.Value.ToDateTime(default) : null;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (DateTime?)value;
            return dateTime.HasValue ? DateOnly.FromDateTime(dateTime.Value) : null;
        }

        private DatesConverter() { }

        public static DatesConverter Instance { get; } = new();
    }
}
