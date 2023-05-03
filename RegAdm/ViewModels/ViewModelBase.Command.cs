using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ViewModels
{

    public abstract partial class ViewModelBase
    {
        private readonly Dictionary<string, RelayCommand> commands = new();

        private bool TryGetCommand(string? commandName, out RelayCommand? command)
        {
            if (string.IsNullOrWhiteSpace(commandName))
                throw Exceptions.commandNameException;
            return commands.TryGetValue(commandName, out command);
        }

        protected RelayCommand<T> GetCommand<T>(ExecuteHandler<T> execute, CanExecuteHandler<T> canExecute, ConverterFromObjectHandler<T> converter, [CallerMemberName] string? commandName = null)
        {

            if (!TryGetCommand(commandName, out RelayCommand? command))
            {
                command = new RelayCommand<T>(execute, canExecute, converter);
                commands.Add(commandName!, command);
                RaisePropertyChanged(commandName!);
            }
            return (RelayCommand<T>)command!;
        }

        protected RelayCommand<T> GetCommand<T>(ExecuteHandler<T> execute, CanExecuteHandler<T> canExecute, [CallerMemberName] string? commandName = null)
        {

            if (!TryGetCommand(commandName, out RelayCommand? command))
            {
                command = new RelayCommand<T>(execute, canExecute);
                commands.Add(commandName!, command);
            }
            return (RelayCommand<T>)command!;
        }

        protected RelayCommand<T> GetCommand<T>(ExecuteHandler<T> execute, ConverterFromObjectHandler<T> converter, [CallerMemberName] string? commandName = null)
        {

            if (!TryGetCommand(commandName, out RelayCommand? command))
            {
                command = new RelayCommand<T>(execute, converter);
                commands.Add(commandName!, command);
            }
            return (RelayCommand<T>)command!;
        }

        protected RelayCommand<T> GetCommand<T>(ExecuteHandler<T> execute, [CallerMemberName] string? commandName = null)
        {

            if (!TryGetCommand(commandName, out RelayCommand? command))
            {
                command = new RelayCommand<T>(execute);
                commands.Add(commandName!, command);
            }
            return (RelayCommand<T>)command!;
        }

        protected RelayCommand GetCommand(ExecuteHandler<object?> execute, CanExecuteHandler<object?> canExecute, [CallerMemberName] string? commandName = null)
        {
            if (!TryGetCommand(commandName, out RelayCommand? command))
            {
                command = new RelayCommand(execute, canExecute);
                commands.Add(commandName!, command);
            }
            return command!;
        }

        protected RelayCommand GetCommand(ExecuteHandler<object?> execute, [CallerMemberName] string? commandName = null)
        {
            if (!TryGetCommand(commandName, out RelayCommand? command))
            {
                command = new RelayCommand(execute);
                commands.Add(commandName!, command);
            }
            return command!;
        }

        protected RelayCommand GetCommand(ExecuteHandler execute, CanExecuteHandler canExecute, [CallerMemberName] string? commandName = null)
        {
            if (!TryGetCommand(commandName, out RelayCommand? command))
            {
                command = new RelayCommand(execute, canExecute);
                commands.Add(commandName!, command);
            }
            return command!;
        }

        protected RelayCommand GetCommand(ExecuteHandler execute, [CallerMemberName] string? commandName = null)
        {
            if (!TryGetCommand(commandName, out RelayCommand? command))
            {
                command = new RelayCommand(execute);
                commands.Add(commandName!, command);
            }
            return command!;
        }

        protected RelayCommand? GetCommand([CallerMemberName] string? commandName = null)
        {
            TryGetCommand(commandName, out RelayCommand? command);
            return command;
        }

        protected bool RemoveCommand(string commandName)
        {
            bool remove = commands.Remove(commandName);
            RaisePropertyChanged(commandName);
            return remove ;
        }

        public static class Exceptions
        {
            public static readonly ArgumentException commandNameException = new("null, Empty и только пробелы не разрешёны", "commandName");
        }

    }
}
