using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using ViewModels;

namespace RegAdm.Dialogs
{
    internal abstract class AddUpdateDialog<TTemp, TViewModel> : Window
    {
        protected readonly AddUpdateDialogData<TTemp, TViewModel> dialogData;
        public AddUpdateDialog(TTemp entity, TViewModel viewModel)
        {
            ((IComponentConnector)this).InitializeComponent();
            dialogData = (AddUpdateDialogData<TTemp, TViewModel>)Resources[nameof(dialogData)];
            dialogData.Entity = entity;
            dialogData.ViewModel = viewModel;
        }
    }

    internal class AddUpdateDialogData<TEntity, TViewModel> : ViewModelBase
    {
        public TEntity Entity { get => Get<TEntity>()!; set => Set(value); }
        public TViewModel ViewModel { get => Get<TViewModel>()!; set => Set(value); }
    }
}
