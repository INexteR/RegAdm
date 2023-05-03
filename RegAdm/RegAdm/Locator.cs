using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Interfaces;

namespace RegAdm
{
    public class Locator : ViewModelBase
    {
        public IAuthorizationViewModel Authorization
        {
            get => Get<IAuthorizationViewModel>()!;
            set => Set(value);
        }
    }
}
