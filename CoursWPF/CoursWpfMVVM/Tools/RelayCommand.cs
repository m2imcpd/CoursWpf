using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoursWpfMVVM.Tools
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> execution;
        private Func<object, bool> testExecution;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            execution = execute;
            testExecution = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return (testExecution == null) || testExecution(parameter);
        }

        public void Execute(object parameter)
        {
            execution(parameter);
        }
    }
}
