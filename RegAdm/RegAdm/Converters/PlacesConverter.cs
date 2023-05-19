using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RegAdm.Converters
{
    public class PlacesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var reservations = (IEnumerable<IReservation>)value;
            return reservations.Where(r => r.IsActual).Sum(r => r.Clients.Count());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private PlacesConverter() { }

        public static PlacesConverter Instance { get; } = new();
    }
}
