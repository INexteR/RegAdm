using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RegAdm
{
    public static class MessageHelper
    {
        public static void Msg(this string txt, string? title = null, MessageBoxButton btn = default, MessageBoxImage img = MessageBoxImage.Error)
        {
            MessageBox.Show(txt, title, btn, img);
        }
    }
}
