using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DiaballikGame.PlayerAction;
using DiaballikGame.Utils;
using DiaballikGame.Welcome;
namespace DiaballikGame.Game
{
    class GameManagerModel
    {
        /// <summary>
        /// Acces à la fenetre principale
        /// </summary>
        private MainInterface mI;
        /// <summary>
        /// Vue des deux joueur
        /// </summary>
        private object actionPlayer1, actionPlayer2;
        /// <summary>
        /// Command d'acces au replay
        /// </summary>
        private ICommand replayAccessCommand;
        /// <summary>
        /// Modele du jeu
        /// </summary>
        private Diaballik.Game game;

        /// <summary>
        /// Constructeur <see cref="GameManagerModel"/> class.
        /// </summary>
        /// <param name="game">Modele du jeu</param>
        /// <param name="mI">Acces à la fenetre principale</param>
        public GameManagerModel(Diaballik.Game game, MainInterface mI)
        {
            this.mI = mI;
            this.game = game;
            actionPlayer1 = new DiaballikGame.PlayerAction.ActionPlayer(game.P1);
            actionPlayer2 = new DiaballikGame.PlayerAction.ActionPlayer(game.P2);
        }

        /// <summary>
        /// Getter de la vue 1
        /// </summary>
        public object ActionPlayer1
        {
            get
            {
                return actionPlayer1;
            }
        }

        /// <summary>
        /// Getter de la vue 2
        /// </summary>
        public object ActionPlayer2
        {
            get
            {
                return actionPlayer2;
            }
        }

        /// <summary>
        /// Command d'acces du replay
        /// </summary>
        public ICommand ReplayAccessCommand
        {
            get
            {
               return this.replayAccessCommand ?? (replayAccessCommand = new RelayCommand(accessReplay));
            }
        }

        /// <summary>
        /// Action de l'acces au replay
        /// </summary>
        private void accessReplay()
        {
            mI.replayCurrentGame(game.Board.MementoManager.getId());
        }
    }
}
