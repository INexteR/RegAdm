using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RegAdm
{
    public static class Helper
    {
        public static ReadOnlyDictionary<AuthorizationStatus, string?> StatusDictionary { get; } =
            new Dictionary<AuthorizationStatus, string?>
            {
                [AuthorizationStatus.None] = null,
                [AuthorizationStatus.InProcessing] = "В обработке...",
                [AuthorizationStatus.Authorized] = "Пользователь авторизован",
                [AuthorizationStatus.Fail] = "Пользователь не найден!"
            }.AsReadOnly();

        public static KeyEventHandler OnlyDigits { get; } = (s, e) =>
        {
            if (e.Key is not (>= Key.D0 and <= Key.D9 or
            >= Key.NumPad0 and <= Key.NumPad9 or Key.Back or Key.Left or Key.Right))
            {
                e.Handled = true;
            }
        };
    }
}
