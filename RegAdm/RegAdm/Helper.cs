using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegAdm
{
    public static class Helper
    {
        public const string ADMINISTRATOR = "Администратор";
        public const string SENIOR_ADMINISTRATOR = $"Старший {ADMINISTRATOR}";

        public static ReadOnlyDictionary<AuthorizationStatus, string?> StatusDictionary { get; } =
            new Dictionary<AuthorizationStatus, string?>
            {
                [AuthorizationStatus.None] = null,
                [AuthorizationStatus.InProcessing] = "В обработке...",
                [AuthorizationStatus.Authorized] = "Пользователь авторизован",
                [AuthorizationStatus.Fail] = "Пользователь не найден!"
            }.AsReadOnly();
    }
}
