using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DiaballikGame.Utils;
using DiaballikGame.Welcome;
using DiaballikGame.Game;
using System.Windows;

namespace DiaballikGame.MenuDiaballik
{
    /// <summary>
    /// Modele de la vue MenuDiaballik
    /// </summary>
    /// <seealso cref="DiaballikGame.Utils.ViewModelBase" />
    class MenuDiaballikModel : ViewModelBase
    {
        /// <summary>
        ///  Acces à la fenetre principale
        /// </summary>
        private MainInterface mI;
        /// <summary>
        /// Commandes du menu
        /// </summary>
        private ICommand newGameCommand;
        private ICommand saveCurrentGame;
        private ICommand goMenuCommand, goAboutCommand, exiteCommand;

        /// <summary>
        /// Constructeur <see cref="MenuDiaballikModel"/> class.
        /// </summary>
        /// <param name="mI">Acces à la fenetre principale</param>
        public MenuDiaballikModel(MainInterface mI)
        {
            this.mI = mI;
        }


        /*
         * 
         * Commandes du menu
         * 
         */

        public ICommand NewGameCommand
        {
            get
            {
                return newGameCommand ?? (newGameCommand = new RelayCommand(newGame));
            }
        }

        public ICommand ExiteCommand
        {
            get
            {
                return exiteCommand ?? (exiteCommand = new RelayCommand(exitDiaballik));
            }
        }
        

        public ICommand SaveCurrentGameCommand
        {
            get
            {
                return saveCurrentGame ?? (saveCurrentGame = new RelayCommand(saveGame));
            }
        }

        public ICommand GoMenuCommand
        {
            get
            {
                return goMenuCommand ?? (goMenuCommand = new RelayCommand(goMenu));
            }
        }
        public ICommand GoAboutCommand
        {
            get
            {
                return goAboutCommand ?? (goAboutCommand = new RelayCommand(goAbout));
            }
        }

        /*
         * 
         * Actions du menu
         * 
         */

        public void goMenu()
        {
            mI.displayMenu();
        }

        public void newGame()
        {
            mI.changeMainView(new CommandViewChoiceHandler(new ConfigGame(mI)));
        }

        public void saveGame()
        {
            mI.saveCurrentGame();
        }

        public void goAbout()
        {
            mI.about();
        }

        public void exitDiaballik()
        {
            mI.exitDiaballik();
        }

    }
}
