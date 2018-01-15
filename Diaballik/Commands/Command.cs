using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Diaballik
{
    /// <summary>
    /// Classe qui gére une commande
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Type de Commande possible
        /// </summary>
        public enum COMMAND_ACTION { BALL, PIECE };
        /// <summary>
        /// Case
        /// </summary>
        private Tile tile;
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="tile"></param>
        protected Command(Tile tile)
        {
            this.tile = tile;
        }
        /// <summary>
        /// Methode qui execute la commande dans l'envirronement du plateau
        /// </summary>
        /// <param name="board"></param>
        abstract public void execute(Board board);

        /// <summary>
        /// Getter de la tile
        /// </summary>
        public Tile Tile
        {
            get
            {
                return this.tile;
            }
        }
    }
}