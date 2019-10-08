using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoursWpfMVVM.Tools
{
    public class AddCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ObservableCollection<object> Liste;
        private object objet;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public AddCommand(ObservableCollection<object> liste, object o)
        {
            Liste = liste;
            objet = o;
        }
        public void Execute(object parameter)
        {
            Liste.Add(objet);
        }
    }
}
