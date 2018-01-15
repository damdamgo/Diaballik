using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiaballikGame.Utils
{
    /// <summary>
    /// Permet de relayer une action au sein d'une commande
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    class RelayCommand : ICommand
    {
        Action execute;
        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
