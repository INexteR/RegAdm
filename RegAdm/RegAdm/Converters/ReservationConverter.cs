using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RegAdm.Converters
{
    public class ReservationsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = (IEnumerable<dynamic>)value;
            return list.Sum(r => r.Clients.Count);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private ReservationsConverter() { }

        public static ReservationsConverter Instance { get; } = new();
    }
}
