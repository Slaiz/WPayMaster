using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shared.Commands
{
    public class CommandWithParameters : ICommand
    {
        public CommandWithParameters(Action<object> action, bool canExecute = true)
        {
            Action = action;
            CanExecuteCommand = canExecute;
        }

        private Action<object> Action { get; }
        private bool CanExecuteCommand { get; }

        public bool CanExecute(object parameter)
        {
            return CanExecuteCommand;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Action(parameter);
        }
    }
}
