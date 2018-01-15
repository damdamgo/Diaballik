using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DiaballikGame.Game;
using DiaballikGame.Utils;
using Diaballik.DataManager;

namespace DiaballikGame.Welcome
{
    /// <summary>
    /// Modele de la vue ChoiceGameView
    /// </summary>
    /// <seealso cref="DiaballikGame.Utils.ViewModelBase" />
    public class ModelChoiceGame : ViewModelBase
    {
        /// <summary>
        /// Acces à la fenetre principale
        /// </summary>
        private MainInterface mI;
        /// <summary>
        ///Commande création d'une partie
        /// </summary>
        private ICommand newGameCommand;
        /// <summary>
        /// Liste des parties
        /// </summary>
        private List<GameModelDB> listGames;

        /// <summary>
        /// Constructeur <see cref="ModelChoiceGame"/> class.
        /// </summary>
        /// <param name="mI">Acces à la fenetre principale</param>
        public ModelChoiceGame (MainInterface mI)
        {
            this.mI = mI;
            listGames = DBManager.getInstance().getListGameSaved().ToList<GameModelDB>() ;
        }

        /// <summary>
        /// Commande pour la création d'une partie
        /// </summary>
        public ICommand NewGameCommand
        {
            get
            {
                return newGameCommand ?? (newGameCommand = new RelayCommand(newGame));
            }
        }

        /// <summary>
        /// Getter liste des parties
        /// </summary>
        public List<GameModelDB> ListGames
        {
            get
            {
                return this.listGames;
            }
        }

        /// <summary>
        /// Action pour une nouvelle partie
        /// </summary>
        public void newGame()
        {
            mI.changeMainView(new CommandViewChoiceHandler(new ConfigGame(mI)));
        }

        /// <summary>
        /// Action sur une partie existante
        /// </summary>
        /// <param name="index">Index dans la liste</param>
        public void ActionOnItem(int index)
        {
            GameModelDB game = listGames.ElementAt(index);
            if (game.gameStatus == GameModelDB.GameStatus.FINISHED)
            {
                mI.replayGame(game.Id);
            }
            else mI.resumeGame(game.Id);
        }
    }
}
