using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace GestionRendezVousHopital.Tools
{
    public class RelayDataGridCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object, DataGridRowEditEndingEventArgs> toExecute;
        public RelayDataGridCommand(Action<object, DataGridRowEditEndingEventArgs> eventExecute)
        {
            toExecute = eventExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            toExecute(this, parameter as DataGridRowEditEndingEventArgs);
        }
    }
}
