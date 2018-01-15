using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaballik;
using System.Windows;
using DiaballikGame.Utils;

namespace DiaballikGame.Board
{
    /// <summary>
    /// Modele pour une Case
    /// </summary>
    /// <seealso cref="DiaballikGame.Utils.ViewModelBase" />
    class TileModel : ViewModelBase
    {
        /// <summary>
        /// Modele de la case
        /// </summary>
        private Tile tile;
        /// <summary>
        /// Modele du jeu
        /// </summary>
        private Diaballik.Game game;

        /// <summary>
        /// Constructor <see cref="TileModel"/> class.
        /// </summary>
        /// <param name="tile">Le modele de la case</param>
        /// <param name="game">Le modele du jeu</param>
        public TileModel(Tile tile, Diaballik.Game game)
        {
            this.tile = tile;
            this.game = game;
        }

        /// <summary>
        /// Getter de la case
        /// </summary>
        /// <value>
        /// Case
        /// </value>
        public Tile Tile
        {
            get
            {
                return this.tile;
            }
        }

        /// <summary>
        /// Gestion du click sur la case
        /// </summary>
        public void click(){
            Diaballik.Player p = game != null ? game.PlayerWhoPlay: null ;
            tile.click(p);
        }
    }
}
