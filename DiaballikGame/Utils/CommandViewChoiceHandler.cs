using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DiaballikGame.Welcome;

namespace DiaballikGame.Utils
{
    /// <summary>
    /// Permet de créer une commande pour changer de vue
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class CommandViewChoiceHandler : ICommand
    {
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Nouvelle vue
        /// </summary>
        private object view;

        public CommandViewChoiceHandler(object view)
        {
            this.view = view;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object viewToChange)
        {
            ((WelcomeModel)viewToChange).CurrentView = this.view;
        }
    }
}
