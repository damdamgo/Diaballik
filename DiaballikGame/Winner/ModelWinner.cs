using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Diaballik;
using DiaballikGame.Utils;
using DiaballikGame.Welcome;
using MaterialDesignThemes.Wpf;

namespace DiaballikGame.Winner
{
    /// <summary>
    /// Modele de la vue Winner
    /// </summary>
    public class ModelWinner
    {
        /// <summary>
        /// Acceder au dialog
        /// </summary>
        DialogOpenedEventArgs close = null;
        /// <summary>
        /// Commande de la vue
        /// </summary>
        private ICommand goReplayAction, goMenuAction;
        /// <summary>
        /// Acces à la fenetre principale
        /// </summary>
        private MainInterface mI;
        /// <summary>
        /// Id de la partie dans la base de donnnées
        /// </summary>
        private int IDDB;

        /// <summary>
        /// Constructeur <see cref="ModelWinner"/> class.
        /// </summary>
        /// <param name="mI">Accès à la fenetre principale</param>
        /// <param name="IDDB">ID de la partie</param>
        public ModelWinner(MainInterface mI,int IDDB)
        {
            this.mI = mI;
            this.IDDB = IDDB;
        }

       /*
        * 
        * Commandes de la vue
        * 
        */

        public ICommand GoReplayAction
        {
            get
            {
                return goReplayAction ?? (goReplayAction = new RelayCommand(goReplay));
            }
        }

        public ICommand GoMenuAction
        {
            get
            {
                return goMenuAction ?? (goMenuAction = new RelayCommand(goMenu));
            }
        }

        /// <summary>
        /// Action qui lance un replay
        /// </summary>
        public void goReplay()
        {

            if (close != null)
            {
                mI.replayGame(IDDB);
                close.Session.Close(false);
            }

        }

        /// <summary>
        /// fermeture de la fenetre dialog
        /// </summary>
        internal void setCloseCommand(DialogOpenedEventArgs close)
        {
            this.close = close;
        }

        /// <summary>
        /// Action vers le menu
        /// </summary>
        public void goMenu()
        {
            if (close != null)
            {
                mI.menuEndGame();
                close.Session.Close(false);
            }
           
        }


    }
}
