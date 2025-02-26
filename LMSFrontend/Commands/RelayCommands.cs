using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LMSFrontend.Commands
{
    public class RelayCommands : ICommand
    {

        public event EventHandler? CanExecuteChanged;

        private Action<object?> _execute { get; set; }

        private Predicate<object?> _canExecute { get; set; }


        public RelayCommands(Action<object?> ExecuteMethod, Predicate<object?> CanExecuteMethod)
        {
            _execute = ExecuteMethod;

            _canExecute = CanExecuteMethod;
        }


        public bool CanExecute(object? parameter)
        {
            return _canExecute(parameter);
        }


        public void Execute(object? parameter)
        {
            _execute(parameter);
        }


        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);   
        }
            
    }
}
