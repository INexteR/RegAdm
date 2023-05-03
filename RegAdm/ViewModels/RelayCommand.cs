using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ViewModels
{
    #region Класс команд - RelayCommand
    public partial class RelayCommand : ICommand
    {
        private readonly CanExecuteHandler<object?> canExecute;
        private readonly ExecuteHandler<object?> execute;
        private readonly EventHandler requerySuggested;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(ExecuteHandler<object?> execute, CanExecuteHandler<object?> canExecute)
        {
            dispatcher = Application.Current.Dispatcher;
            this.execute = execute ?? throw Exceptions.executeException;
            this.canExecute = canExecute ?? throw Exceptions.canExecuteException;

            requerySuggested = (o, e) => Invalidate();
            CommandManager.RequerySuggested += requerySuggested;
        }

        /// <inheritdoc cref="RelayCommand(ExecuteHandler{object?}, CanExecuteHandler{object?})"/>
        public RelayCommand(ExecuteHandler<object?> execute)
        :this(execute, obj => true)
        { }

        /// <inheritdoc cref="RelayCommand(ExecuteHandler{object?}, CanExecuteHandler{object?})"/>
        public RelayCommand(ExecuteHandler execute, CanExecuteHandler canExecute)
                : this
                (
                      execute is not null ? p => execute() : throw Exceptions.executeException,
                      canExecute is not null ? p => canExecute() : throw Exceptions.canExecuteException
                )
        { }

        /// <inheritdoc cref="RelayCommand(ExecuteHandler{object?}, CanExecuteHandler{object?})"/>
        public RelayCommand(ExecuteHandler execute)
                : this
                (
                      execute is not null ? p => execute() : throw Exceptions.executeException
                )
        { }

        private readonly Dispatcher dispatcher;

        public void RaiseCanExecuteChanged()
        {
            if (dispatcher.CheckAccess())
                Invalidate();
            else
                dispatcher.BeginInvoke(Invalidate);
        }
        private void Invalidate()
            => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter) => canExecute(parameter);

        public void Execute(object? parameter) => execute(parameter);
    }
    #endregion
}

