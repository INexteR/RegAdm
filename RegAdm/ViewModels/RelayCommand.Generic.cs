namespace ViewModels
{
    public class RelayCommand<T> : RelayCommand
    {
        public RelayCommand(ExecuteHandler<T> execute, CanExecuteHandler<T> canExecute, ConverterFromObjectHandler<T> converter)
            : base
            (
                  execute is null ? throw Exceptions.executeException
                  : converter is null ? throw Exceptions.converterException
                  : p =>
                  {
                      if (p is T t || converter(p, out t))
                          execute(t);
                  },

                  canExecute is null ? throw Exceptions.canExecuteException
                  : converter is null ? throw Exceptions.converterException
                  : p => (p is T t || converter(p, out t)) && canExecute(t)
            )
        { }

        public RelayCommand(ExecuteHandler<T> execute, CanExecuteHandler<T> canExecute)
            : base
            (
                  execute is null ? throw Exceptions.executeException
                  : p =>
                  {
                      if (p is T t)
                          execute(t);
                  },

                  canExecute is null ? throw Exceptions.canExecuteException
                  : p => p is T t && canExecute(t)
            )
        { }

        public RelayCommand(ExecuteHandler<T> execute, ConverterFromObjectHandler<T> converter)
            : base
            (
                  execute is null ? throw Exceptions.executeException
                  : converter is null ? throw Exceptions.converterException
                  : p =>
                  {
                      if (p is T t || converter(p, out t))
                          execute(t);
                  }
            )
        { }

        public RelayCommand(ExecuteHandler<T> execute)
            : base
            (
                  execute is null ? throw Exceptions.executeException
                  : p =>
                  {
                      if (p is T t)
                          execute(t);
                  }
            )
        { }
    }
}

