using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaballikGame.Utils;
using DiaballikGame.Board;
using Diaballik;
using DiaballikGame.Welcome;

namespace DiaballikGame.Game
{
    /// <summary>
    /// Modele de la vue MainGameModel
    /// </summary>
    /// <seealso cref="DiaballikGame.Utils.ViewModelBase" />
    class MainGameModel : ViewModelBase
    {
        /// <summary>
        /// Vues du jeu
        /// </summary>
        private object boardView,gameManager;

        /// <summary>
        /// Constructeur  <see cref="MainGameModel"/> class.
        /// </summary>
        /// <param name="mI">Acces à la fenetre principale</param>
        /// <param name="game">Modele du plateau</param>
        public MainGameModel(MainInterface mI,Diaballik.Game game)
        {
            boardView = new DiaballikGame.Board.Board(game.Board, game);
            gameManager = new GameManager(game, mI);
        }

        /// <summary>
        /// Getter de la vue du plateau
        /// </summary>
        public object BoardView
        {
            get
            {
                return this.boardView;
            }
        }

        /// <summary>
        /// Getter de la vue du replay
        /// </summary>
        public object GameManager
        {
            get
            {
                return this.gameManager;
            }
        }

       

    }
}
