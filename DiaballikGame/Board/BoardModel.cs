using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaballik;
using System.Windows.Controls;
using DiaballikGame.Utils;

namespace DiaballikGame.Board
{
    /// <summary>
    /// Modele de la vue Board
    /// </summary>
    /// <seealso cref="DiaballikGame.Utils.ViewModelBase" />
    class BoardModel : ViewModelBase
    {
        /// <summary>
        /// Plateau du jeu
        /// </summary>
        private Diaballik.Board b;
        /// <summary>
        /// Grille de la vue
        /// </summary>
        private Grid gridBoard;

        /// <summary>
        /// Constructor <see cref="BoardModel"/> class.
        /// </summary>
        /// <param name="b">Le plateau (modele).</param>
        /// <param name="gridBoard">La grille</param>
        /// <param name="game">Le jeu</param>
        public BoardModel(Diaballik.Board b, Grid gridBoard,Diaballik.Game game) 
        {
            this.b = b;
            this.gridBoard = gridBoard;
            setUpBoard(game);
        }

        /// <summary>
        /// Initialisation du board
        /// </summary>
        /// <param name="game">Le jeu</param>
        private void setUpBoard(Diaballik.Game game)
        {
            for (int i = 0; i < b.SizeBoard; i++)
            {
                for (int j = 0; j < b.SizeBoard; j++)
                {
                    Tile t = b.getTile(i, j);
                    TileView tV = new TileView(t, game);
                    Grid.SetRow(tV, i);
                    Grid.SetColumn(tV, j);
                    this.gridBoard.Children.Add(tV);
                }
            }
        }
    }
}
